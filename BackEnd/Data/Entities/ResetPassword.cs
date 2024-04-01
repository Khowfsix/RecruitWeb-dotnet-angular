using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public partial class ResetPassword
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string OTP { get; set; }

        [Required]
        public DateTime InsertDateTimeUTC { get; set; }
    }
}