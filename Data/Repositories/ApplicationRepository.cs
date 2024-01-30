using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ApplicationRepository : Repository<Application>, IApplicationRepository
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ApplicationRepository(RecruitmentWebContext context, IUnitOfWork uow, IMapper mapper)
            : base(context)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<bool> DeleteApplication(Guid applicationId)
        {
            var application = GetById(applicationId);
            if (application == null)
                throw new ArgumentNullException(nameof(application));
            //Entities.Remove(department);
            application.IsDeleted = true;
            Entities.Update(application);

            _uow.SaveChanges();
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<Application>> GetAllApplications()
        {
            var listData = new List<Application>();

            var data = await Entities.Include(a => a.Position)
                                     .Include(a => a.Cv)
                                     .ToListAsync();
            foreach (var item in data)
            {
                var obj = _mapper.Map<Application>(item);
                listData.Add(obj);
            }
            return listData;
        }

        public async Task<Application> SaveApplication(Application request)
        {
            try
            {
                var application = _mapper.Map<Application>(request);
                application.ApplicationId = Guid.NewGuid();

                //application.PositionId = request.Position.PositionId;
                Entities.Add(application);
                _uow.SaveChanges();

                var response = _mapper.Map<Application>(application);
                return await Task.FromResult(response);
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
                var application = _mapper.Map<Application>(request);
                application.ApplicationId = requestId;

                //application.PositionId = request.Position.PositionId;
                //application.Cvid = request.Cv.Cvid;

                Entities.Update(application);
                _uow.SaveChanges();

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                return await Task.FromResult(false);
            }
        }

        public async Task<IEnumerable<Application>> GetApplicationHistory(
            Guid Cvid
        )
        {
            var data = await Entities
                .Where(entity => entity.Cvid == Cvid)
                .Include(entity => entity.Position)
                .OrderByDescending(entity => entity.DateTime)
                .Select(
                    entity =>
                        new Application
                        {
                            ApplicationId = entity.ApplicationId,
                            Position = entity.Position.PositionName,
                            Cvid = entity.Cvid,
                            PositionId = entity.PositionId,
                            DateTime = entity.DateTime,
                            Candidate_status = entity.Company_Status,
                            Priority = entity.Priority,
                        }
                )
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
                var obj = _mapper.Map<Application>(data);
                return obj;
            }

            return null;
        }

        public async Task<IEnumerable<Application>> GetApplicationsWithStatus(
            string status,
            string priority
        )
        {
            var listData = new List<Application>();

            var data = await Entities
                .Where(a => a.Company_Status.Contains(status) && a.Priority.Contains(priority))
                .ToListAsync();
            foreach (var item in data)
            {
                var obj = _mapper.Map<Application>(item);
                listData.Add(obj);
            }
            return listData;
        }

        public async Task<IEnumerable<Application>> ApplicationReport(DateTime fromDate, DateTime toDate)
        {
            var data = await Entities
                .AsNoTracking()
                .Where(x => fromDate <= x.DateTime && x.DateTime <= toDate)
                .Include(x => x.Cv).ThenInclude(x => x.Candidate).ThenInclude(x => x.User)
                .Include(x => x.Position).ThenInclude(x => x.Department)
                .Include(x => x.Position).ThenInclude(x => x.Language)
                .ToListAsync();

            return data;
        }
    }
}