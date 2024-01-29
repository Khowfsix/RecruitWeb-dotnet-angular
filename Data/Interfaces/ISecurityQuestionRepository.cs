using Data.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ISecurityQuestionRepository : IRepository<SecurityQuestion>
    {
        Task<List<SecurityQuestionModel>> GetSecurityQuestion();

        Task<SecurityQuestionModel> AddSecurityQuestion(SecurityQuestionModel request);

        Task<bool> UpdateSecurityQuestion(SecurityQuestionModel request, Guid requestId);

        Task<bool> RemoveSecurityQuestion(Guid requestId);
    }
}
