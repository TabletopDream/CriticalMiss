using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lib = CriticalMiss.Library.Models;

namespace CriticalMiss.UI.Models
{
    public class SuperModel
    {
        public bool verifyRegistered(User u)
        {
            lib.User user = new lib.User();
            if (user.RegisteredUser(u.UserName, u.Password))
            {
                return true;
            }
            return false;
        }
    }
}
