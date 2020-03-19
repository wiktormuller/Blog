using System.Linq;
using System.Threading.Tasks;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Services
{
    public class CategoryService : ICategory
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
        }

        public Post Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Category> GetAll()
        {
            var categories = _context.Categories;
            return categories;
        }

        public Task Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Category category)
        {
            throw new System.NotImplementedException();
        }
    }
}
