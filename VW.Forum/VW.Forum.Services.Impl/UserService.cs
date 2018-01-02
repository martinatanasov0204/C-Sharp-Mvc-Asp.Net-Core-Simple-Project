using AutoMapper;
using System.Collections.Generic;
using VW.Forum.Data;
using VW.Forum.Services.Models;

namespace VW.Forum.Services.Impl
{
	public class UserService : Service, IUserService
	{
		public UserService(VwForumDbContext context, IMapper mapper) : base(context, mapper)
		{

		}

		public IEnumerable<User> GetUsers()
		{
			IEnumerable<Entities.User> usersDb = Context.Users;

			return Mapper.Map<IEnumerable<User>>(usersDb);
		}

		public User GetUser(string username, string password)
		{
			throw new System.NotImplementedException();
		}

		public User GetUserById(string id)
		{
			Entities.User user = Context.Users.Find(id);

			return Mapper.Map<User>(user);
		}
	}
}
