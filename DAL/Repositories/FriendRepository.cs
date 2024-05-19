using Collections;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class FriendRepository : BaseRepository<Friend>
    {
        public FriendRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
