﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.ViewModels.Certificate
{
    public class CertificateAddModel
    {
        public string CertificateName { get; set; } = null!;

        public string? Description { get; set; }

        public string? OrganizationName { get; set; }

        public DateTime DateEarned { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public string? Link { get; set; }

        public Guid Cvid { get; set; }

        public bool IsDeleted { get; set; } = false;
    }

}
