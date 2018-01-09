using CriticalMiss.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CriticalMiss.Library.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; }

        private CriticalMissDbContext db = new CriticalMissDbContext();

        public bool RegisteredUser(string user, string pass)
        {
            var query = (from a in db.user
                        where a.UserName == user && a.Password == pass
                        select new { a.UserName, a.FirstName, a.LastName }).First();

            if(query.FirstName != null)
            {
                return true;
            }
            return false;
        }
    }

    
}
