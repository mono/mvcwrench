namespace MvcWrench.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.Mvc;
	using System.Web.Security;
	using DotNetOpenAuth.Messaging;
	using DotNetOpenAuth.OpenId;
	using DotNetOpenAuth.OpenId.RelyingParty;
	using MvcWrench.Models;

	public class UserController : ApplicationController
	{
		private static OpenIdRelyingParty openid = new OpenIdRelyingParty ();

		public ActionResult Index ()
		{
			if (!User.Identity.IsAuthenticated) {
				Response.Redirect ("/User/Login?ReturnUrl=Index");
			}

			return View ("Index");
		}

		//public ActionResult LoginPopup ()
		//{
		//        return View ("LoginPopup");
		//}

		public ActionResult Logout ()
		{
			FormsAuthentication.SignOut ();
			return Redirect ("/Home");
		}

		public ActionResult Login ()
		{
			// Stage 1: display login form to user
			return View ("Login");
		}
		
		public ActionResult Profile ()
		{
			return View ("Profile", CurrentUser);
		}

		[AcceptVerbs (HttpVerbs.Post)]
		public ActionResult Profile (User user)
		{
			if (string.IsNullOrEmpty (user.Email))
				ModelState.AddModelError ("Email", "You must provide an email address");
			if (!UserRepository.IsSvnAccountAvailable (CurrentUser.ID, user.SvnAccount))
				ModelState.AddModelError ("SvnAccount", "SVN account has already been claimed");
						
			if (!ModelState.IsValid)
				return View ("Profile", user);
			
			UserRepository.SaveUser (user);
			
			return RedirectToAction ("Index", "Home");
		}

		[ValidateInput (false)]
		public ActionResult Authenticate (string returnUrl)
		{
			var response = openid.GetResponse ();
			if (response == null) {
				// Stage 2: user submitting Identifier
				Identifier id;
				if (Identifier.TryParse (Request.Form["openid_identifier"], out id)) {
					try {
						return openid.CreateRequest (Request.Form["openid_identifier"]).RedirectingResponse.AsActionResult ();
					} catch (ProtocolException ex) {
						ViewData["Message"] = ex.Message;
						return View ("Login");
					}
				} else {
					ViewData["Message"] = "Invalid identifier";
					return View ("Login");
				}
			} else {
				// Stage 3: OpenID Provider sending assertion response
				switch (response.Status) {
					case AuthenticationStatus.Authenticated:
						User user = UserRepository.GetUserFromOpenId (response.ClaimedIdentifier);
						
						// This is a new user, send them to a registration page
						if (user == null) {
							ViewData["openid"] = response.ClaimedIdentifier;
							return Redirect (string.Format ("~/user/register?openid={0}", Url.Encode (response.ClaimedIdentifier)));
						}

						Session["FriendlyIdentifier"] = response.FriendlyIdentifierForDisplay;
						FormsAuthentication.SetAuthCookie (user.Name, false);

						if (!string.IsNullOrEmpty (returnUrl)) {
							return Redirect (returnUrl);
						} else {
							return RedirectToAction ("Index", "Home");
						}
					case AuthenticationStatus.Canceled:
						ViewData["Message"] = "Canceled at provider";
						return View ("Login");
					case AuthenticationStatus.Failed:
						ViewData["Message"] = response.Exception.Message;
						return View ("Login");
				}
			}
			return new EmptyResult ();
		}

		public ActionResult Register ()
		{
			MvcWrench.Models.User user = new MvcWrench.Models.User ();
			user.OpenID = Request.QueryString["openid"];

			return View ("Registration", user);
		}

		[AcceptVerbs (HttpVerbs.Post)]
		public ActionResult Register (User user)
		{
			if (string.IsNullOrEmpty (user.Name) || string.IsNullOrEmpty (user.Email)) {
				if (string.IsNullOrEmpty (user.Name))
					ModelState.AddModelError ("Name", "You must pick a username");
				if (string.IsNullOrEmpty (user.Email))
					ModelState.AddModelError ("Email", "You must provide an email address");

				return View ("Registration", user);			
			}
			
			if (UserRepository.IsUserNameAvailable (user.Name)) {
				UserRepository.CreateUser (user);

				FormsAuthentication.SetAuthCookie (user.Name, true);

				return RedirectToAction ("Index", "Home");
			}

			ModelState.AddModelError ("Name", "This username is not available, please choose another");

			return View ("Registration", user);
		}
	}
}
