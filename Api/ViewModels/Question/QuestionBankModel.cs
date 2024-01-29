using Api.ViewModels.CategoryQuestion;

namespace Api.ViewModels.Question;

public class CategoryQuestionBankModel
{
    public ICollection<CategoryQuestionViewModel> CategoryQuestions { get; set; } = new List<CategoryQuestionViewModel>();
}