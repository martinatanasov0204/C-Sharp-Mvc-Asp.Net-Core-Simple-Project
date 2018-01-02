using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VW.Forum.Data;
using VW.Forum.Services.Models;

namespace VW.Forum.Services.Impl
{
	public class PostService : Service, IPostService
	{
		public PostService(VwForumDbContext context, IMapper mapper) : base(context, mapper)
		{
		}

		public async Task<IEnumerable<Post>> GetPosts()
		{
			IEnumerable<Entities.Post> postsDb = await Context.Posts.OrderByDescending(p => p.DateCreated).ToListAsync();

			IEnumerable<Post> posts = Mapper.Map<IEnumerable<Post>>(postsDb);

			return posts;
		}

		public async Task<Post> GetPostById(int postId)
		{
			Entities.Post postDb = 
				await Context.Posts.Include(p => p.Author).FirstOrDefaultAsync(p => p.Id == postId);

			Post post = Mapper.Map<Post>(postDb);

			return post;
		}

		public async void Add(Post post)
		{
			Entities.Post postDb = Mapper.Map<Entities.Post>(post);

			await Context.Posts.AddAsync(postDb);
			Context.SaveChanges();
		}

		public void Delete(int postId)
		{
			Entities.Post postDb = Context.Posts.FirstOrDefault(p => p.Id == postId);

			Context.Posts.Remove(postDb);
			Context.SaveChanges();
		}
	}
}
