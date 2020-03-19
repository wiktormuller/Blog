using System.Collections.Generic;
using AutoMapper;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using Blog.Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategory categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categories = _categoryService.GetAll();
            var model = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return View(model);
        }

        [HttpGet]
        public IActionResult Create(CreateCategoryDto model)
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult AddCategory(CreateCategoryDto model)
        {
            var category = _mapper.Map<Category>(model);    //is it correct?
            _categoryService.Add(category);

            return RedirectToAction("Index", "Category");
        }
    }
}