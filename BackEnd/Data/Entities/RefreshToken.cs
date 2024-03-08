﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public partial class RefreshToken
    {
        [Key]
        public int Id { get; set; }
        public string Token { get; set; } = null!;
        public string JwtId { get; set; } = null!;
        public DateTime CreatedDateTimeUtc { get; set; }
        public DateTime ExpiryDateTimeUtc { get; set; }
        public bool Used { get; set; }
        public bool Invalidated { get; set; }
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;
    }
}