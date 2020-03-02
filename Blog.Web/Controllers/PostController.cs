using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Domain.Interfaces;
using Blog.Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postService;
        private readonly IMapper _mapper;

        public PostController(IPost postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        public IActionResult Index(int id)
        {
            var post = _postService.Get(id);
            var model = _mapper.Map<PostDetailsDto>(post);

            return View(model);
        }
    }
}