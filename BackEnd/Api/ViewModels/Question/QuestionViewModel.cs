using Api.ViewModels.CategoryQuestion;

namespace Api.ViewModels.Question;

public class QuestionViewModel
{
    public Guid QuestionId { get; set; }
    public string QuestionString { get; set; } 
    public Guid CategoryQuestionId { get; set; }
    public CategoryQuestionViewModel CategoryQuestion { get; set; } 
}