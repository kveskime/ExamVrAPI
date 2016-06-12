using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs.PK;
using Domain.PK;

namespace BLL.Factories.PK
{
    public class AnswerFactory
    {
        public AnswerFullDTO CreateFullDTO(Answer answer)
        {
            return new AnswerFullDTO()
            {
                AnswerId = answer.AnswerId,
                CreationDate = answer.CreationDate,
                LastUsed = answer.LastUsed,
                QuestionId = answer.QuestionId,
                Title = answer.Title
                
            };
        }

        public Answer RecreateFullDTO(AnswerFullDTO answerFullDTO)
        {
            return new Answer()
            {
                AnswerId = answerFullDTO.AnswerId,
                CreationDate = answerFullDTO.CreationDate,
                LastUsed = answerFullDTO.LastUsed,
                QuestionId = answerFullDTO.QuestionId,
                Title = answerFullDTO.Title,
            };
        }
        
    }
}
