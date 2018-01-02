using AutoMapper;
using VW.Forum.Services.Models;

namespace VW.Forum.Services.Impl.MapperProfiles
{
	public class ItemMapperProfile : Profile
	{
		public ItemMapperProfile()
		{
			#region Post

			CreateMap<Entities.Post, Post>();

			CreateMap<Post, Entities.Post>();

			#endregion

			#region Comment

			CreateMap<Entities.Comment, Comment>();

			#endregion
		}
	}
}
