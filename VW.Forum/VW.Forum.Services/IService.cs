using VW.Forum.Data;

namespace VW.Forum.Services
{
	public interface IService
	{
		VwForumDbContext Context { get; }
	}
}
