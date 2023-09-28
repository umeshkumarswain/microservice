using MediatR;

namespace Authentication.Application.Features.Post.Queries;

public class GetAllPosts : IRequest<ICollection<Domain.Models.Post>>
{
    
}