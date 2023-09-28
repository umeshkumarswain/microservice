using MediatR;

namespace Authentication.Application.Features.Post.Queries;

public class GetPostById : IRequest<Domain.Models.Post>
{
    public int PostId { get; set; }
}