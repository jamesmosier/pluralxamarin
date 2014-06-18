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