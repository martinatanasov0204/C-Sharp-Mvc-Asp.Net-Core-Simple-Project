using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VW.Forum.Entities;

namespace VW.Forum.Data
{
	public class VwForumDbContext : IdentityDbContext<User>
	{
		public VwForumDbContext(DbContextOptions<VwForumDbContext> options) : base(options)
		{
		}

		public DbSet<Comment> Comments { get; set; }

		public DbSet<Post> Posts { get; set; }

		public new DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			// Comment

			builder.Entity<Comment>(entity =>
			{
				entity.HasKey(comment => comment.Id);

				entity
					.HasOne(x => x.Author)
					.WithMany(x => x.Comments)
					.HasForeignKey(x => x.AuthorId)
					.OnDelete(DeleteBehavior.Restrict);
			});

			// Post

			builder.Entity<Post>(entity =>
			{
				entity.HasKey(post => post.Id);

				entity
					.HasOne(x => x.Author)
					.WithMany(x => x.Posts)
					.HasForeignKey(x => x.AuthorId)
					.OnDelete(DeleteBehavior.Restrict);
			});

			// User

			builder.Entity<User>(entity =>
			{
				entity.HasKey(user => user.Id);

				entity
					.HasMany(x => x.Comments)
					.WithOne(x => x.Author)
					.HasForeignKey(x => x.AuthorId)
					.OnDelete(DeleteBehavior.Restrict);

				entity
					.HasMany(x => x.Posts)
					.WithOne(x => x.Author)
					.HasForeignKey(x => x.AuthorId)
					.OnDelete(DeleteBehavior.Restrict);
			});
		}
	}
}
