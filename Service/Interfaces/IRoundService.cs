using Service.Models;

namespace Service.Interfaces
{
    public interface IRoundService
    {
        Task<IEnumerable<RoundModel>> GetAllRounds(string? interviewId);

        Task<IEnumerable<RoundModel>> GetRoundsOfInterview(Guid interviewId);

        Task<RoundModel> SaveRound(RoundModel roundModel);

        Task<bool> UpdateRound(RoundModel roundModel, Guid roundId);

        Task<bool> DeleteRound(Guid roundId);
    }
}