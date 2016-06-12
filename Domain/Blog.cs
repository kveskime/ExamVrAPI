using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Blog
    {
        public int BlogId { get; set; }
        [MaxLength(100), MinLength(1)]
        public string Title { get; set; }
        [MaxLength(3000), MinLength(1)]
        public string Body { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}
