using MediatR;

namespace Authentication.Application.Features.Post.Commands;

public class UpdatePost : IRequest<Domain.Models.Post>
{
    public int PostId { get; set; }
    public string? PostContent { get; set; }
}