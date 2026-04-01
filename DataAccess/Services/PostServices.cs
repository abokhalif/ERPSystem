using Application.IServices;
using AutoMapper;
using DataAccess;
using Domain.DTOs;
using Domain.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public class PostServices:IPostServices
    {
        private readonly Context _context;
        private readonly IMapper mapper;
        private readonly IValidator<Post> validator;

        public PostServices(Context context,IMapper mapper,IValidator<Post> validator)
        {
            _context = context;
            this.mapper = mapper;
            this.validator = validator;
        }
        public async Task<ResponseResult> AddPost(AddPostDto post)
        {
            if (post != null)
            {
                try
                {
                    var Mpost = mapper.Map<Post>(post);
                    _context.Posts.Add(Mpost);
                    _context.SaveChanges();
                    return await Task.FromResult(new ResponseResult { IsSuccess = true, Message = "Post added successfully", Obj = post });
                }
                catch (Exception ex)
                {
                    return await Task.FromResult(new ResponseResult { IsSuccess = false, Message = ex.Message });
                }
            }
            return await Task.FromResult(new ResponseResult { IsSuccess = false, Message = "Post cannot be null" });

        }
        public async Task<ResponseResult> AddValidatedPost(Post post)
        {
            ValidationResult result = await validator.ValidateAsync(post);
            if(!result.IsValid)
            {
                return new ResponseResult { IsSuccess = false, Obj = result.Errors.Select(x=>x.ErrorMessage)};
                  
            }
            _context.Posts.Add(post);
            _context.SaveChanges();
            return new ResponseResult { IsSuccess = true, Message = "Done", Obj = post };
        }

        public async Task<ResponseResult> DeletePost(int id)
        {
            var post = _context.Posts.Find(id);
            if (post != null)
            {
                try
                {
                    _context.Posts.Remove(post);
                    _context.SaveChanges();
                    return await Task.FromResult(new ResponseResult { IsSuccess = true, Message = "Post deleted successfully" });
                }
                catch (Exception ex)
                {
                    return  await Task.FromResult(new ResponseResult { IsSuccess = false, Message = ex.Message });
                }
            }
            return await Task.FromResult(new ResponseResult { IsSuccess = false, Message = "Post not found" });
        }
        public async Task<ResponseResult> GetPost(int id)
        {

            var post = _context.Posts.Find(id);
            if (post != null)
            {
                return await Task.FromResult(new ResponseResult { IsSuccess = true, Message = "Post found", Obj = post });
            }
            return await Task.FromResult(new ResponseResult { IsSuccess = false, Message = "Post not found" });
        }

        public async Task<ResponseResult> GetPosts()
        {
            var posts = _context.Posts.ToList();
            if (posts.Count > 0 && posts != null )
            {
                
                return await Task.FromResult(new ResponseResult { IsSuccess = true, Message = "Post found", Obj = posts });
            }
            return new ResponseResult  { IsSuccess = false, Message = "No post found" };
        }

        public async Task<ResponseResult> UpdatePost(Post post)
        {
            if (post != null)
            {
                try
                {
                    _context.Posts.Update(post);
                    _context.SaveChanges();
                    return await Task.FromResult(new ResponseResult { IsSuccess = true, Message = "Post updated successfully", Obj = post });
                }
                catch (Exception ex)
                {
                    return await Task.FromResult(new ResponseResult { IsSuccess = false, Message = ex.Message });
                }
            }
            return await Task.FromResult(new ResponseResult { IsSuccess = false, Message = "Post cannot be null" });
        }
    }
}
