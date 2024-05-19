using Collections;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class CollectionItemRepository : BaseRepository<CollectionItem>
    {
        public CollectionItemRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
