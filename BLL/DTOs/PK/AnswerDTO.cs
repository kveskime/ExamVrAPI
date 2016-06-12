using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.PK
{
    public class AnswerFullDTO
    {
        public int AnswerId { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastUsed { get; set; }
        public int QuestionId { get; set; }
    }
}
