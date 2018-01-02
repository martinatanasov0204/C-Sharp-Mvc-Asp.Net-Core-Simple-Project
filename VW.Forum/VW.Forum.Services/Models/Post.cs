using System;

namespace VW.Forum.Services.Models
{
	public class Post
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Content { get; set; }

		public DateTime DateCreated { get; set; }

		public string AuthorId { get; set; }

		public User Author { get; set; }
	}
}
