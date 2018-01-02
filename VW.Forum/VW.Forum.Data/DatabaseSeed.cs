using System;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using VW.Forum.Entities;

namespace VW.Forum.Data
{
	public static class DatabaseSeed
	{
		public static void EnsureSeeded(this VwForumDbContext context)
		{
			var user1 = context.Users.FirstOrDefault(u => u.Email == "martinatanasov0204@gmail.com");

			Post post = new Post()
			{
				Author = user1,
				Title = "First post title",
				Content = "First post content",
				DateCreated = DateTime.ParseExact("26-11-2017", "dd-MM-yyyy", CultureInfo.InvariantCulture),
			};
			
			Post post2 = new Post()
			{
				Author = context.Users.FirstOrDefault(),
				Title = "Second post title",
				Content = "Second post content",
				DateCreated = DateTime.ParseExact("27-11-2017", "dd-MM-yyyy", CultureInfo.InvariantCulture),
			};
			
			context.Posts.AddRange(post, post2);
			context.SaveChanges();

			Comment comment = new Comment()
			{
				 Author = user1,
				 DateCreated = DateTime.Now,
				 Content = "Comment content",
				 Post = post
			};

			context.Comments.Add(comment);
			context.SaveChanges();
		}
	}
}
