using Authentication.Domain.Models;

namespace Authentication.Application.Abstractions;

public interface IPostRepository
{
    Task<ICollection<Post>> GetPosts();
    Task<Post> GetPost(int postId);
    Task<Post> CreatePost(Post toCreate);
    Task<Post> UpdatePost(string updateContent, int postId);
    Task DeletePost(int postId); 
}