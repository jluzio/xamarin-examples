using System;
using System.Collections.Generic;
using System.Text;

namespace BootcampTap.Core.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Username{ get; set; }
        public string Password { get; set; }
        public UserType Type { get; set; }

    }

    public enum UserType
    {
        Null,
        Admin,
        Collab
    }

}
