using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using forum.Domain.Entities;
using forum.DataBase.Concrete;

namespace Forum.Web.Models
{
    public class SectionViewModel
    {
        public SectionViewModel(int sectionId, EFSections sections, EFThreards threads )
        {
            Name = sections.Sections.FirstOrDefault(x => x.IdSection == sectionId).SectionName;
            this.threads = threads.Threads.Where(x => x.IdSection == sectionId);
            this.sectionId = sectionId;
        }
        public string Name { get; set; }
        public IEnumerable<Thread> threads { get; set; }
        public int sectionId { get; set; }
    }

}