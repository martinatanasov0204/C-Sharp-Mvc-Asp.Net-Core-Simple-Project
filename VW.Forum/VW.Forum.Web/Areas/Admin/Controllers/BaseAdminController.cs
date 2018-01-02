using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static VW.Forum.Web.WebConstants;

namespace VW.Forum.Web.Areas.Admin.Controllers
{
	[Area(AdminArea)]
	[Authorize(Roles = AdministratorRole)]
	public abstract class BaseAdminController : Controller
	{
	}
}
