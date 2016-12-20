using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingWPF.Models
{
    public class User
    {

		public int Id { get; private set; }

		[Required(ErrorMessage = "Username is mandatory")]
		public string Username { get; set; }

        [Required(ErrorMessage = "Password is mandatory")]
        public string Password { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string AssociationName { get; set; }

        public string OIB { get; set; }


    }
}
