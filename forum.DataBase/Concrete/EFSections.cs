using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using forum.Domain.Entities;

namespace forum.DataBase.Concrete
{
    public class EFSections
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Section> Sections
        {
            get { return context.Sections; }
        }
        public void SaveSection(Section section)
        {
            if (section.IdSection == 0)
            {

                context.Sections.Add(section);
            }
            context.SaveChanges();
        }
    }
}
