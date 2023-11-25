using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Eventures.Models
{
    [BindProperties]
    public class UserLogin
    {
        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "UserName is required")]
        public string? UserName { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
