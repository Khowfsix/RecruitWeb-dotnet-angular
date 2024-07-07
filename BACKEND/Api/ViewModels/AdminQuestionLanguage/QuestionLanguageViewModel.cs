using Api.ViewModels.Language;
using Api.ViewModels.Question;

namespace Api.ViewModels.AdminQuestionLanguage;

public partial class QuestionLanguageViewModel
{
    public Guid QuestionLanguageId { get; set; }

    public Guid QuestionId { get; set; }

    public Guid LanguageId { get; set; }

    public virtual QuestionViewModel Question { get; set; } 

    public virtual LanguageViewModel Language { get; set; } 

 }