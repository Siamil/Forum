using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace forum.Domain.Entities
{
    public class Messege
    {
        public Messege()
        {
        }

        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Enter Subject")]
        public string Subject { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        [Required(ErrorMessage = "Enter Messege")]
        public string Text { get; set; }
    }
}
