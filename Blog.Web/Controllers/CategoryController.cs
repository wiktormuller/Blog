using System.Collections.Generic;
using AutoMapper;
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
    }
}