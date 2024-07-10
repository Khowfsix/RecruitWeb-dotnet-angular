namespace Service.Models;

public partial class QuestionLanguageModel
{
    public Guid QuestionLanguageId { get; set; }

    public Guid QuestionId { get; set; }

    public Guid LanguageId { get; set; }

    public virtual QuestionModel Question { get; set; } 

    public virtual LanguageModel Language { get; set; } 

 }