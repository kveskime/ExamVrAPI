using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.PK
{
    public class Question
    {
        public int QuestionId { get; set; }
        public bool Deleted { get; set; }
        public bool Public { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }

        public DateTime? UpdateDate { get; set; }
        public DateTime CreationDate { get; set; }
        #region Foreign
        public virtual List<Answer> Answers{ get; set; } 
        #endregion

    }
}
