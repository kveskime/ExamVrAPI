using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs.PK;
using BLL.Factories;
using BLL.Factories.PK;
using DAL.Interfaces;
using DAL.Repositories;

namespace BLL.Services
{
    public class QuestionService
    {

        private readonly AnswerFactory _answerFactory;
        private readonly QuestionFactory _questionFactory;
        private readonly AnswerRepository _answerRepository;
        private readonly QuestionRepository _questionRepository;

        public QuestionService(IDbContext dbContext)
        {
            _answerFactory = new AnswerFactory();
            _questionFactory = new QuestionFactory();


            _answerRepository = new AnswerRepository(dbContext);
            _questionRepository = new QuestionRepository(dbContext);
        }
        #region Questions

        //public List<QuestionFullDTO> AllQuestions()
        //{
        //    return _questionRepository.All.Select(x => this._questionFactory.CreateFullDTO(x)).ToList();
        //}

        public List<QuestionFullDTO> AllQuestions()
        {
            var z = _questionRepository.All.Where(x => x.Deleted == false)
                    .Select(x => this._questionFactory.CreateFullDTO(x))
                    .ToList();
            return z;

        }


        public QuestionFullDTO GetQuestionById(int id)
        {
            var questionBO = this._questionRepository.GetById(id);
            return questionBO == null ? null : this._questionFactory.CreateFullDTO(questionBO);
        }
        public void UpdateQuestion(QuestionFullDTO value)
        {
            this._questionRepository.Update(this._questionFactory.RecreateFullDTO(value));
            this._questionRepository.SaveChanges();
        }
        public void AddQuestion(QuestionFullDTO questionDTO)
        {
            this._questionRepository.Add(this._questionFactory.RecreateFullDTO(questionDTO));
            this._questionRepository.SaveChanges();
        }

        public void DeleteQuestion(QuestionFullDTO questionDTO)
        {
            this._questionRepository.Delete(this._questionFactory.RecreateFullDTO(questionDTO));
            this._questionRepository.SaveChanges();
        }

        public void DeleteQuestionById(int questionId)
        {
            this._questionRepository.Delete(questionId);
            this._questionRepository.SaveChanges();
        }
        //TODO: Question filtering
        public List<QuestionFullDTO> FilterQuestionList(string filter)
        {
            return _questionRepository.All.Where(a => a.Title.ToLower().Contains(filter)).Select(b => _questionFactory.CreateFullDTO(b)).ToList();
        }
        #endregion
        #region Answers

        public List<AnswerFullDTO> AllAnswers()
        {
            return _answerRepository.All.Select(x => this._answerFactory.CreateFullDTO(x)).ToList();
        }
        public AnswerFullDTO GetAnswerById(int id)
        {
            var answerBO = this._answerRepository.GetById(id);
            return answerBO == null ? null : this._answerFactory.CreateFullDTO(answerBO);
        }
        public void UpdateAnswer(AnswerFullDTO AnswerDTO)
        {
            this._answerRepository.Update(this._answerFactory.RecreateFullDTO(AnswerDTO));
            this._answerRepository.SaveChanges();
        }
        public void AddAnswer(AnswerFullDTO AnswerDTO)
        {
            this._answerRepository.Add(this._answerFactory.RecreateFullDTO(AnswerDTO));
            this._answerRepository.SaveChanges();

        }

        public void DeleteAnswer(AnswerFullDTO answer)
        {
            this._answerRepository.Delete(answer);
            this._questionRepository.SaveChanges();
        }
        public void DeleteBlogById(int blogId)
        {
            this._answerRepository.Delete(blogId);
            this._answerRepository.SaveChanges();
        }

        public List<AnswerFullDTO> FilterList(string filter)
        {
            return _answerRepository.All.Where(a => a.Title.ToLower().Contains(filter)).Select(b => _answerFactory.CreateFullDTO(b)).ToList();
        }
        #endregion

        public List<QuestionFullDTO> FilteredByTitleList(string filter)
        {
            return
                _questionRepository.All.Where(a => a.Title.ToLower().Contains(filter.ToLower()))
                    .Select(b => _questionFactory.CreateFullDTO(b))
                    .ToList();
        }

        public List<QuestionFullDTO> FilteredByDescriptionList(string filter)
        {
            return
        _questionRepository.All.Where(a => a.Description.ToLower().Contains(filter.ToLower()))
        .Select(b => _questionFactory.CreateFullDTO(b))
        .ToList();
        }
    }
}
