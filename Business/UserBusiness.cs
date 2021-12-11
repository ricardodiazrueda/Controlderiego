using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data;

namespace Business
{
    public class UserBusiness
    {
        UserData userData = new UserData();
        LogData logData = new LogData();
        public string Create(UserEntity user)
        {
            string result = userData.Insert(user);
            
            if (result == "OK")
                logData.Insert(new LogEntity() { EntityID = null, Type = "CREATE USER", Data = "Created user FullName: " + user.FullName + ", Username: " + user.UserName });

            return result;
        }
        public UserEntity Login(string username, string password)
        {
            UserEntity user = userData.Read(username, password);

            int? entity = null;
            string type = "LOGIN FAIL";
            string data = string.Format("Username: {0}", username); 
            if (user != null)
            {
                entity = user.UserID;
                type = "LOGIN SUCCESS";
            }
            logData.Insert(new LogEntity() { EntityID = entity, Type = type, Data = data });

            return user;
        }
    }
}
