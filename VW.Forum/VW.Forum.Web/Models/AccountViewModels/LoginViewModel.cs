using System.ComponentModel.DataAnnotations;
using VW.Forum.Entities;

namespace VW.Forum.Web.Models.AccountViewModels
{
	public class LoginViewModel
	{
		[Required]
		[StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
		[Display(Name = "Username")]
		public string UserName { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Remember me?")]
		public bool RememberMe { get; set; }
	}
}
