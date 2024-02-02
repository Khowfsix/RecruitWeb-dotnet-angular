namespace Api.ViewModels.Question;

public class QuestionAddModel
{
    public string QuestionString { get; set; } = null!;

    public Guid CategoryQuestionId { get; set; }
}