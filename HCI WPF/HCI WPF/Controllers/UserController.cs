using HCI_WPF.Models;
using HCI_WPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_WPF.Controllers
{
    public class UserController
    {
        private UserService userService = new UserService();
        public List<User> GetAll()
        {
            return userService.GetAll();
        }

        public User GetById(int id)
        {
            return userService.GetById(id);
        }

        public void Save(User user)
        {
            userService.Save(user);
        }

        public void Delete(int id)
        {
            userService.Delete(id);
        }


        public User Login(string username, string password)
        {
            foreach(User user in GetAll())
            {
                if (user.Username.Equals(username) && user.Password.Equals(password))
                    return user;
            }
            return null;
        }

    }
}
