using System.ComponentModel.DataAnnotations;

namespace VW.Forum.Web.Models.AccountViewModels
{
	public class ForgotPasswordViewModel
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }
	}
}
