using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OxiServi.AggregatesModel.AuthAggregate
{
    public class UserLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public void Login(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
