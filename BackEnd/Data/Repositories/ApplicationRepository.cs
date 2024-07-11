using Data.CustomModel.Application;
using Data.CustomModel.Position;
using Data.Entities;
using Data.Interfaces;
using Data.Sorting;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ApplicationRepository : Repository<Application>, IApplicationRepository
    {
        private readonly IUnitOfWork _uow;

        public ApplicationRepository(RecruitmentWebContext context, IUnitOfWork uow)
            : base(context)
        {
            _uow = uow;
        }

        public async Task<bool> DeleteApplication(Guid applicationId)
        {
            try
            {
                var application = GetById(applicationId);
                if (application == null)
                    return await Task.FromResult(false);

                application.IsDeleted = true;
                Entities.Update(application);

                _uow.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<IEnumerable<Application>> GetAllApplications()
        {
            var listData = await Entities.Include(a => a.Position)
                                     .Include(a => a.Cv)
                                     .ToListAsync();
            return listData;
        }

        public async Task<IEnumerable<Application>> GetAllApplicationsByPositionId(Guid positionId, ApplicationFilter? applicationFilter, string? sortString)
        {
            var query = Entities.Where(e => e.PositionId == positionId);
            query = query
                .Include(e => e.Interviews)
                .Include(a => a.Cv.Candidate.User)
                .Include(e => e.Cv.CvHasSkills).ThenInclude(e => e.Skill)
                .AsNoTracking()
                ;

            if (!String.IsNullOrEmpty(applicationFilter!.Search))
            {
                query = query.Where(o => 
                (o.Cv.Candidate.User!.FullName!.ToLower().Contains(applicationFilter.Search.ToLower())
                || o.Cv.CvHasSkills.First(o => o.Skill.SkillName!.ToLower().Contains(applicationFilter.Search.ToLower())) != null));

            }
            if (applicationFilter.FromDate.HasValue && applicationFilter.ToDate.HasValue)
            {
                query = query.Where(e => applicationFilter.FromDate.Value <= e.CreatedTime && e.CreatedTime <= applicationFilter.ToDate.Value);
            }
            if (applicationFilter.candidateStatus.HasValue)
            {
                query = query.Where(e => e.Candidate_Status == applicationFilter.candidateStatus.Value);
            }
            if (applicationFilter.companyStatus.HasValue)
            {
                query = query.Where(e => e.Company_Status == applicationFilter.companyStatus.Value);
            }
            if (sortString != null)
            {
                var sort = new Sort<Application>(sortString);
                query = sort.getSort(query);
            }
            var listData = await query.Select(e =>
            new Application
            {
                ApplicationId = e.ApplicationId,
                Cvid = e.Cvid,
                PositionId = e.PositionId,
                CreatedTime = e.CreatedTime,
                Company_Status = e.Company_Status,
                Candidate_Status = e.Candidate_Status,
                Priority = e.Priority,
                IsDeleted = e.IsDeleted,
                Cv = new Cv
                {
                    Cvid = e.Cvid,
                    CvName = e.Cv.CvName,
                    CandidateId = e.Cv.CandidateId,
                    CvPdf = e.Cv.CvPdf,
                    Candidate = new Candidate
                    {
                        CandidateId = e.Cv.CandidateId,
                        CandidateHasSkills = e.Cv.Candidate.CandidateHasSkills,
                        AboutMe = e.Cv.Candidate.AboutMe,
                        User = new WebUser
                        {
                            FullName = e.Cv.Candidate.User!.FullName,
                            Email = e.Cv.Candidate.User.Email,
                            ImageURL = e.Cv.Candidate.User.ImageURL,
                            DateOfBirth = e.Cv.Candidate.User.DateOfBirth,
                        },
                    },
                },
                Interviews = e.Interviews,  
            })
                .ToListAsync();

            return listData;
        }   


        public async Task<Application> SaveApplication(Application request)
        {
            try
            {
                request.ApplicationId = Guid.NewGuid();

                //application.PositionId = request.Position.PositionId;
                Entities.Add(request);
                _uow.SaveChanges();

                return await Task.FromResult(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateApplication(Application request, Guid requestId)
        {
            try
            {
                request.ApplicationId = requestId;

                //application.PositionId = request.Position.PositionId;
                //application.Cvid = request.Cv.Cvid;

                Entities.Update(request);
                _uow.SaveChanges();

                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                //throw new Exception(ex.Message);
                return await Task.FromResult(false);
            }
        }

        public async Task<IEnumerable<Application>> GetApplicationHistory(Guid candidateId)
        {
            var data = await Entities
                .Where(entity => entity.Cv.CandidateId == candidateId)
                .Include(entity => entity.Position).ThenInclude(o => o.Company)
                .Include(entity => entity.Position).ThenInclude(o => o.Level)
                .OrderByDescending(entity => entity.CreatedTime)
                .ToListAsync();
            return data;
        }

        public async Task<Application?> GetApplicationById(Guid ApplicationId)
        {
            var data = await Entities.Include(a => a.Position)
                                     .Include(a => a.Cv)
                                     .Where(a => a.ApplicationId.Equals(ApplicationId))
                                     .AsNoTracking()
                                     .FirstOrDefaultAsync();
            if (data != null)
            {
                return data;
            }

            return null;
        }

        public async Task<IEnumerable<Application>> GetApplicationsWithStatus(
            int status,
            int priority
        )
        {
            var listData = await Entities
                .Where(a => a.Company_Status! == status && a.Priority! == priority)
                .ToListAsync();

            return listData;
        }

        public async Task<IEnumerable<Application>> ApplicationReport(DateTime fromDate, DateTime toDate)
        {
            if (fromDate != DateTime.MinValue && toDate != DateTime.MinValue)
            {
                var data = await Entities
                    .AsNoTracking()
                    .Where(x => fromDate.Date <= x.CreatedTime.Date && x.CreatedTime.Date <= toDate.Date)
                    .Include(x => x.Cv).ThenInclude(x => x.Candidate).ThenInclude(x => x.User)
                    .Include(x => x.Position).ThenInclude(x => x.Company)
                    .Include(x => x.Position).ThenInclude(x => x.Language)
                    .ToListAsync();

                return data;

            }

            var result = await Entities
                .AsNoTracking()
                .Include(x => x.Cv).ThenInclude(x => x.Candidate).ThenInclude(x => x.User)
                .Include(x => x.Position).ThenInclude(x => x.Company)
                .Include(x => x.Position).ThenInclude(x => x.Language)
                .ToListAsync();

            return result;
            }
    }
}