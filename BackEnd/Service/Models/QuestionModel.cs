namespace Service.Models;

public class QuestionModel
{
    public Guid QuestionId { get; set; }

    public string QuestionString { get; set; } = null!;

    public Guid CategoryQuestionId { get; set; }

    public CategoryQuestionModel CategoryQuestion { get; set; } = null!;
}