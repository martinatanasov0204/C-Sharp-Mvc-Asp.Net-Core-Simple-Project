using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VW.Forum.Data;
using VW.Forum.Services;
using VW.Forum.Services.Impl;
using VW.Forum.Web.MapperProfiles;
using VW.Forum.Web.Services;

namespace VW.Forum.Web
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<VwForumDbContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<ItemMapperProfile>();
			});
			services.AddSingleton<IMapper>(new Mapper(config));

			services.AddIdentity<Entities.User, IdentityRole>()
				.AddEntityFrameworkStores<VwForumDbContext>()
				.AddDefaultTokenProviders();

			services.AddTransient<IEmailSender, EmailSender>();

			services.AddScoped<IPostService, PostService>();
			services.AddScoped<ICommentService, CommentService>();
			services.AddScoped<IAdminUserService, AdminUserService>();

			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, VwForumDbContext context)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseBrowserLink();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseAuthentication();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});

			context.Database.EnsureCreatedAsync().Wait();
			context.Database.MigrateAsync().Wait();
		}
	}
}
