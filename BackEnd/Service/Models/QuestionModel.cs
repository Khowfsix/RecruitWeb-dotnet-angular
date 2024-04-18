namespace Service.Models;

public class QuestionModel
{
    public Guid QuestionId { get; set; }

    public string QuestionString { get; set; } 

    public Guid CategoryQuestionId { get; set; }

    public CategoryQuestionModel CategoryQuestion { get; set; } 
}