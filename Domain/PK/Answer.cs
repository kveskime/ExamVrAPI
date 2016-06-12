using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.PK
{
    public class Answer
    {
        public int AnswerId { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastUsed { get; set; }
        #region Foreign

        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        #endregion
    }
}