using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Web.Configuration;

namespace MvcWrench.Models
{
	public static class UserRepository
	{
		private static string conn_string;
		
		static UserRepository ()
		{
			conn_string = WebConfigurationManager.ConnectionStrings["Postgres"].ConnectionString;
		}
		
		public static User GetUserFromOpenId (string openid)
		{
			NpgsqlConnection conn = new NpgsqlConnection (conn_string);
			conn.Open ();
			
			NpgsqlCommand comm = conn.CreateCommand ();
			
			string sql = "SELECT * FROM openids WHERE id = @id";
			comm.CommandText = sql;
			
			comm.Parameters.Add ("@id", openid);
			
			NpgsqlDataReader reader = comm.ExecuteReader ();
			
			int user_id = -1;
			
			while (reader.Read ())
				user_id = (int)reader["UserID"];
			
			reader.Close ();
			comm.Dispose ();
			conn.Close ();

			if (user_id == -1)
				return null;
				
			return GetUser (user_id);
		}
		
		public static User GetUserFromSvn (string svn)
		{
			NpgsqlConnection conn = new NpgsqlConnection (conn_string);
			conn.Open ();

			NpgsqlCommand comm = conn.CreateCommand ();

			string sql = "SELECT * FROM users WHERE svn = @svn";
			comm.CommandText = sql;

			comm.Parameters.Add ("@svn", svn);

			NpgsqlDataReader reader = comm.ExecuteReader ();

			User user = null;

			while (reader.Read ())
				user = new User (reader);

			reader.Close ();
			comm.Dispose ();
			conn.Close ();

			return user;
		}

		public static User GetUser (int id)
		{
			NpgsqlConnection conn = new NpgsqlConnection (conn_string);
			conn.Open ();

			NpgsqlCommand comm = conn.CreateCommand ();

			string sql = "SELECT * FROM users WHERE id = @id";
			comm.CommandText = sql;

			comm.Parameters.Add ("@id", id);

			NpgsqlDataReader reader = comm.ExecuteReader ();

			User user = null;

			while (reader.Read ())
				user = new User (reader);

			reader.Close ();
			comm.Dispose ();
			conn.Close ();

			return user;
		}

		public static User GetUser (string name)
		{
			NpgsqlConnection conn = new NpgsqlConnection (conn_string);
			conn.Open ();

			NpgsqlCommand comm = conn.CreateCommand ();

			string sql = "SELECT * FROM users WHERE name = @name";
			comm.CommandText = sql;

			comm.Parameters.Add ("@name", name);

			NpgsqlDataReader reader = comm.ExecuteReader ();

			User user = null;

			while (reader.Read ())
				user = new User (reader);

			reader.Close ();
			comm.Dispose ();
			conn.Close ();

			return user;
		}
		
		public static User CreateUser (User user)
		{
			NpgsqlConnection conn = new NpgsqlConnection (conn_string);
			NpgsqlCommand comm = conn.CreateCommand ();

			// Add data to the User table
			string sql = "INSERT INTO users (name, email) VALUES (@name, @email)";
			comm.CommandText = sql;

			comm.Parameters.Add ("@name", user.Name);
			comm.Parameters.Add ("@email", user.Email);

			conn.Open ();
			comm.ExecuteNonQuery ();
			comm.Dispose ();
			
			User new_user = GetUser (user.Name);
			
			// Add data to the OpenID table
			comm = conn.CreateCommand ();
			
			sql = "INSERT INTO openids (id, userid) VALUES (@id, @userid)";
			comm.CommandText = sql;

			comm.Parameters.Add ("@id", user.OpenID);
			comm.Parameters.Add ("@userid", new_user.ID);

			comm.ExecuteNonQuery ();

			comm.Dispose ();
			conn.Close ();
			
			return new_user;
		}
		
		public static void SaveUser (User user)
		{
			NpgsqlConnection conn = new NpgsqlConnection (conn_string);
			NpgsqlCommand comm = conn.CreateCommand ();

			// Add data to the User table
			string sql = "UPDATE users SET email = @email, gravatar = @gravatar, svn = @svn WHERE id = @id";
			comm.CommandText = sql;

			comm.Parameters.Add ("@id", user.ID);
			comm.Parameters.Add ("@svn", user.SvnAccount);
			comm.Parameters.Add ("@email", user.Email);
			comm.Parameters.Add ("@gravatar", user.Gravatar);

			conn.Open ();
			comm.ExecuteNonQuery ();
			comm.Dispose ();
		}

		internal static bool IsUserNameAvailable (string name)
		{
			return GetUser (name) == null;
		}

		internal static bool IsSvnAccountAvailable (int userId, string account)
		{
			NpgsqlConnection conn = new NpgsqlConnection (conn_string);
			NpgsqlCommand comm = conn.CreateCommand ();

			// Add data to the User table
			string sql = "SELECT COUNT (*) FROM users WHERE id != @id AND svn = @svn";
			comm.CommandText = sql;

			comm.Parameters.Add ("@id", userId);
			comm.Parameters.Add ("@svn", account);

			conn.Open ();
			Int64 count = (Int64)comm.ExecuteScalar ();
			comm.Dispose ();
			
			return count == 0;
		}
		
		public static List<Role> GetRolesForUser (int userId)
		{
			NpgsqlConnection conn = new NpgsqlConnection (conn_string);
			NpgsqlCommand comm = conn.CreateCommand ();

			string sql = "SELECT * FROM roles, userroles WHERE userroles.roleid = roles.id and userroles.userid = @userid";
			comm.CommandText = sql;

			comm.Parameters.Add ("@userid", userId);

			conn.Open ();

			NpgsqlDataReader reader = comm.ExecuteReader ();

			List<Role> roles = new List<Role> ();

			while (reader.Read ())
				roles.Add (new Role (reader));

			reader.Close ();
			comm.Dispose ();
			conn.Close ();

			return roles;
		}
		
		public static Dictionary<string, string> GetSvnGravatars ()
		{
			NpgsqlConnection conn = new NpgsqlConnection (conn_string);
			NpgsqlCommand comm = conn.CreateCommand ();

			string sql = "SELECT svn, gravatar FROM users WHERE svn <> '' AND gravatar <> ''";
			comm.CommandText = sql;

			conn.Open ();

			NpgsqlDataReader reader = comm.ExecuteReader ();

			Dictionary<string, string> gravatars = new Dictionary<string,string> ();

			while (reader.Read ())
				gravatars.Add ((string)reader["svn"], (string)reader["gravatar"]);

			reader.Close ();
			comm.Dispose ();
			conn.Close ();

			return gravatars;
		}
	}
}
