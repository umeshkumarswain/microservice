using Authentication.Application.Abstractions;
using Authentication.Application.Features.Post.Commands;
using MediatR;

namespace Authentication.Application.Features.Post.CommandHandlers;

public class DeletePostHandler : IRequestHandler<DeletePost>
{
    private readonly IPostRepository _repository;
    public DeletePostHandler(IPostRepository postRepository)
    {
        _repository = postRepository;
    }
    
    public async Task Handle(DeletePost request, CancellationToken cancellationToken)
    {
         await _repository.DeletePost(request.PostId);
    }
}