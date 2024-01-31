using Service.Models;

namespace Service.Interfaces
{
    public interface ISecurityQuestionService
    {
        Task<IEnumerable<SecurityQuestionModel>> GetAllSecurityQuestion();
        Task<SecurityQuestionModel> SaveSecurityQuestion(SecurityQuestionModel request);
        Task<bool> UpdateSecurityQuestion(SecurityQuestionModel request, Guid requestId);
        Task<bool> DeleteSecurityQuestion(Guid requestId);
    }
}
