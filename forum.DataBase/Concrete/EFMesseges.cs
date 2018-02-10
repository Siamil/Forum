using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using forum.Domain.Entities;

namespace forum.DataBase.Concrete
{
   public class EFMesseges
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Messege> Messeges
        {
            get { return context.Messeges; }
        }
        public void SaveMessege(Messege Messege)
        {
            if (Messege.ID == 0)
            {

                context.Messeges.Add(Messege);
            }
            context.SaveChanges();
        }
        public void DeleteMessege(int Id)
        {
            Messege dbEntry = context.Messeges.Find(Id);
            if (dbEntry != null)
            {

                context.Messeges.Remove(dbEntry);
                context.SaveChanges();
            }
        }
    }
}
