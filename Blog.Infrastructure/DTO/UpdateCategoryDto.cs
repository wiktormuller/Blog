using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Infrastructure.DTO
{
    public class UpdateCategoryDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
