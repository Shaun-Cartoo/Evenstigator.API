using Evenstigator.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Evenstigator.API.DAO
{
    public class ETWContext: DbContext
    {
        public DbSet<Log> Log { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                @"server=localhost;userid=root;pwd=admin;port=3306;database=etw;sslmode=none;");
        }

        public IEnumerable<Log> GetAllEventLogs()
        {
            return Log;
        }
    }
}
