using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7Day3.Entities;
using Week7Day3.Interfaces;

namespace Week7Day3.Repositories
{
    class UserListRepository : IUserDbManager
    {
        public static List<User> users = new List<User>()
        {
            new User("Pippo","Neri",new DateTime(2009,07,16),EnumSex.M,false, null),
            new User("Pluto","PP",new DateTime(2001,07,16),EnumSex.M,true, null),
            new User("Paperino","Pap",new DateTime(2002,07,16),EnumSex.M,false, null),
            new User("Minnie","Mouse",new DateTime(2003,07,16),EnumSex.F,true, null),
            new User("Paperina","Pap",new DateTime(2005,07,16),EnumSex.F,true, null)
        };
        public void Delete(User user)
        {
            users.Remove(user);
        }

        public List<User> Fetch()
        {
            return users;
        }

        public User GetById(int? id)
        {
            return users.Find(u => u.Id == id);
        }

        public void Insert(User user)
        {
            users.Add(user);
        }

        public void Update(User user)
        {
            var userToDelete = GetById(user.Id);
            Delete(userToDelete);
            Insert(user);
        }
    }
}
