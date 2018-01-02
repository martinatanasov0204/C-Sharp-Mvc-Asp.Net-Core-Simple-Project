using System;

namespace VW.Forum.Services.Models
{
	public class Comment
	{
		public int Id { get; set; }

		public DateTime DateCreated { get; set; }

		public string Content { get; set; }

		public string AuthorId { get; set; }

		public User Author { get; set; }

		public int PostId { get; set; }

		public Post Post { get; set; }
	}
}
