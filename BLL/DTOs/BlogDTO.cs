using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace BLL.DTOs
{
    public class BlogFullDTO
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public List<CommentFullDTO> Comments { get; set; }
    }
}
