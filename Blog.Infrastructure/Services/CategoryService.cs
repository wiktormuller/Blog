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

        public Category Get(int id)
        {
            var category = _context.Categories.Where(p => p.CategoryId == id).First();
            return category;
        }

        public IQueryable<Category> GetAll()
        {
            var categories = _context.Categories;
            return categories;
        }

        public void Remove(int id)
        {
            var category = Get(id);
            //category.IsActive = false;
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }
    }
}
