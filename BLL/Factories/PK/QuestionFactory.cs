using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs.PK;
using Domain.PK;

namespace BLL.Factories.PK
{
    public class QuestionFactory
    {
        private readonly AnswerFactory _answerFactory;

        public QuestionFactory()
        {
            _answerFactory = new AnswerFactory();
        }

        public QuestionFullDTO CreateFullDTO(Question question)
        {
            var ret  = new QuestionFullDTO()
            {
                QuestionId = question.QuestionId,
                Title = question.Title,
                CreationDate = question.CreationDate,
                Deleted = question.Deleted,
                Description = question.Description,
                Answers = question.Answers.Select(x => _answerFactory.CreateFullDTO(x)).ToList(),
                Public = question.Public,
                UpdateDate = question.UpdateDate
            };
            return ret;
        }

        public Question RecreateFullDTO(QuestionFullDTO questionDTO)
        {
            var c = new Question()
            {
                Answers = questionDTO.Answers.Select(x => _answerFactory.RecreateFullDTO(x)).ToList(),
                CreationDate = questionDTO.CreationDate,
                Deleted = questionDTO.Deleted,
                Description = questionDTO.Description,
                Public = questionDTO.Public,
                QuestionId = questionDTO.QuestionId,
                Title = questionDTO.Title,
                UpdateDate = questionDTO.UpdateDate
            };
            return c;
        }
    }
}
