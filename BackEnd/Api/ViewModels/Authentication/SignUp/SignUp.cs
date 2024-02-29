using System.ComponentModel.DataAnnotations;

public class SignUp
{
    public string? FullName { get; set; }
    public string? Username { get; set; }

    [EmailAddress]
    [Required(ErrorMessage = "Email is required")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }

    public Guid CompanyId { get; set; } = Guid.NewGuid();
}