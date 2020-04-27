using System.ComponentModel.DataAnnotations;

namespace Login.Application.ViewModel
{
    public class AccountViewModel
    {
        public int Id { get; set; }
        [EmailAddress(ErrorMessage = "This not a valid e-mail")]
        public string Email { get; set; }
        [MinLength (8)]
        [MaxLength(15)]
        public string Password { get; set; }
        [MinLength (5)]
        [MaxLength(20)]
        public string Login { get; set; }
    }
}
