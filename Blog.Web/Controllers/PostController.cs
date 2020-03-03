using System.Collections.Generic;
using System.Diagnostics;
using AutoMapper;
using Blog.Domain.Interfaces;
using Blog.Infrastructure.DTO;
using Blog.Web.Models;
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

        //[HttpGet("[controller]/[action]")]    //WHY THIS DOES NOT WORK?
        public IActionResult Index()
        {
            var posts = _postService.GetAll();
            var model = _mapper.Map<IEnumerable<PostDto>>(posts);
            
            return View("AllPosts", model);
        }

        [HttpGet("[controller]/[action]/{id}")]
        public IActionResult Index(int id)
        {
            var post = _postService.Get(id);
            var model = _mapper.Map<PostDetailsDto>(post);

            return View(model);
        }

        public IActionResult Privacy()  //DO NOT FORGET TO IMPLEMENT
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });    //FOR WHAT IS IT?
        }
    }
}