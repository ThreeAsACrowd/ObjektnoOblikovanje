
namespace AccountingWPF.Models
{
    public class User
    {
        public User()
        {

        }

        public virtual int Id { get; protected set; }

        //[Required(ErrorMessage = "Username is mandatory")]
        public virtual string Username { get; set; }

        //  [Required(ErrorMessage = "Password is mandatory")]
        public virtual string Password { get; set; }

        public virtual string Email { get; set; }

        public virtual string Address { get; set; }

        public virtual string AssociationName { get; set; }

        public virtual string OIB { get; set; }


    }
}
