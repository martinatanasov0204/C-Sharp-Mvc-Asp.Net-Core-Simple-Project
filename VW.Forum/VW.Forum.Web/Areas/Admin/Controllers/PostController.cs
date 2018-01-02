using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VW.Forum.Services;
using VW.Forum.Services.Models;
using VW.Forum.Web.ViewModels.Comment;
using VW.Forum.Web.ViewModels.Post;

namespace VW.Forum.Web.Areas.Admin.Controllers
{
	[Route("admin/post")]
	public class PostController : BaseAdminController
	{
		private readonly UserManager<Entities.User> _userManager;
		private readonly IPostService _postService;
		private readonly ICommentService _commentService;
		private readonly IMapper _mapper;

		public PostController(
			UserManager<Entities.User> userManager,
			IPostService postService,
			ICommentService commentService,
			IMapper mapper)
		{
			_userManager = userManager;
			_postService = postService;
			_commentService = commentService;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> Posts(
			CancellationToken cancellationToken = default(CancellationToken))
		{
			IEnumerable<Post> posts = await _postService.GetPosts();

			var postsVM = _mapper.Map<List<PostsViewModel>>(posts);

			var model = new PostsListViewModel()
			{
				Posts = postsVM
			};

			return View(model);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Post(int id,
			CancellationToken cancellationToken = default(CancellationToken))
		{
			Post post = await _postService.GetPostById(id);
			IEnumerable<Comment> comments = await _commentService.GetComments(id);

			var postsVM = _mapper.Map<PostContentViewModel>(post);
			var commentsVM = _mapper.Map<IEnumerable<CommentViewModel>>(comments);

			var model = new PostViewModel()
			{
				Content = postsVM,
				Comments = commentsVM
			};

			return View(model);
		}

		[HttpGet("createPost")]
		public async Task<IActionResult> CreatePost(
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return View();
		}

		[HttpPost("createPost")]
		public async Task<IActionResult> CreatePostRequest(CreatePostViewModel model,
			CancellationToken cancellationToken = default(CancellationToken))
		{
			model.AuthorId = _userManager.GetUserId(HttpContext.User);

			Post post = _mapper.Map<Post>(model);

			_postService.Add(post);

			return RedirectToAction("Posts", "Post", new {area = "Admin"});
		}

		[HttpGet("deletePost")]
		public async Task<IActionResult> DeletePostRequest(int postId,
			CancellationToken cancellationToken = default(CancellationToken))
		{
			_postService.Delete(postId);

			return RedirectToAction("Posts", "Post", new {area = "Admin"});
		}
	}
}
