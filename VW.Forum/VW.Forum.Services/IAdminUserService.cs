using System.Collections.Generic;
using System.Threading.Tasks;

namespace VW.Forum.Services
{
	public interface IAdminUserService
	{
		Task<IEnumerable<Entities.User>> AllAsync();
	}
}
