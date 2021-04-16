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

        public IEnumerable<Log> GetAllEventLogs(string sortOrder, int limit)
        {
            IEnumerable<Log> logs;

            if(!string.IsNullOrEmpty(sortOrder) && limit == 0)
            {
                switch(sortOrder)
                {
                    case "desc":
                        logs = Log.OrderByDescending(x => x.Date);
                        break;
                    default:
                        logs = Log.OrderBy(x => x.Date);
                        break;
                }
            }
            else
            {
                switch (sortOrder)
                {
                    case "desc":
                        logs = Log.OrderByDescending(x => x.Date).Take(limit);
                        break;
                    default:
                        logs = Log.OrderBy(x => x.Date).Take(limit);
                        break;
                }
            }

            return logs;
        }
    }
}
