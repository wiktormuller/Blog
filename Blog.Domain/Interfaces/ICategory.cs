using Blog.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Domain.Interfaces
{
    public interface ICategory
    {
        Post Get(int id);
        IQueryable<Category> GetAll();
        Task Add(Category category);
        Task Update(Category category);
        Task Remove(int id);
    }
}
