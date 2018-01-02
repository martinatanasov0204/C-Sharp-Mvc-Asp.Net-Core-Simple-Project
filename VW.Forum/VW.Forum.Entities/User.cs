using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace VW.Forum.Entities
{
	public class User : IdentityUser
	{
		public IEnumerable<Comment> Comments { get; set; } = new HashSet<Comment>();

		public IEnumerable<Post> Posts { get; set; } = new HashSet<Post>();
	}
}
