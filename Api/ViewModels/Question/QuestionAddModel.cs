using System;
using System.Collections.Generic;

namespace Data.ViewModels.Question;

public class QuestionAddModel
{
    public string QuestionString { get; set; } = null!;

    public Guid CategoryQuestionId { get; set; }
}
