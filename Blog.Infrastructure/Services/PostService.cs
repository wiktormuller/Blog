using System.Linq;
using System.Threading.Tasks;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Services
{
    public class PostService : IPost
    {
        private readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Post post)
        {
            _context.Add(post);
            _context.SaveChanges();
        }

        public Post Get(int id)
        {
            var post = _context.Posts.Where(p => p.PostId == id).First();
            return post;
        }

        public IQueryable<Post> GetAll()
        {
            var posts = _context.Posts
                .Include(post => post.Author)
                .Include(post => post.Comments)
                .Include(post => post.Categories)
                .Include(post => post.Image)
                .OrderByDescending(post => post.Created);

            return posts;
        }

        public Task Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Post post)
        {
            throw new System.NotImplementedException();
        }
    }
}
