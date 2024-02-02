using Data.Entities;

namespace Service.Interfaces
{
    public interface ISecurityAnswerService
    {
        Task<IEnumerable<SecurityAnswerModel>> GetAllSecurityAnswers();

        Task<SecurityAnswerModel> SaveSecurityAnswer(SecurityAnswerModel viewModel);

        Task<bool> UpdateSecurityAnswer(SecurityAnswerModel reportModel, Guid reportModelId);

        Task<bool> DeleteSecurityAnswer(Guid reportModelId);
    }
}