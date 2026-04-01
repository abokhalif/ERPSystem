using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.IServices
{
    public interface IPostServices
    {
        Task<ResponseResult> AddPost(AddPostDto post);
        Task<ResponseResult> DeletePost(int id);
        Task<ResponseResult> GetPost(int id);
        Task<ResponseResult>GetPosts();
        Task<ResponseResult> UpdatePost(Post post);
        Task<ResponseResult> AddValidatedPost(Post post);

    }
}
