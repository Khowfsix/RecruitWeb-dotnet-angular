using Data.Entities;

namespace Data.Interfaces
{
    public interface ICvRepository : IRepository<Cv>
    {
        Task<IEnumerable<Cv>> GetAllCv(string? request);

        Task<IEnumerable<Cv>> GetAllUserCv(string userId);

        Task<(bool, Cv)> SaveCv(Cv request);

        Task<bool> UpdateCv(Cv request, Guid requestId);

        Task<bool> DeleteCv(Guid requestId);

        Task<IEnumerable<Cv>> GetForeignKey(Guid requestId);

        Task<List<Cv>> GetCvsByCandidateId(Guid candidateId);

        Task<Cv> GetCVById(Guid id);

        //Task<Cv> GetCVByIdNoTracking(Guid id);

        Task<Cv> GetDefaultCv(Guid candidateId);
    }
}