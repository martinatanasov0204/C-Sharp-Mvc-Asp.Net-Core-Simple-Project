using System.Collections.Generic;
using VW.Forum.Services.Models;

namespace VW.Forum.Services
{
	public interface IUserService
	{
		IEnumerable<User> GetUsers();

		User GetUser(string username, string password);

		User GetUserById(string id);
	}
}
