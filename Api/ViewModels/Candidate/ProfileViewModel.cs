using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.ViewModels.Candidate
{
    public class ProfileViewModel

    {
        public Guid UserId { get; set; }
        public Guid CandidateId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; } = null!;
        public string? ImageURL { get; set; } = null;
        public string? Status { get; set; }
        public bool? Priority { get; set; }
        public Guid BlacklistId { get; set; }
        public string? Reason { get; set; }

    }

}
