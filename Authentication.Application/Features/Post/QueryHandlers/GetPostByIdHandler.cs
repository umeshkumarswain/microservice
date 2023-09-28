using Authentication.Application.Abstractions;
using Authentication.Application.Features.Post.Queries;
using MediatR;

namespace Authentication.Application.Features.Post.QueryHandlers;

public class GetPostByIdHandler :IRequestHandler<GetPostById,Domain.Models.Post>
{
    private readonly IPostRepository _repository;
    public GetPostByIdHandler(IPostRepository postRepository)
    {
        _repository = postRepository;
    }
    public async Task<Domain.Models.Post> Handle(GetPostById request, CancellationToken cancellationToken)
    {
        return  await _repository.GetPost(request.PostId);
    }
}