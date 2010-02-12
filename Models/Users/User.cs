using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

namespace MvcWrench.Models
{
	public class User
	{
		public int ID { get; set; }
		public string OpenID { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Gravatar { get; set; }
		public string SvnAccount { get; set; }
		
		public bool IsAdministrator { get { return IsInRole ("Administrator"); } }
		public bool IsNovell { get { return IsInRole ("Novell"); } }
		
		private List<Role> roles;

		public User ()
		{
		
		}
		
		internal User (NpgsqlDataReader reader)
		{
			ID = (int)reader["id"];
			Name = (string)reader["name"];
			Email = (string)reader["email"];
			Gravatar = (string)reader["gravatar"];
			SvnAccount = (string)reader["svn"];
		}
		
		public bool IsInRole (string role)
		{
			if (roles == null)
				roles = UserRepository.GetRolesForUser (ID);
				
			foreach (Role r in roles)
				if (string.Compare (role, r.Name, true) == 0)
					return true;
					
			return false;
		}
		
		public string GetGravatar (int size)
		{
			string grav = Gravatar;

			grav = string.IsNullOrEmpty (grav) ? SvnAccount : grav;
			grav = string.IsNullOrEmpty (grav) ? Name : grav;
			
			return UserHelpers.EmailToGravatar (grav, size);
		}
	}
}
