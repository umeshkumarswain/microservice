using Authentication.Application.Features.Post.Commands;
using Authentication.Application.Features.Post.Queries;
using Authentication.Domain.Models;
using MediatR;
using Service.Authentication.Abstractions;

namespace Service.Authentication.EndPointDefinations;


    public class PostEndPointDefinations : IEndPointDefinations
    {
        public void RegisterEndPoints(WebApplication app)
        {
            var baseRoute = app.MapGroup("/api/posts");
            baseRoute
                .MapGet(
                    "/{id}",
                    async (IMediator mediator, int Id) =>
                    {
                        var post = new GetPostById() { PostId = Id };
                        var result = await mediator.Send(post);
                        return Results.Ok(result);
                    }
                )
                .WithName("GetPostById");

            baseRoute.MapPost(
                "/",
                async (IMediator mediator, Post post) =>
                {
                    var createPost = new CreatePost() { PostContent = post.Content };
                    var createdPost = await mediator.Send(createPost);
                    return Results.CreatedAtRoute(
                        "GetPostById",
                        new { createdPost.Id },
                        createdPost
                    );
                }
            );

            baseRoute.MapGet(
                "/",
                async (IMediator mediator) =>
                {
                    var getCommand = new GetAllPosts();
                    var posts = await mediator.Send(getCommand);
                    return Results.Ok(posts);
                }
            );

            baseRoute.MapPut(
                "/{id}",
                async (IMediator mediator, Post post, int id) =>
                {
                    var updatePost = new UpdatePost { PostContent = post.Content, PostId = id };
                    var updatedPost = await mediator.Send(updatePost);
                    return Results.Ok(updatedPost);
                }
            );

            baseRoute.MapDelete(
                "/{id}",
                async (IMediator mediator, int id) =>
                {
                    var deletePost = new DeletePost { PostId = id };
                    await mediator.Send(deletePost);
                    return Results.NoContent();
                }
            );
        }

      
    }