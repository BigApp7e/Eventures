using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventures.Models
{
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "UserName is required")]
        public string? UserName { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "FirstName is required")]

        public string? FirstName { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "LastName is required")]

        public string? LastName { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "UniqueCitizenNumber is required")]
        public string? UniqueCitizenNumber { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string type { get; set; } = "User";

        public UserModel(string UserName, string Password,  string Email, string FirstName, string LastName, string UniqueCitizenNumber, string type)
        {
            this.UserName = UserName;
            this.Password = Password;
            this.Email = Email;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.UniqueCitizenNumber = UniqueCitizenNumber;
            this.type = type;
        }
    }
}
