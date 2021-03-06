﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoMapper;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using Blog.Infrastructure.DTO;
using Blog.Web.Models;
using Microsoft.AspNetCore.Authorization;
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
        public IActionResult AllPosts()
        {
            var posts = _postService.GetAll();
            var model = _mapper.Map<IEnumerable<PostDto>>(posts);   //error mapping types when ISS is turned off WHY?
            
            return View("AllPosts", model);
        }

        [HttpGet("[controller]/[action]/{id}")]
        public IActionResult Index(int id)
        {
            var post = _postService.Get(id);
            var model = _mapper.Map<PostDetailsDto>(post);

            return View(model);
        }

        [HttpGet]
        public IActionResult RelatedPosts(int id)
        {
            var posts = _postService.GetRelatedPosts(id);

            var model = _mapper.Map<IEnumerable<RelatedPostDto>>(posts);

            return View("RelatedPosts", model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(CreatePostDto model)
        {
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddPost(CreatePostDto model)
        {
            var post = _mapper.Map<Post>(model);    //is it correct?
            _postService.Add(post);

            return RedirectToAction("Index", "Post");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Remove(int id)
        {
            _postService.Remove(id);

            return RedirectToAction("AllPosts", "Post");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id)
        {
            var post = _postService.Get(id);
            var model = _mapper.Map<UpdatePostDto>(post);
            if(model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult ChangePost(UpdatePostDto updatedPost)
        {
            var model = _mapper.Map<Post>(updatedPost);
            if (model == null)
            {
                return NotFound();
            }
            _postService.Update(model);

            return RedirectToAction("Index", "Post", new { id = model.PostId }); 
        }

        [HttpPost]
        public IActionResult Search(string searchQuery)
        {
            if (string.IsNullOrEmpty(searchQuery))
            {
                return RedirectToAction("AllPosts", "Post");
            }

            var filteredPosts = _postService.GetFilteredPosts(searchQuery);
            if (!filteredPosts.Any())
            {
                return View("AllPosts", null);
            }

            var model = _mapper.Map<IEnumerable<PostDto>>(filteredPosts);

            return View("AllPosts", model);
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