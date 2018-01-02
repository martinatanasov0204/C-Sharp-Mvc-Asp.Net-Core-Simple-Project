using System;
using System.ComponentModel.DataAnnotations;

namespace VW.Forum.Entities
{
	public class Comment
	{
		public int Id { get; set; }

		[Required]
		public DateTime DateCreated { get; set; }

		[Required]
		[MinLength(1)]
		public string Content { get; set; }

		[Required]
		public string AuthorId { get; set; }

		[Required]
		public int PostId { get; set; }

		#region Navigation properties

		public Post Post { get; set; }

		public User Author { get; set; }

		#endregion
	}
}
