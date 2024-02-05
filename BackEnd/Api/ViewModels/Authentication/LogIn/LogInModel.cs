using System.ComponentModel.DataAnnotations;

public class LogInModel
{
    [Required(ErrorMessage = "User Name is required")]
    public string Username { get; set; }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}