using Data.ViewModels.CategoryQuestion;

namespace Data.ViewModels.Question;

public class CategoryQuestionBankModel
{
    public ICollection<CategoryQuestionViewModel> CategoryQuestions { get; set; } = new List<CategoryQuestionViewModel>();
}