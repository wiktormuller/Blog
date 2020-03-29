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
            CreateMap<CreatePostDto, Post>();   //is it correct in post method?
            CreateMap<CreateCategoryDto, Category>();   //is it correct in post method?
            CreateMap<Post, UpdatePostDto>();
            CreateMap<UpdatePostDto, Post>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category, UpdateCategoryDto>();
            CreateMap<PostCategory, RelatedPostDto>();
        }
    }
}
