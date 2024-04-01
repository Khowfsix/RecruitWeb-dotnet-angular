using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public partial class RefreshToken
    {
        [Key]
        public int Id { get; set; }

        public string Token { get; set; } = string.Empty;
        public DateTime? ExpiryOn { get; set; } = DateTime.MinValue;
        public DateTime? CreatedOn { get; set; } = DateTime.Now;
        public string? CreatedByIp { get; set; } = string.Empty;
        public DateTime? RevokedOn { get; set; } = DateTime.MinValue;
        public string? RevokedByIp { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;
        public virtual WebUser User { get; set; } = new();
    }
}