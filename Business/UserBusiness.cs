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
        public string Create(UserEntity user)
        {
            return userData.Insert(user);
        }
        public UserEntity Login(string username, string password)
        {
            return userData.Read(username, password);
        }
    }
}
