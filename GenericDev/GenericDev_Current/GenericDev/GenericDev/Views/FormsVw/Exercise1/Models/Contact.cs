using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDev.Views.FormsVw.Exercise1.Models
{
    public class Contact
    {
        public int? Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public bool Blocked { get; set; }
    }
}
