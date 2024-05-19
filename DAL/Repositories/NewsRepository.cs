using Collections;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class NewsRepository : BaseRepository<News>
    {
        public NewsRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
