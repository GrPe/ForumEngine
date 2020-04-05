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
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.UserPhotoPath, opt => opt.MapFrom(src => src.User.PhotoPath))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => SplitContent(src.Content)))
                .ForMember(dest => dest.PhotoPath, opt => opt.MapFrom(src => src.PhotoPath))
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id));

            CreateMap<Post, PostSummaryViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.ContentSummary, opt => opt.MapFrom(src => ShrinkContent(src.Content)))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));

            CreateMap<PostCreateViewModel, Post>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content));

            CreateMap<Post, PostViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.UserPhotoPath, opt => opt.MapFrom(src => src.User.PhotoPath))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => SplitContent(src.Content)))
                .ForMember(dest => dest.PhotoPath, opt => opt.MapFrom(src => src.PhotoPath))
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments.OrderBy(c => c.CreatedOn)))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id));

            CreateMap<IEnumerable<Post>, PostListViewModel>()
                .ForMember(dest => dest.Posts, opt => opt.MapFrom(src => src.OrderByDescending(p => p.CreatedOn)));

            CreateMap<Post, PostEditViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ReverseMap();

            CreateMap<IEnumerable<Post>, HomeViewModel>()
                .ForMember(dest => dest.Posts, opt => opt.MapFrom(src => src));

            CreateMap<ForumUser, UserViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Bio, opt => opt.MapFrom(src => src.Bio))
                .ForMember(dest => dest.PhotoPath, opt => opt.MapFrom(src => src.PhotoPath));

            CreateMap<ForumUser, UserUpdateViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Bio, opt => opt.MapFrom(src => src.Bio));
        }

        private List<string> SplitContent(string content)
        {
            return content.Split("\n").ToList();
        }

        private string ShrinkContent(string content)
        {
            var shrinkContent = content[0..Math.Min(100, content.Length)];
            if (content.Length > 100)
            {
                shrinkContent += "...";
            }
            return shrinkContent;
        }
    }
}
