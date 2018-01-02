using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using forum.Domain.Entities;

namespace forum.DataBase.Concrete
{
     public class EFThreards
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Thread> Threads
        {
            get { return context.Threads; }
        }
    }
}
