using Authentication.Application.Abstractions;
using Authentication.Application.Features.Post.Commands;
using MediatR;

namespace Authentication.Application.Features.Post.CommandHandlers;

public class UpdatePostHandler :IRequestHandler<UpdatePost,Domain.Models.Post>
{
    private readonly IPostRepository _repository;
    public UpdatePostHandler(IPostRepository postRepository)
    {
        _repository = postRepository;
    }
    public  async Task<Domain.Models.Post> Handle(UpdatePost request, CancellationToken cancellationToken)
    {
        return await _repository.UpdatePost(request?.PostContent,request.PostId);
    }
}