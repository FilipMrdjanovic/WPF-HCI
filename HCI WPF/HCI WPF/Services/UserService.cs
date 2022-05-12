using HCI_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_WPF.Services
{
    public class UserService
    {
        private Repository.UserRepository userRepository = new Repository.UserRepository();
        public List<User> GetAll()
        {
            return userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return userRepository.GetById(id);
        }

        public void Save(User user)
        {
            userRepository.Save(user);
        }

        public void Delete(int id)
        {
            userRepository.Delete(id);
        }
    }
}
