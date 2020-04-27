using System.ComponentModel.DataAnnotations;

namespace Login.Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public bool Deleted { get; set; }
    }
}
