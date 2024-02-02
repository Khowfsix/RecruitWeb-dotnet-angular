using Data.Entities;

namespace Data.Interfaces
{
    public interface ISecurityAnswerRepository : IRepository<SecurityAnswer>
    {
        Task<IEnumerable<SecurityAnswer>> GetAllSecurityAnswers();

        Task<SecurityAnswer> SaveSecurityAnswer(SecurityAnswer request);

        Task<bool> UpdateSecurityAnswer(SecurityAnswer request, Guid requestId);

        Task<bool> DeleteSecurityAnswer(Guid requestId);
    }
}