using Application;
using Application.IServices;
using DataAccess.Services;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MinimalAPI.Controllers
{
    public static class PostController
    {
        public static void MapPostController(this WebApplication app)
        {
            app.MapPost("/post", AddPost);
            app.MapDelete("/api/post/{id}", DeletePost);
            app.MapGet("/api/post/{id}", GetPost);
            app.MapGet("/api/posts", GetPosts);
            app.MapPut("/api/post", UpdatePost);
            app.MapPost("/AddValidatedPost", AddValidatedPost);
            app.MapPost("/test", Test);
        }
        public static async Task<string> Test([FromBody] string test, [FromServices] IPy testPy) => (await testPy.GenerateResponseAsync(test));

        public static async Task<IResult> AddValidatedPost([FromBody] Post post, [FromServices] IPostServices postServices) => Results.Ok(await postServices.AddValidatedPost(post));


        public static async Task<IResult> AddPost([FromBody] AddPostDto post, [FromServices] IPostServices postServices) => Results.Ok(await postServices.AddPost(post));

        public static async Task<IResult> DeletePost([FromRoute] int id, [FromServices] IPostServices postServices) => Results.Ok(await postServices.DeletePost(id));

        public static async Task<IResult> GetPost([FromRoute] int id, [FromServices] IPostServices postServices) => Results.Ok(await postServices.GetPost(id));

        public static async Task<IResult> GetPosts([FromServices] IPostServices postServices) => Results.Ok(await postServices.GetPosts());

        public static async Task<IResult> UpdatePost([FromBody] Post post, [FromServices] IPostServices postServices) => Results.Ok(await postServices.UpdatePost(post));
    }
}
