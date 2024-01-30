using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class QuestionSkillRepository : Repository<QuestionSkill>, IQuestionSkillRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuestionSkillRepository(RecruitmentWebContext context,
            IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<QuestionSkill> AddQuestionSkill(QuestionSkill questionSkill)
        {
            /*------------------------------*/
            // Adds mapped entity to db from given model.
            /*------------------------------*/
            questionSkill.QuestionSkillsId = Guid.NewGuid();

            Entities.Add(questionSkill);
            _unitOfWork.SaveChanges();
            return await Task.FromResult(questionSkill);
        }

        public async Task<List<QuestionSkill>> GetAllQuestionSkills()
        {
            /*------------------------------*/
            // Finds all of questionSkill entities asynchronously in db.
            // Returns a list of found questionSkills in db.
            /*------------------------------*/
            var questionSkillList = await Entities.ToListAsync();
            return questionSkillList;
        }

        public async Task<bool> RemoveQuestionSkill(Guid id)
        {
            //var foundQuestionSkill = GetById(id);

            /*------------------------------*/
            // Finds asynchronously and removes entity with matched id in db.
            var foundQuestionSkill = await Entities.FindAsync(id);
            /*------------------------------*/

            if (foundQuestionSkill is not null)
            {
                Entities.Remove(foundQuestionSkill);
                _unitOfWork.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateQuestionSkill(QuestionSkill questionSkill, Guid id)
        {
            /*------------------------------*/
            // If id is not found in db, return false. Else, update and return true.
            if (await Entities.AnyAsync(l => l.QuestionSkillsId.Equals(id)) is false)
                return await Task.FromResult(false);
            /*------------------------------*/

            questionSkill.QuestionSkillsId = id;

            Entities.Update(questionSkill);
            _unitOfWork.SaveChanges();

            return await Task.FromResult(true);
        }
    }
}