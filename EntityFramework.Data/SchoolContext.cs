using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext()
            : base("dbConnection")
        {
        }

        public DbSet<School> Schools { get; set; }
        public DbSet<Class> Classes { get; set; }
    }
}
