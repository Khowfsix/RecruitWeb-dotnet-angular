namespace Api.ViewModels.Question;

public class QuestionUpdateModel
{
    //public Guid QuestionId { get; set; }
    // Update model cũng giống add model, truyền id trên param là được
    public string QuestionString { get; set; } 

    public Guid CategoryQuestionId { get; set; }
}