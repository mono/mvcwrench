using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

namespace MvcWrench.Models
{
	public class Role
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		internal Role (NpgsqlDataReader reader)
		{
			ID = (int)reader["id"];
			Name = (string)reader["name"];
			Description = (string)reader["description"];
		}
	}
}
