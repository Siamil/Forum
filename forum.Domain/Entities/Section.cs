using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace forum.Domain.Entities
{
    public class Section
    {
        [Key]
        public int IdSection { get; set; }
        [Required(ErrorMessage = "Enter Name")]
        public string SectionName { get; set; }
        public int OverSectionId { get; set; }
    }
}
