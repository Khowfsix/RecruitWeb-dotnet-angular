using System.ComponentModel.DataAnnotations;

namespace Api.ViewModels.Authentication.LogIn
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Username is reqired")]
        public string Username { get; set; }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [Required(ErrorMessage = "Current password is reqired")]
        public string CurrentPassword { get; set; }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [Required(ErrorMessage = "New password is reqired")]
        public string NewPassword { get; set; }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [Required(ErrorMessage = "Confirm password is reqired")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmpassword do not match")]
        public string ConfirmPassword { get; set; }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}