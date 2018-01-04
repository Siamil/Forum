using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using forum.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace forum.Domain.Entities
{
    public class Post
    {
        [Key]
        public int IdPost { get; set; }
        public int IdThread { get; set; }
        public string Description { get; set; }
       
        public string UserName {get; set;}
        User PostUser { get; set; }
    }
}
