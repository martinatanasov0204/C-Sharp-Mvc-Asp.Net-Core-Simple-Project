using AutoMapper;
using System;
using System.Globalization;
using VW.Forum.Services.Models;
using VW.Forum.Web.ViewModels.Comment;
using VW.Forum.Web.ViewModels.Post;

namespace VW.Forum.Web.MapperProfiles
{
	public class ItemMapperProfile : Profile
	{
		public ItemMapperProfile()
		{
			#region Post

			CreateMap<Post, PostsViewModel>()
				.ForMember(x => x.Title, opt => opt.MapFrom(y => y.Title))
				.ForMember(x => x.Content, opt => opt.MapFrom(y => TextConvertor(y)));

			CreateMap<Post, PostContentViewModel>()
				.ForMember(x => x.PostId, opt => opt.MapFrom(y => y.Id))
				.ForMember(x => x.Title, opt => opt.MapFrom(y => y.Title))
				.ForMember(x => x.Author, opt => opt.MapFrom(y => y.Author.UserName))
				.ForMember(x => x.Content, opt => opt.MapFrom(y => y.Content))
				.ForMember(x => x.DateCreated, opt => opt.MapFrom(y => y.DateCreated.ToString("ddd d MMM", CultureInfo.CreateSpecificCulture("en-US"))));

			CreateMap<CreatePostViewModel, Post>();

			#endregion

			#region Comment

			CreateMap<Comment, CommentViewModel>()
				.ForMember(x => x.Author, opt => opt.MapFrom(y => y.Author.UserName))
				.ForMember(x => x.Content, opt => opt.MapFrom(y => y.Content))
				.ForMember(x => x.DateCreated, opt => opt.MapFrom(y => y.DateCreated.ToString("ddd d MMM hh:mm", CultureInfo.CreateSpecificCulture("en-US"))));

			CreateMap<CreateCommentViewModel, Comment>();

			#endregion
		}

		private static string TextConvertor(Post value)
		{
			string textToConvert = value.Content;

			if (textToConvert.Length > 100)
			{
				string text = textToConvert.Substring(0, 100);
				textToConvert = text.Substring(0, text.LastIndexOf(". ", StringComparison.CurrentCulture) + 1);
			}

			return textToConvert;
		}
	}
}
