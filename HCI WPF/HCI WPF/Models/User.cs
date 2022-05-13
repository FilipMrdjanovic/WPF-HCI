using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_WPF.Models
{
    public class User
    {
        public int Id { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Email { get; set; }
        public static readonly User Instance = new User();

        public User(int id, string username, string password, string name, string surname, string email)
        {
            Id = id;
            Username = username;
            Password = password;
            Name = name;
            Surname = surname;
            Email = email;
        }
        public User()
        {

        }
    }
}
