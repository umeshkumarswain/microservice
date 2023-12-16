using Authentication.Application.Abstractions;
using Authentication.Application.Features.Post.Commands;
using MediatR;

namespace Authentication.Application.Features.Post.CommandHandlers
{
    public class CreatePostHandler : IRequestHandler<CreatePost,Domain.Models.Post>
    {
        private readonly IPostRepository _repository;
        public CreatePostHandler(IPostRepository postRepository)
        {
            _repository = postRepository;
        }
        public async Task<Domain.Models.Post> Handle(CreatePost request, CancellationToken cancellationToken)
        {
            var post = new Domain.Models.Post()
            {
                Content = request.PostContent
            };
            return await _repository.CreatePost(post);
        }
    }
}