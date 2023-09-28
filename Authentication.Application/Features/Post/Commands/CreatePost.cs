using MediatR;

namespace Authentication.Application.Features.Post.Commands;

public class CreatePost :IRequest<Domain.Models.Post>
{
    public string? PostContent { get; set; }
}