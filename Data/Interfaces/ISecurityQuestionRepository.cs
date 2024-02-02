using Data.Entities;

namespace Data.Interfaces
{
    public interface ISecurityQuestionRepository : IRepository<SecurityQuestion>
    {
        Task<List<SecurityQuestion>> GetSecurityQuestion();

        Task<SecurityQuestion> AddSecurityQuestion(SecurityQuestion request);

        Task<bool> UpdateSecurityQuestion(SecurityQuestion request, Guid requestId);

        Task<bool> RemoveSecurityQuestion(Guid requestId);
    }
}