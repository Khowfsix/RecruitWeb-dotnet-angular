using Api.ViewModels.CategoryQuestion;
using System;
using System.Collections.Generic;

namespace Api.ViewModels.Question;

public class QuestionViewModel
{
    public Guid QuestionId { get; set; }
    public string QuestionString { get; set; } = null!;
    public Guid CategoryQuestionId { get; set; }
    public CategoryQuestionViewModel CategoryQuestion { get; set; } = null!;
}
