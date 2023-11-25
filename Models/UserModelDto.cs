using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Eventures.Models
{
    public class UserModelDto
    {
        public int Id { get; set; } = 0;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UniqueCitizenNumber { get; set; } = string.Empty;
        public string type { get; set; } = "Guest";

        public UserModelDto(string UserName, string Password, string ConfirmPassword,  string Email, string FirstName, string LastName, string UniqueCitizenNumber, string type)
        {
            this.UserName = UserName;
            this.Password = Password;
            this.ConfirmPassword = ConfirmPassword;
            this.Email = Email;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.UniqueCitizenNumber = UniqueCitizenNumber;
            this.type = type;
        }
        public UserModelDto() { }
    }
}

