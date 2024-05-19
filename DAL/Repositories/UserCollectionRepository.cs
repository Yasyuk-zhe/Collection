using Collections;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class UserCollectionRepository : BaseRepository<UserCollection>
    {
        public UserCollectionRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
