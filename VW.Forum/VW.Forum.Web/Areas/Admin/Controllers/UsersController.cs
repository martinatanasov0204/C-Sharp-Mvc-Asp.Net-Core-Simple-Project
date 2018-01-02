using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VW.Forum.Services;
using VW.Forum.Services.Models;
using VW.Forum.Web.Areas.Admin.Models.Users;
using User = VW.Forum.Entities.User;

namespace VW.Forum.Web.Areas.Admin.Controllers
{
	[Route("admin/users")]
	public class UsersController : BaseAdminController
	{
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly UserManager<User> _userManager;
		private readonly IAdminUserService _users;
		private readonly IMapper _mapper;

		public UsersController(
			UserManager<User> userManager,
			RoleManager<IdentityRole> roleManager,
			IAdminUserService users,
			IMapper mapper)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_users = users;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var users = await _users.AllAsync();

			var userModels = new List<User>();

			foreach (var user in users)
			{
				if (!await _userManager.IsInRoleAsync(user, "Administrator"))
				{
					userModels.Add(user);
				}
			}

			var roles = await _roleManager
				.Roles
				.Select(r => new SelectListItem
				{
					Text = r.Name,
					Value = r.Name
				})
				.ToListAsync();

			var usersVm = _mapper.Map<IEnumerable<AdminUserListingServiceModel>>(userModels);

			return View(new UserListingsViewModel
			{
				Users = usersVm,
				Roles = roles
			});
		}

		[HttpPost]
		public async Task<IActionResult> AddToRole(AddUserToRoleFormModel model)
		{
			var roleExists = await _roleManager.RoleExistsAsync(model.Role);
			var user = await _userManager.FindByIdAsync(model.UserId);
			var userExists = user != null;

			if (!roleExists || !userExists)
			{
				ModelState.AddModelError(string.Empty, "Invalid identity details.");
			}

			if (!ModelState.IsValid)
			{
				return RedirectToAction(nameof(Index));
			}

			await _userManager.AddToRoleAsync(user, model.Role);

			return RedirectToAction(nameof(Index));
		}
	}
}
