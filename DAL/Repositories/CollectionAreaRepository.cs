﻿using Collections;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class CollectionAreaRepository : BaseRepository<CollectionArea>
    {
        public CollectionAreaRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
