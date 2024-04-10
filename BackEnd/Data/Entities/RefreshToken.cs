using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public partial class RefreshToken
    {
        [Key]
        public int Id { get; set; }

        public string Token { get; set; }
        public DateTime? ExpiryOn { get; set; } = DateTime.MinValue;
        public DateTime? CreatedOn { get; set; } = DateTime.Now;
        public string? CreatedByIp { get; set; }
        public DateTime? RevokedOn { get; set; } = DateTime.MinValue;
        public string? RevokedByIp { get; set; }

        public string UserId { get; set; }
        public virtual WebUser User { get; set; }
    }
}