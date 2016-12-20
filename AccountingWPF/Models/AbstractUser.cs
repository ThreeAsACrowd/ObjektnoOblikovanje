using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingWPF.Models
{
     class User
    {

        public int id { get; }
        [Required(ErrorMessage = "Username is mandatory")]
        public String username { get { return username; } set { this.username = value; } }
        [Required(ErrorMessage = "Password is mandatory")]
        public String password { get; set; }
        public String email { get; set; }
        public String address { get; set; }
        public String associationName { get; set; }
        public String OIB { get; set; }


    }
}
