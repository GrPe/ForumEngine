using System.Threading.Tasks;
using AutoMapper;
using ForumEngine.Data.DTO;
using ForumEngine.Data.Images;
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
        private readonly IImageStorage imageStorage;

        public UserController(UserManager<ForumUser> userManager, UserRepository userRepository, IMapper mapper, IImageStorage imageStorage)
        {
            this.userManager = userManager;
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.imageStorage = imageStorage;
        }

        [HttpGet]
        public async Task<IActionResult> Profile(string id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            ForumUser user;
            if(!string.IsNullOrWhiteSpace(id))
            {
                user = userRepository.GetUserById(id);
            }
            else
            {
                user = await userManager.GetUserAsync(User);
            }

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
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            var user = await userManager.GetUserAsync(User);

            user.UserName = model.Name;
            user.Bio = model.Bio;

            if(model.Image != null)
            {
                user.PhotoPath = await imageStorage.SaveAsync(model.Image);
            }

            await userRepository.UpdateAsync(user);

            return RedirectToAction("Profile");
        }

    }
}