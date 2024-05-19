using Collections;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class MarketplaceListingRepository : BaseRepository<MarketplaceListing>
    {
        public MarketplaceListingRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
