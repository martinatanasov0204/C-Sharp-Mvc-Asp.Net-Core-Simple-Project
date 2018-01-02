using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using VW.Forum.Services.Models;

namespace VW.Forum.Web.Areas.Admin.Models.Users
{
	public class UserListingsViewModel
	{
		public IEnumerable<AdminUserListingServiceModel> Users { get; set; }

		public IEnumerable<SelectListItem> Roles { get; set; }
	}
}
