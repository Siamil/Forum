using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forum.Domain.Entities
{
   public class User
    {
        string UserName { get; set; }
        string Password { get; set; }
        List<Post> UserPosts { get; set; }
        public void AddPost(Post post)
        {
            UserPosts.Add(post);
        }
    }
}
