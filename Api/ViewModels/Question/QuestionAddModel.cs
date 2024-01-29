using System;
using System.Collections.Generic;

namespace Api.ViewModels.Question;

public class QuestionAddModel
{
    public string QuestionString { get; set; } = null!;

    public Guid CategoryQuestionId { get; set; }
}
