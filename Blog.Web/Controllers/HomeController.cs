using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Web.Models;
using Blog.Domain.Interfaces;
using AutoMapper;
using Blog.Infrastructure.DTO;
using Blog.Domain.Entities;

namespace Blog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPost _postService;
        private readonly IMapper _mapper;

        public HomeController(IPost postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var posts = _postService.GetAll();
            var model = _mapper.Map<IEnumerable<PostDto>>(posts);
            
            return View(model);
        }

        public IActionResult Privacy()  //DO NOT FORGET TO IMPLEMENT
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
