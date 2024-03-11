using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class SecurityQuestion
    {
        [Key]
        public Guid SecurityQuestionId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string QuestionString { get; set; } = null!;
        public virtual IList<SecurityAnswer>? SecurityAnswers { get; set; }
    }
}