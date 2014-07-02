using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProteinTrackerMVC.Api
{
	public class User
	{
		public string Name { get; set; }
		public int Goal { get; set; }
		public int Total { get; set; }
		public long Id { get; set; }

		public override string ToString ()
		{
			return Name;
		}
	}

	public class AddProteinResponse
	{
		public int NewTotal { get; set; }
	}

	[Route("/users/{userid}", "POST")]
	public class AddProtein : IReturn<AddProteinResponse>
	{
		public long UserId { get; set; }
		public int Amount { get; set; }
	}

	public class UsersResponse
	{
		public IEnumerable<User> Users { get; set; }
	}

	[Route("/users", "GET")]
	public class Users : IReturn<AddProteinResponse>
	{

	}

	public class AddUserResponse
	{
		public long UserId { get; set; }
	}

	[Route("/users", "POST")]
	public class AddUser: IReturn<AddProteinResponse>
	{
		public string Name { get; set; }
		public int Goal { get; set; }
	}


}