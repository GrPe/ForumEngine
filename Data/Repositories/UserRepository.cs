using ForumEngine.Data.DTO;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace ForumEngine.Data.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ForumUser> userManager;

        public UserRepository(ApplicationDbContext context, UserManager<ForumUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public ForumUser GetUserById(string id)
        {
            return context.Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public async Task UpdateAsync(ForumUser user)
        {
            await userManager.UpdateAsync(user);
        }
    }
}
