using AutoMapper;
using VW.Forum.Services.Models;

namespace VW.Forum.Web.MapperProfiles
{
	public class UserMapperProfile : Profile
	{
		public UserMapperProfile()
		{
			CreateMap<Entities.User, AdminUserListingServiceModel>()
				.ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
				.ForMember(x => x.Username, y => y.MapFrom(z => z.UserName));
		}
	}
}
