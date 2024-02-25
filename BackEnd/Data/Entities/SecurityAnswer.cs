using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class SecurityAnswer
    {
        [Key]
        public Guid SecurityAnswerId;

        [Required]
        public string AnswerString = null!;

        public Guid SecurityQuestionId;


        public string WebUserId;



        public virtual SecurityQuestion SecurityQuestion { get; set; }


        public virtual WebUser WebUser { get; set; }

    }
}