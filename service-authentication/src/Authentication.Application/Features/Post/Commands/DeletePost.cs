using MediatR;

namespace Authentication.Application.Features.Post.Commands
{
    public class DeletePost : IRequest
    {
        public int PostId { get; set; }
    }
}