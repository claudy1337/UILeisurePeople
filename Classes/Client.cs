using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIKitTutorials.Classes
{
    public class Client
    {
        public Client(int id, string name, string lastName, string login, int role, string link)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Login = login;
            Role = role;
            Link = link;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName {get; set; }
        public string Login { get; set; }
        public int Role { get; set; }
        public string Link { get; set; }

    }
}
