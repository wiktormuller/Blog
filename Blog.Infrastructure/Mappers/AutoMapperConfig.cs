using AutoMapper;
using Blog.Domain.Entities;
using Blog.Infrastructure.DTO;
using System.Collections.Generic;

namespace Blog.Infrastructure.Mappers
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Post, PostDto>();
            CreateMap<Post, PostDetailsDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<ApplicationUser, ProfileDto>();
        }
    }
}
