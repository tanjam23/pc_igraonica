using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserBusiness
    {
        private UserRepository userRepository;

        public UserBusiness()
        {
            this.userRepository = new UserRepository();
        }

        public List<User> GetAllUsers()
        {
            return this.userRepository.GetAllUsers();
        }

        public List<User> GetAllUsersByUsername(string username)
        {
            return this.userRepository.GetAllUsers().Where(u => u.username.Contains(username)).ToList();
        }

        public bool InsertUser(User u)
        {
            int res = 0;
            if (u != null)
            {
                res = this.userRepository.InsertUser(u);
            }
            if (res > 0)
            {
                return true;
            }
            return false;
        }
        public void UpdateUser(User u)
        {
            this.userRepository.UpdateUser(u);
        }

        public void DeleteUser(User u)
        {
            this.userRepository.DeleteUser(u);
        }
    }
}
