using System.ComponentModel.DataAnnotations;

namespace Med.Core.Requests.Account;

public class LoginRequest : Request
{
    [Required(ErrorMessage = "E-mail")]
    [EmailAddress(ErrorMessage ="Invalid e-mail")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Invalid password")]
    public string Password { get; set; } = string.Empty;
}
