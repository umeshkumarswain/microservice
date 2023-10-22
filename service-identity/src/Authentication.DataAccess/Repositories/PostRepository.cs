using Authentication.Application.Abstractions;
using Authentication.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Authentication.DataAccess.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly AuthenticationDbContext _context;

        public PostRepository(AuthenticationDbContext dbContext)
        {
            _context = dbContext;
        }
        public  async Task<ICollection<Post>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post> GetPost(int postId)
        {
            return await _context.Posts.FirstOrDefaultAsync((post ) => post.Id == postId);
        }

        public async Task<Post> CreatePost(Post toCreate)
        {
            toCreate.DateCreated = DateTime.Now;
            toCreate.LastModified = DateTime.Now;
            _context.Posts.Add(toCreate);
            await _context.SaveChangesAsync();
            return toCreate;
        }

        public async  Task<Post> UpdatePost(string updateContent, int postId)
        {
            var post = _context.Posts.FirstOrDefault((post) => post.Id == postId);
            post.Content = updateContent;
            post.LastModified = DateTime.Now;
            await _context.SaveChangesAsync();

            return post;
        }

        public async Task DeletePost(int postId)
        {
            var post = _context.Posts.FirstOrDefault((p) => p.Id == postId);
            if (post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }
    }
}