using System.Collections.Generic;
using AutoMapper;
using Blog.Domain.Interfaces;
using Blog.Infrastructure.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IApplicationUser _applicationUser;
        private readonly IMapper _mapper;

        public ProfileController(IApplicationUser applicationUser, IMapper mapper)
        {
            _applicationUser = applicationUser;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var profiles = _applicationUser.GetAll();
            var model = _mapper.Map<IEnumerable<ProfileDto>>(profiles);

            return View("AllUsers", model);
        }

        public IActionResult Login()    //WHY?
        {
            return View("_LoginPartial");
        }
    }
}