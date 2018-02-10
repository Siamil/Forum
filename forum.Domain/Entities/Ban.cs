using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
namespace forum.Domain.Entities
{
    public class Ban
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}
