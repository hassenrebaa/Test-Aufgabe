using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Aufgabe.Models.Repositories
{
    public class UserRepository : IUserRepository<User>
    {   // User Repository
        IList<User> users;
        public UserRepository()
        {
            users = new List<User>();
            

       
        }
        // Create Methode 
        public void Add(User entity)
        {
            entity.id = users.Max(b => b.id) + 1;
            users.Add(entity);

        }
       
        public User Find(int id)
        {
            var user = users.SingleOrDefault(b => b.id == id);
            return user;
        }



        public IList<User> List()
        {
            return users.ToList();
        }
    }
}


