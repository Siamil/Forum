using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using forum.Domain.Entities;
namespace forum.DataBase.Concrete
{
   public class EFOverSections
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<OverSection> OverSections
        {
            get { return context.OverSections; }
        }
        public void SaveSection(OverSection OverSection)
        {
            if (OverSection.OverSectionId == 0)
            {

                context.OverSections.Add(OverSection);
            }
            context.SaveChanges();
        }
        public void DeleteSection(int OverSectionId)
        {
            OverSection dbEntry = context.OverSections.Find(OverSectionId);
            if (dbEntry != null)
            {

                context.OverSections.Remove(dbEntry);
                context.SaveChanges();
            }
        }
    }
}

