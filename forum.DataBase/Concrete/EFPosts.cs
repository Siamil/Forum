using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using forum.Domain.Entities;

namespace forum.DataBase.Concrete
{
    public class EFPosts
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Post> Posts
        {
            get { return context.Posts; }
        }
        public void SavePost(Post post)
        {
            if (post.IdPost == 0) {
               
                context.Posts.Add(post);
            }
            else
            {
                Post dbEntry = context.Posts.Find(post.IdPost);
                if (dbEntry != null)
                {

                    dbEntry.Description = post.Description;
                     
                }
            }
            context.SaveChanges();
        }
        public void DeletePost(int postId)
        {
            Post dbEntry = context.Posts.Find(postId);
                if(dbEntry != null)
            {
                context.Posts.Remove(dbEntry);
                context.SaveChanges();
            }
        }
    }
}
