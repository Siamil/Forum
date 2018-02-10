using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using forum.Domain.Entities;

namespace forum.DataBase.Concrete
{
    public class EFBans
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Ban> Bans
        {
            get { return context.Bans; }
        }
        public void SaveBan(Ban Ban)
        {
            if (Ban.Id == 0)
            {

                context.Bans.Add(Ban);
            }
            context.SaveChanges();
        }
        public void DeleteBan(int Id)
        {
            Ban dbEntry = context.Bans.Find(Id);
            if (dbEntry != null)
            {

                context.Bans.Remove(dbEntry);
                context.SaveChanges();
            }
        }
    }
}
