using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VW.Forum.Data;

namespace VW.Forum.Services.Impl
{
	public class AdminUserService : Service, IAdminUserService
	{
		public AdminUserService(VwForumDbContext context, IMapper mapper) : base(context, mapper)
		{
		}

		public async Task<IEnumerable<Entities.User>> AllAsync()
		{
			var users = await Context.Users.ToListAsync();

			return users;
		}
	}
}
