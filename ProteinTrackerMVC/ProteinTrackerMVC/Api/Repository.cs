using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProteinTrackerMVC.Api
{
    public interface IRepository
    {
        long AddUser(string name, int goal);
    }
    public class Repository : IRepository
    {
        IRedisClientsManager RedisManager { get; set; }

        public Repository(IRedisClientsManager redisManager)
        {
            RedisManager = redisManager;
        }

        public long AddUser(string name, int goal)
        {
            using (var redisClient = RedisManager.GetClient())
            {
                var redisUsers = redisClient.As<User>();
                var user = new User() { Name = name, Goal = goal, Id = redisUsers.GetNextSequence() };
                redisUsers.Store(user);
                return user.Id;
            }
        }
    }
}