using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuestionRepository(IUnitOfWork unitOfWork,
            RecruitmentWebContext context) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Question> AddQuestion(Question entity)
        {
            //throw new NotImplementedException();

            /*------------------------------*/
            // Adds mapped entity to db from given model.
            /*------------------------------*/
            entity.QuestionId = Guid.NewGuid();

            await Entities.AddAsync(entity);
            _unitOfWork.SaveChanges();
            return await Task.FromResult(entity);
        }

        public async Task<List<Question>> GetAllQuestions()
        {
            /*------------------------------*/
            // Finds all of question entities asynchronously in db.
            // Returns a list of found questions in db.
            /*------------------------------*/
            var questionList = await Entities.Include(q => q.CategoryQuestion).ToListAsync();
            return questionList;
        }

        public async Task<List<Question>> GetListQuestions(Guid id)
        {
            var listData = new List<Question>();
            listData = await Entities.Include(q => q.CategoryQuestion)
            .Where(cq => cq.CategoryQuestionId == id)
            .Select(cq => new Question
            {
                QuestionId = cq.QuestionId,
                QuestionString = cq.QuestionString,
                CategoryQuestionId = cq.CategoryQuestionId
            }).ToListAsync();
            return listData;
        }

        public async Task<Question> GetQuestion(Guid? id)
        {
            /*------------------------------*/
            // Finds the first position entity that has the id asynchronously in db.
            // Returns it with the related entities if found. Otherwise, return null
            /*------------------------------*/

            var foundQuestion = await Entities.Include(q => q.CategoryQuestion).Where(q => q.QuestionId.Equals(id)).FirstOrDefaultAsync();

            // if (foundQuestion is not null)
            // {
            //     var data = _mapper.Map<Question>(foundQuestion);
            //     return data;
            // }
            // return null;

            /*------------------------------*/
            //Returns a Question mapped from foundQuestion if it is in db. Otherwise, return null.
            return foundQuestion;
            /*------------------------------*/
        }

        public async Task<List<Question>> GetQuestionsByName(string keyword)
        {
            // var listData = new List<Question>();
            // listData = await Entities
            // .Where(cq => cq.QuestionString.Contains(keyword))
            // .ToListAsync();

            //var response = new List<Question>();

            // if (listData != null)
            // {
            //     foreach(var item in listData)
            //     {
            //         var obj = _mapper.Map<Question>(item);
            //         response.Add(obj);
            //     }
            // }
            // if (response != null)
            //     return response;
            // else
            //     return null;

            /*------------------------------*/
            // Finds all of position entities that contain name parameter asynchronously in db.
            // Returns a list of it with the related entities if matched.
            var listData = new List<Question>();
            listData = await Entities
                    .Include(q => q.CategoryQuestion)
                    .Where(cq => cq.QuestionString.ToLower().Contains(keyword.ToLower().Trim()))
                    .ToListAsync();
            return listData;
            /*------------------------------*/
        }

        public async Task<bool> RemoveQuestion(Guid id)
        {
            /*------------------------------*/
            // Finds asynchronously and removes entity with matched id in db.
            /*------------------------------*/
            var foundQuestion = await Entities.FindAsync(id);
            if (foundQuestion != null)
            {
                try
                {
                    Entities.Remove(foundQuestion);
                    _unitOfWork.SaveChanges();
                    return await Task.FromResult(true);
                }
                catch (Exception)
                {
                    await Task.FromResult(false);
                }
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> UpdateQuestion(Question entity, Guid id)
        {
            /*------------------------------*/
            // If id is not found in db, return false. Else, update and return true.
            if (await Entities.AnyAsync(l => l.QuestionId.Equals(id)) is false)
                return await Task.FromResult(false);
            
            entity.QuestionId = id;

            Entities.Update(entity);
            _unitOfWork.SaveChanges();
            return await Task.FromResult(true);
        }
    }
}