using Authentication.Application.Abstractions;
using Authentication.Application.Features.Post.Queries;
using MediatR;

namespace Authentication.Application.Features.Post.QueryHandlers;

public class GetAllPostsHandler : IRequestHandler<GetAllPosts,ICollection<Domain.Models.Post>>
{
    private readonly IPostRepository _repository;
    public GetAllPostsHandler(IPostRepository postRepository)
    {
        _repository = postRepository;
    }
    public async Task<ICollection<Domain.Models.Post>> Handle(GetAllPosts request, CancellationToken cancellationToken)
    {
        return await _repository.GetPosts();
    }
}