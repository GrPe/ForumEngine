using System.Threading.Tasks;
using AutoMapper;
using ForumEngine.Data.DTO;
using ForumEngine.Data.Repositories;
using ForumEngine.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ForumEngine.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<ForumUser> userManager;
        private readonly UserRepository userRepository;
        private readonly IMapper mapper;

        public UserController(UserManager<ForumUser> userManager, UserRepository userRepository, IMapper mapper)
        {
            this.userManager = userManager;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Profile(string id)
        {
            var user = userRepository.GetUserById(id);

            var model = mapper.Map<UserViewModel>(user);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var user = await userManager.GetUserAsync(User);

            var model = mapper.Map<UserUpdateViewModel>(user);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserUpdateViewModel model)
        {
            var user = await userManager.GetUserAsync(User);

            //map changes;

            await userRepository.UpdateAsync(user);

            return RedirectToAction("Profile");
        }

    }
}