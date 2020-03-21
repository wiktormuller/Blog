using Blog.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Domain.Interfaces
{
    public interface ICategory
    {
        Category Get(int id);
        IQueryable<Category> GetAll();
        void Add(Category category);
        void Update(Category category);
        void Remove(int id);
    }
}
