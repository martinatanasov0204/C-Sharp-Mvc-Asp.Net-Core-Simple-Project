using System.Collections.Generic;
using System.Threading.Tasks;
using VW.Forum.Services.Models;

namespace VW.Forum.Services
{
	public interface ICommentService
	{
		Task<IEnumerable<Comment>> GetComments(int postId);

		void Add(Comment comment);
	}
}
