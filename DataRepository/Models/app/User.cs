
namespace DataRepository.Models
{

    public class User
    {
        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string Email { get; set; }
        public virtual string Address { get; set; }
        public virtual string AssociationName { get; set; }
        public virtual string OIB { get; set; }

    }
}
