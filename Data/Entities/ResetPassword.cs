using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public partial class ResetPassword
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [Required]
        public string OTP { get; set; }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [Required]
        public DateTime InsertDateTimeUTC { get; set; }
    }
}