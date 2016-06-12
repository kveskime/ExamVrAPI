using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CommentFullDTO
    {
        public int CommentId { get; set; }
        public string User { get; set; } = "Anonymous";
        public string Body { get; set; }
        public int BlogId { get; set; }
    }
}
