using Blog.Domain.Entities;

namespace Blog.Infrastructure.DTO
{
    public class RelatedPostDto
    {
        public int PostId { get; set; }
        public Post Post { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
