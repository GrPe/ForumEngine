using ForumEngine.Data.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumEngine.Data
{
    public class PostRepository : IRepository<Post, Guid>
    {
        private readonly ApplicationDbContext context;

        public PostRepository(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }

        public async Task<IEnumerable<Post>> GetListByUserId(string id)
        {
            var user = await context.Users.Include(user => user.Posts).Where(u => u.Id == id).FirstOrDefaultAsync();

            return user?.Posts;
        }

        public Task<Post> GetByIdAsync(Guid id)
        {
            return context.Posts.Include(p => p.User).Include(p => p.Comments).ThenInclude(c => c.User).Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Post post)
        {
            post.CreatedOn = DateTime.UtcNow;

            await context.Posts.AddAsync(post);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Post post)
        {
            post.ModifiedOn = DateTime.UtcNow;

            context.Posts.Update(post);
            await context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var post = context.Posts.Where(p => p.Id == id).FirstOrDefault();

            context.Posts.Remove(post);
            await context.SaveChangesAsync();
        }

        public async Task AddCommentAsync(Comment comment)
        {
            await context.Comments.AddAsync(comment);
            await context.SaveChangesAsync();
        }
    }
}
