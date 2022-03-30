using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersAspnet.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string  LastName { get; set; }
        public string  MiddilName { get; set; }
        public string  Age { get; set; }
        public string  Phone { get; set; }
        public string  Address { get; set; }
    }
}
