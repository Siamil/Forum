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
        string ThreadName { get; set; }
        [Key]
        public int IdThread { get; set; }
        public int IdSection { get; set; }
        Section section { get; set; }
        List <Post> ThreadPosts { get; set; }
        public void AddPost (Post post)
        {
            ThreadPosts.Add(post);
        }
    }
}
