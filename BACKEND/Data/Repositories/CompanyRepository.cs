using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly IUnitOfWork _uow;

        public CompanyRepository(RecruitmentWebContext context, IUnitOfWork uow) : base(context)
        {
            _uow = uow;
        }

        public async Task<bool> DeleteCompany(Guid requestId)
        {
            try
            {
                var company = GetById(requestId);
                if (company == null)
                    throw new ArgumentNullException(nameof(company));

                //Entities.Remove(company);
                company.IsDeleted = true;
                Entities.Update(company);

                _uow.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Company>> GetAllCompany(string? request)
        {
            try
            {
                var listData = new List<Company>();
                if (string.IsNullOrEmpty(request))
                {
                    listData = await Entities.ToListAsync();
                }
                else
                {
                    listData = await Entities
                        .Where(rp => rp.CompanyName.Contains(request))
                        .ToListAsync();
                }

                return listData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Company> GetCompanyById(Guid companyId)
        {
            try
            {
                var foundCompany = await Entities.Where(e => e.CompanyId.Equals(companyId)).FirstAsync();
                return foundCompany;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Company> SaveCompany(Company request)
        {
            try
            {
                request.CompanyId = Guid.NewGuid();

                Entities.Add(request);
                _uow.SaveChanges();

                return await Task.FromResult(request);
            }
            catch (Exception)
            {
                return null!;
            }
        }

        public async Task<bool> UpdateCompany(Company request, Guid requestId)
        {
            try
            {
                request.CompanyId = requestId;

                Entities.Update(request);
                _uow.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateStatus(bool isActived, bool isDeleted, Guid requestId)
        {
            try
            {
                var foundCompany = await Entities.Where(e => e.CompanyId.Equals(requestId)).FirstAsync();
                if (foundCompany == null) {
                    return await Task.FromResult(false);
                }
                foundCompany.IsActived = isActived;
                foundCompany.IsDeleted = isDeleted; 

                Entities.Update(foundCompany);
                _uow.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }
    }
}