using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CategoryQuestionRepository : Repository<CategoryQuestion>, ICategoryQuestionRepository
    {
        private readonly IUnitOfWork _uow;

        public CategoryQuestionRepository(
            RecruitmentWebContext context,
            IUnitOfWork uow
        )
            : base(context)
        {
            _uow = uow;
        }

        public async Task<bool> DeleteCategoryQuestion(Guid requestId)
        {
            try
            {
                var categoryQuestion = GetById(requestId);
                if (categoryQuestion != null)
                {
                    Entities.Remove(categoryQuestion);
                    _uow.SaveChanges();
                    return await Task.FromResult(true);
                }

                return await Task.FromResult(false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<CategoryQuestion>> GetAllCategoryQuestions()
        {
            var listData = await Entities.ToListAsync();
            return listData;
        }

        public async Task<CategoryQuestion?> GetCategoryQuestionById(Guid id)
        {
            try
            {
                var categoryQuestion = GetById(id);
                return categoryQuestion is not null ? categoryQuestion : null!;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<CategoryQuestion>> GetCategoryQuestionsByName(string keyword)
        {
            try
            {
                var listData = await Entities
                    .Where(
                        cq =>
                            cq.CategoryQuestionName != null
                            && cq.CategoryQuestionName.Contains(keyword)
                    )
                    .Select(
                        cq =>
                            new CategoryQuestion
                            {
                                CategoryQuestionId = cq.CategoryQuestionId,
                                CategoryQuestionName = cq.CategoryQuestionName,
                                Weight = cq.Weight
                            }
                    )
                    .ToListAsync();
                return listData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<CategoryQuestion>> GetCategoryQuestionsByWeight(
            double weight
        )
        {
            try
            {
                var listData = await Entities
                    .Where(cq => cq.Weight == weight)
                    .Select(
                        cq =>
                            new CategoryQuestion
                            {
                                CategoryQuestionId = cq.CategoryQuestionId,
                                CategoryQuestionName = cq.CategoryQuestionName,
                                Weight = cq.Weight
                            }
                    )
                    .ToListAsync();
                return listData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Guid> GetIdCategoryQuestion(string keyword)
        {
            var data = await Entities
                .Where(
                    cq =>
                        cq.CategoryQuestionName != null && cq.CategoryQuestionName.Contains(keyword)
                )
                .Select(
                    cq =>
                        new CategoryQuestion
                        {
                            CategoryQuestionId = cq.CategoryQuestionId,
                            CategoryQuestionName = cq.CategoryQuestionName,
                            Weight = cq.Weight
                        }
                )
                .FirstOrDefaultAsync();
            if (data != null)
                return data.CategoryQuestionId;
            else
                return Guid.Empty;
        }

        public async Task<CategoryQuestion> SaveCategoryQuestion(CategoryQuestion categoryQuestion)
        {
            categoryQuestion.CategoryQuestionId = Guid.NewGuid();

            Entities.Add(categoryQuestion);
            _uow.SaveChanges();

            return await Task.FromResult(categoryQuestion);
        }

        public async Task<bool> UpdateCategoryQuestion(
            CategoryQuestion categoryQuestion,
            Guid categoryQuestionId
        )
        {
            categoryQuestion.CategoryQuestionId = categoryQuestionId;
            Entities.Update(categoryQuestion);
            _uow.SaveChanges();
            return await Task.FromResult(true);
        }
    }
}