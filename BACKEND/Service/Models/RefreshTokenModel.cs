namespace Service.Models
{
    public class RefreshTokenModel
    {
        public string Token { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public DateTime ExpiryOn { get; set; }
        public DateTime CreatedOn { get; set; }

        //public string CreatedByIp { get; set; } = string.Empty;
        //public DateTime RevokedOn { get; set; }
        //public string RevokedByIp { get; set; } = string.Empty;
    }
}
