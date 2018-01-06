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
        public void SaveThread(Thread thread)
        {
            if (thread.IdThread == 0)
            {

                context.Threads.Add(thread);
            }
            else
            {
                Thread dbEntry = context.Threads.Find(thread.IdThread);
                if (dbEntry != null)
                {

                    dbEntry.ThreadName = thread.ThreadName;
                    dbEntry.IdSection = thread.IdSection;
                    dbEntry.Description = thread.Description;

                }
            }

            context.SaveChanges();
        }
        public void DeleteThread(int threadId)
        {
            Thread dbEntry = context.Threads.Find(threadId);
            if (dbEntry != null)
            {
                context.Threads.Remove(dbEntry);
                
            }
            context.SaveChanges();
        }
    }
}
