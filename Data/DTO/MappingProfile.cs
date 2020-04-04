using AutoMapper;
using ForumEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ForumEngine.Data.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Comment, CommentViewModel>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(scr => scr.User.UserName))
                .ForMember(dest => dest.UserPhotoPath, opt => opt.MapFrom(scr => scr.User.PhotoPath))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(scr => SplitContent(scr.Content)))
                .ForMember(dest => dest.PhotoPath, opt => opt.MapFrom(scr => scr.PhotoPath))
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(scr => scr.CreatedOn))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(scr => scr.User.Id));

            CreateMap<Post, PostSummaryViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(scr => scr.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(scr => scr.Title))
                .ForMember(dest => dest.ContentSummary, opt => opt.MapFrom(scr => ShrinkContent(scr.Content)))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(scr => scr.User.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(scr => scr.User.UserName));

            CreateMap<PostCreateViewModel, Post>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(scr => scr.Title))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(scr => scr.Content));

            CreateMap<Post, PostViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(scr => scr.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(scr => scr.User.UserName))
                .ForMember(dest => dest.UserPhotoPath, opt => opt.MapFrom(scr => scr.User.PhotoPath))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(scr => SplitContent(scr.Content)))
                .ForMember(dest => dest.PhotoPath, opt => opt.MapFrom(scr => scr.PhotoPath))
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(scr => scr.CreatedOn))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(scr => scr.Comments.OrderBy(c => c.CreatedOn)))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id));

            CreateMap<IEnumerable<Post>, PostListViewModel>()
                .ForMember(dest => dest.Posts, opt => opt.MapFrom(scr => scr.OrderByDescending(p => p.CreatedOn)));

            CreateMap<Post, PostEditViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(scr => scr.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(scr => scr.Title))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(scr => scr.Content))
                .ReverseMap();

            CreateMap<IEnumerable<Post>, HomeViewModel>()
                .ForMember(dest => dest.Posts, opt => opt.MapFrom(scr => scr));
        }

        private List<string> SplitContent(string content)
        {
            return content.Split("\n").ToList();
        }

        private string ShrinkContent(string content)
        {
            var shrinkContent = content[0..Math.Min(100, content.Length)];
            if(content.Length > 100)
            {
                shrinkContent += "...";
            }
            return shrinkContent;
        }
    }
}
