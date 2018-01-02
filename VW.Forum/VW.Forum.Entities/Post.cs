using System;
using System.ComponentModel.DataAnnotations;

namespace VW.Forum.Entities
{
	public class Post
	{
		public int Id { get; set; }

		[Required]
		[MinLength(5), MaxLength(100)]
		public string Title { get; set; }

		[Required]
		[MinLength(5)]
		public string Content { get; set; }

		[Required]
		public DateTime DateCreated { get; set; }

		[Required]
		public string AuthorId { get; set; }

		#region Navigation Properties

		public User Author { get; set; }
		
		#endregion
	}
}
