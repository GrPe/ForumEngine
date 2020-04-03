using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ForumEngine.Models;
using ForumEngine.Data;
using AutoMapper;

namespace ForumEngine.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PostRepository postRepository;
        private readonly IMapper mapper;

        public HomeController(ILogger<HomeController> logger, PostRepository postRepository, IMapper mapper)
        {
            _logger = logger;
            this.postRepository = postRepository;
            this.mapper = mapper;
        }

        public IActionResult Index(int? page)
        {
            if(User.Identity.IsAuthenticated)
            {
                var response = postRepository.GetListByPage(page ?? 0);
                var model = mapper.Map<HomeViewModel>(response);

                return View(model);
            }

            return View(null);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
