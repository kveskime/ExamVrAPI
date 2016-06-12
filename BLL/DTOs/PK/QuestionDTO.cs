using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.PK
{
    public class QuestionFullDTO
    {
        
        public int QuestionId { get; set; }
        public bool Deleted { get; set; }
        public bool Public { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime CreationDate { get; set; }
        #region Foreign

        public List<AnswerFullDTO> Answers { get; set; }
        #endregion
    }
}
