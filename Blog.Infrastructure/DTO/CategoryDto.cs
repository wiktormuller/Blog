using Blog.Domain.Entities;

namespace Blog.Infrastructure.DTO
{
    public class CategoryDto
    {
        public int CategoryId { get; private set; }
        public string Name { get; private set; }

        public Post Post { get; private set; }
    }
}
