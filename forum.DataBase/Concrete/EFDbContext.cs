using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using forum.Domain.Entities;
using System.Data.Entity;

namespace forum.DataBase.Concrete
{
    class EFDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Thread> Threads { get; set; }
        
    }
}
