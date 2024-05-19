using Collections;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class AdminRepository : BaseRepository<Admin>
    {
        public AdminRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
