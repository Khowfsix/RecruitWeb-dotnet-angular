using Data.Models;
using Data.ViewModels.SecurityAnswer;

namespace Service.Interfaces
{
    public interface ISecurityAnswerService
    {
        Task<IEnumerable<SecurityAnswerViewModel>> GetAllSecurityAnswers();
        Task<SecurityAnswerViewModel> SaveSecurityAnswer(SecurityAnswerAddModel viewModel);
        Task<bool> UpdateSecurityAnswer(SecurityAnswerUpdateModel reportModel, Guid reportModelId);
        Task<bool> DeleteSecurityAnswer(Guid reportModelId);
    }
}