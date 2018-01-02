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
    }
}
