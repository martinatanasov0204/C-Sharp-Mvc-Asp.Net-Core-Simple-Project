using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VW.Forum.Data;
using VW.Forum.Services.Models;

namespace VW.Forum.Services.Impl
{
	public class CommentService : Service, ICommentService
	{
		public CommentService(VwForumDbContext context, IMapper mapper) : base(context, mapper)
		{
		}

		public async Task<IEnumerable<Comment>> GetComments(int postId)
		{
			var postComments = await Context
				.Comments
				.Include(c => c.Author)
				.Include(c => c.Post)
				.OrderByDescending(p => p.DateCreated)
				.Where(c => c.PostId == postId)
				.ToListAsync();

			var posts = Mapper.Map<IEnumerable<Comment>>(postComments);

			return posts;
		}

		public async void Add(Comment comment)
		{
			Entities.Comment commentDb = Mapper.Map<Entities.Comment>(comment);

			await Context.Comments.AddAsync(commentDb);
			Context.SaveChanges();
		}
	}
}
