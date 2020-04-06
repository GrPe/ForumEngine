using System.Diagnostics;
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

        public IActionResult Index(int? id)
        {
            if(User.Identity.IsAuthenticated)
            {
                var response = postRepository.GetListByPage(id ?? 0,5);
                var model = mapper.Map<HomeViewModel>(response);
                model.CurrentPage = id ?? 0;
                model.MaxPage = postRepository.GetMaxPage(5);

                return View(model);
            }

            return View(null);
        }

        public IActionResult AccessError()
        {
            return Redirect("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
        }

        public IActionResult ImageValidationError()
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
