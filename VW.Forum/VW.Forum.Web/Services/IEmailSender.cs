using System.Threading.Tasks;

namespace VW.Forum.Web.Services
{
	public interface IEmailSender
	{
		Task SendEmailAsync(string email, string subject, string message);
	}
}
