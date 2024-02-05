using Api.ViewModels.Certificate;

namespace Api.ViewModels.Cv
{
    public class CvUpdateModel
    {
        public Guid Cvid { get; set; }
        public Guid CandidateId { get; set; }
        public string? Experience { get; set; }
        public string? CvPdf { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string CvName { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Introduction { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Education { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public bool IsDeleted { get; set; }
        public IList<CvSkillRelationUpdateModel> Skills { get; set; } = new List<CvSkillRelationUpdateModel>();
        public IList<CertificateUpdateModel> Certificates { get; set; } = new List<CertificateUpdateModel>();
    }

    public class CvSkillRelationUpdateModel
    {
        public Guid SkillId { get; set; }
        public int ExperienceYear { get; set; }
    }
}