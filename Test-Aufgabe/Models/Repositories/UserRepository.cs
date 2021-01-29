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
        public void Add(User entity, int id)
        {
            entity.id =id+ 1;
            users.Add(entity);

        }
       
        public User Find(int id)
        {
            var user = users.Where(b => b.id == id).First();
            return user;
        }



        public IList<User> List()
        {
            return users.ToList();
        }
    }
}


