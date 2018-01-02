using System.Collections.Generic;
using System.Threading.Tasks;
using VW.Forum.Services.Models;

namespace VW.Forum.Services
{
	public interface IPostService
	{
		Task<IEnumerable<Post>> GetPosts();

		Task<Post> GetPostById(int postId);

		void Add(Post post);

		void Delete(int postId);
	}
}
