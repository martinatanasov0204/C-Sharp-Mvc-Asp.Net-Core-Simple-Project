using System;

namespace VW.Forum.Web.ViewModels.Post
{
	public class CreatePostViewModel
	{
		public string AuthorId { get; set; }

		public string Title { get; set; }

		public string Content { get; set; }

		public DateTime DateCreated { get; set; } = DateTime.Now;
	}
}
