using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

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

        public IEnumerable<PostCategory> GetRelatedPosts(int id)    //??????????????????????????????? anonymous projection or zzz project with efcore plus
        {
            var posts = _context.PostCategories
                .Include(p => p.Post)
                .Include(c => c.Category)
                .Where(x => x.CategoryId == id)
                .ToList();

            return posts;
        }

        public IEnumerable<Post> GetFilteredPosts(string searchQuery)
        {
            var query = searchQuery.ToLower();
            var filteredPosts = _context.Posts
                .Include(post => post.Author)
                .Include(post => post.Comments)
                .Include(post => post.PostCategories)
                    .ThenInclude(postCategories => postCategories.Category)
                .Include(post => post.Image)
                .Where(post =>
                    post.Title.ToLower().Contains(query)
                 || post.Content.ToLower().Contains(query))
                .OrderByDescending(post => post.Created);
            return filteredPosts;
        }

        public IEnumerable<Post> GetAll()
        {
            var posts = _context.Posts
                //.Include(post => post.Author)
                //.Include(post => post.Comments)
                //.Include(post => post.PostCategories)
                //    .ThenInclude(postCategories => postCategories.Category)
                //.Include(post => post.Image)
                //.Include(post => post.Categories)
                .OrderByDescending(post => post.Created);

            return posts;
        }

        public void Remove(int id)
        {
            var post = Get(id);
            //post.IsActive = false;
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }

        public void Update(Post post)
        {
            _context.Posts.Update(post);
            _context.SaveChanges();
        }
    }
}
