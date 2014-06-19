using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProteinTrackerMVC.Api
{
    public class UserService : Service
    {
        public IRepository Repository { get; set; }
        public object Post(AddUser request)
        {
            var id = Repository.AddUser(request.Name, request.Goal);
            return new AddUserResponse { UserId = id };
        }

        public object Get(Users request)
        {
            return new UsersResponse { Users = Repository.GetUsers() };
        }

        public object Post(AddProtein request)
        {
            var user = Repository.GetUsers(request.UserId);
            user.Total += request.Amount;
            Repository.UpdateUser(user);
            return new AddProteinResponse { NewTotal = user.Total };
        }
    }

    public class AddProteinResponse
    {
        public int NewTotal { get; set; }
    }

    [Route("/users/{userid}", "POST")]
    public class AddProtein
    {
        public long UserId { get; set; }
        public int Amount { get; set; }
    }

    public class UsersResponse
    {
        public IEnumerable<User> Users { get; set; }
    }

    [Route("/users", "GET")]
    public class Users
    {

    }

    public class AddUserResponse
    {
        public long UserId { get; set; }
    }

    [Route("/users", "POST")]
    public class AddUser
    {
        public string Name { get; set; }
        public int Goal { get; set; }
    }


}