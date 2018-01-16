using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace forum.Domain.Entities
{
    public class OverSection
    {
        [Key]
        public int OverSectionId { get; set; }
        public string Name { get; set; }
    }
}
