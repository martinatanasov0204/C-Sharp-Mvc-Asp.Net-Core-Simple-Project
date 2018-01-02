using System;

namespace VW.Forum.Web.ViewModels.Comment
{
	public class CreateCommentViewModel
	{
		public string AuthorId { get; set; }

		public int PostId { get; set; }

		public string Content { get; set; }

		public DateTime DateCreated { get; } = DateTime.Now;
	}
}
