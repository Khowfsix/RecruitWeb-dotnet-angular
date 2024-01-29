using Data.Entities;

using Api.ViewModels.SecurityAnswer;

namespace Data.Interfaces
{
    public interface ISecurityAnswerRepository : IRepository<SecurityAnswer>
    {
        Task<IEnumerable<SecurityAnswerModel>> GetAllSecurityAnswers();
        Task<SecurityAnswerModel> SaveSecurityAnswer(SecurityAnswerModel request);
        Task<bool> UpdateSecurityAnswer(SecurityAnswerModel request, Guid requestId);
        Task<bool> DeleteSecurityAnswer(Guid requestId);
    }
}

