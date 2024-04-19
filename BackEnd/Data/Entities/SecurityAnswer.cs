using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class SecurityAnswer
    {
        [Key]
        public Guid SecurityAnswerId;

        [Required]
        public string AnswerString { get; set; }

        public Guid SecurityQuestionId;

        public string WebUserId { get; set; }
        public virtual SecurityQuestion SecurityQuestion { get; set; } = new SecurityQuestion();
        public virtual WebUser WebUser { get; set; } = new WebUser();
    }
}