﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using VW.Forum.Services;
using VW.Forum.Services.Models;
using VW.Forum.Web.ViewModels.Comment;

namespace VW.Forum.Web.Areas.Admin.Controllers
{
	[Route("admin/comment")]
	public class CommentController : BaseAdminController
	{
		private readonly UserManager<Entities.User> _userManager;
		private readonly ICommentService _commentService;
		private readonly IMapper _mapper;

		public CommentController(
			UserManager<Entities.User> userManager,
			IPostService postService,
			ICommentService commentService,
			IMapper mapper)
		{
			_userManager = userManager;
			_commentService = commentService;
			_mapper = mapper;
		}

		[HttpPost("{postId}")]
		public async Task<IActionResult> Post(int postId, CreateCommentViewModel model,
			CancellationToken cancellationToken = default(CancellationToken))
		{
			model.AuthorId = _userManager.GetUserId(HttpContext.User);

			Comment comment = _mapper.Map<Comment>(model);

			_commentService.Add(comment);

			return RedirectToAction("Post", "Post", new { area = "Admin", id = model.PostId });
		}
	}
}
