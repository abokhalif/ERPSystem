using AutoMapper;
using Domain.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<AddPostDto, Post>().ForMember(d => d.Content, s => s.MapFrom(s => s.Content)).ReverseMap();
                
                        
        }
    }
}
