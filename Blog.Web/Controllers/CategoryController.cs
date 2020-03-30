using System.Collections.Generic;
using AutoMapper;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using Blog.Infrastructure.DTO;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin")]
        public IActionResult Create(CreateCategoryDto model)
        {
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddCategory(CreateCategoryDto model)
        {
            var category = _mapper.Map<Category>(model);    //is it correct?
            _categoryService.Add(category);

            return RedirectToAction("Index", "Category");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Remove(int id)
        {
            _categoryService.Remove(id);

            return RedirectToAction("Index", "Category");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id)
        {
            var post = _categoryService.Get(id);
            var model = _mapper.Map<UpdateCategoryDto>(post);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult ChangeCategory(UpdateCategoryDto updatedCategory)
        {
            var model = _mapper.Map<Category>(updatedCategory);
            if (model == null)
            {
                return NotFound();
            }
            _categoryService.Update(model);

            return RedirectToAction("Index", "Category");   //new { id = model.CategoryId } direct to post that are connected with that category
        }
    }
}