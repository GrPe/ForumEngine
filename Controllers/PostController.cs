using System;
using System.Threading.Tasks;
using AutoMapper;
using ForumEngine.Data;
using ForumEngine.Data.DTO;
using ForumEngine.Data.Images;
using ForumEngine.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ForumEngine.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly PostRepository postRepository;
        private readonly UserManager<ForumUser> userManager;
        private readonly IMapper mapper;
        private readonly IImageStorage imageStorage;

        public PostController(PostRepository repository, UserManager<ForumUser> userManager, IMapper mapper)
        {
            postRepository = repository;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);

            var posts = await postRepository.GetListByUserId(user.Id);

            PostListViewModel model = mapper.Map<PostListViewModel>(posts);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Post(Guid id)
        {
            var post = await postRepository.GetByIdAsync(id);

            PostViewModel model = mapper.Map<PostViewModel>(post);

            return View(model);
        }

        [HttpPost]
        [ActionName("Post")]
        public async Task<IActionResult> AddComment(PostViewModel model)
        {
            var post = await postRepository.GetByIdAsync(model.Id);
            var user = await userManager.GetUserAsync(User);

            var comment = new Comment()
            {
                User = user,
                Post = post,
                Content = model.NewCommentContent,
                CreatedOn = DateTime.UtcNow
            };

            await postRepository.AddCommentAsync(comment);

            return RedirectToAction("Post");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostCreateViewModel model)
        {
            var user = await userManager.GetUserAsync(User);

            var post = mapper.Map<Post>(model);

            //post.PhotoPath = await imageStorage.Save(model.Image);
            post.User = user;

            await postRepository.AddAsync(post);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var post = await postRepository.GetByIdAsync(id);

            var model = mapper.Map<PostEditViewModel>(post);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostEditViewModel model)
        {
            var post = await postRepository.GetByIdAsync(model.Id);
            post.Title = model.Title;
            post.Content = model.Content;
            post.ModifiedOn = DateTime.UtcNow;

            await postRepository.UpdateAsync(post);
            return RedirectToAction("Post", new { id = post.Id });
        }

        [HttpGet]
        public  IActionResult Remove(Guid id)
        {
            return View(id);
        }

        [HttpPost]
        [ActionName("Remove")]
        public async Task<IActionResult> RemoveConfirm(Guid id)
        {
            await postRepository.RemoveAsync(id);
            return RedirectToAction("Index");
        }

    }
}