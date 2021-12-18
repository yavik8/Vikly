using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vikly.Models;

namespace Vikly.Context
{
    public class SqlDbContext: DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
       public virtual DbSet<ShortnrModel> Shortnr { get; set; }
       public virtual DbSet<ShareBinModel> ShareBin { get; set; }
    }
}
