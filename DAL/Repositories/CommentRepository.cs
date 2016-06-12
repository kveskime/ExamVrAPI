using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class CommentRepository : EFRepository<Comment>, ICommentRepository
    {
        public CommentRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
