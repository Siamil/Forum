using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace forum.Domain.Entities
{
    public class Thread
    {
        [Required(ErrorMessage ="Enter thread name")]
        public string ThreadName { get; set; }
        [Key]
        public int IdThread { get; set; }
        public int IdSection { get; set; }
        public string Description { get; set; }        
        List <Post> ThreadPosts { get; set; }
        public string UserName { get; set; }
        public void AddPost (Post post)
        {
            ThreadPosts.Add(post);
        }
    }
}
