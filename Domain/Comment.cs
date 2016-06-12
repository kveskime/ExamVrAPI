using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Comment
    {
        public int CommentId { get; set; }
        [MaxLength(100)]
        public string User { get; set; } = "Anonymous";
        [MaxLength(3000), MinLength(1)]
        public string Body { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
}