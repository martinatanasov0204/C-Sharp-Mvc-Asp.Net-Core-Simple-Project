using System.Collections.Generic;
using VW.Forum.Web.ViewModels.Comment;

namespace VW.Forum.Web.ViewModels.Post
{
	public class PostViewModel
	{
		public PostContentViewModel Content { get; set; }

		public IEnumerable<CommentViewModel> Comments { get; set; }
	}
}
	