using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CvRepository : Repository<Cv>, ICvRepository
    {
        private readonly IUnitOfWork _uow;
        private readonly ICandidateRepository _candidateRepository;
        private readonly IUploadFileRepository _uploadFileRepository;

        public CvRepository(RecruitmentWebContext context,
            IUnitOfWork uow,
            ICandidateRepository candidateRepository,
            IUploadFileRepository uploadFileRepository) : base(context)
        {
            _uow = uow;
            _candidateRepository = candidateRepository;
            _uploadFileRepository = uploadFileRepository;
        }

        public async Task<bool> DeleteCv(Guid requestId)
        {
            try
            {
                var cv = GetById(requestId);
                if (cv == null)
                    return await Task.FromResult(false);

                cv.IsDeleted = true;

                Entities.Update(cv);
                var changes = _uow.SaveChanges();

                return await Task.FromResult(changes > 0);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Cv> GetCVById(Guid id)
        {
            var cv = Entities
                .AsNoTracking()
                .Include(c => c.Candidate)
                .Include(c => c.CvHasSkills)
                    .ThenInclude(chk => chk.Skill)
                .Include(c => c.Certificates)
                .Where(c => c.Cvid == id)
                .FirstOrDefaultAsync();

            return (await cv != null) ? (await cv)! : null!;
        }

        public async Task<IEnumerable<Cv>> GetAllCv(string? request)
        {
            try
            {
                var listData = new List<Cv>();
                if (string.IsNullOrEmpty(request))
                {
                    listData = await Entities
                        .Include(c => c.CvHasSkills)
                            .ThenInclude(chk => chk.Skill)
                        .Include(c => c.Certificates)
                        .ToListAsync();
                }
                else
                {
                    listData = await Entities
                        .Where(rp => rp.CvName.Contains(request))
                        .Include(c => c.CvHasSkills)
                            .ThenInclude(chk => chk.Skill)
                        .Include(c => c.Certificates)
                        .ToListAsync();
                }
                return listData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<(bool, Cv)> SaveCv(Cv request)
        {
            try
            {
                request.Cvid = Guid.NewGuid();

                var result = Entities.Add(request);
                _uow.SaveChanges();

                return (await Task.FromResult(true), request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<bool> UpdateCv(Cv request, Guid requestId)
        {
            try
            {
                var cvPdf_old = Entities.AsNoTracking().Where(c => c.Cvid == requestId).FirstOrDefault();

                Entities.Update(request);

                if (cvPdf_old != null && (cvPdf_old.CvPdf!.Trim() != "" || cvPdf_old.CvPdf != null))
                {
                    var del = _uploadFileRepository.DeleteFileAsync(cvPdf_old.CvPdf);
                }

                var changes = _uow.SaveChanges();

                return await Task.FromResult(changes > 0);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Cv>> GetForeignKey(Guid requestId)
        {
            var data = await Entities
                .Where(x => x.CandidateId == requestId && x.IsDeleted == false)
                .Include(c => c.CvHasSkills)
                    .ThenInclude(chk => chk.Skill)
                .Include(c => c.Certificates)
                .ToListAsync();

            return data;
        }

        public async Task<List<Cv>> GetCvsByCandidateId(Guid candidateId)
        {
            var cvList = await Entities
                        .Where(cv => cv.CandidateId == candidateId)
                        .Include(c => c.CvHasSkills)
                            .ThenInclude(chk => chk.Skill)
                        .Include(c => c.Certificates)
                        .ToListAsync();
            return cvList;
        }

        public async Task<IEnumerable<Cv>> GetAllUserCv(string userId)
        {
            var candidate = await _candidateRepository.GetCandidateByUserId(userId);
            var data = await Entities
                .Where(x => x.CandidateId == candidate!.CandidateId)
                .Include(c => c.CvHasSkills)
                    .ThenInclude(chk => chk.Skill)
                .Include(c => c.Certificates)
                .ToListAsync();

            return data;
        }
    }
}