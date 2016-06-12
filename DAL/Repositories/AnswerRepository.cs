using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain.PK;

namespace DAL.Repositories
{
    public class AnswerRepository : EFRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
