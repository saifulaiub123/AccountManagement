using Account.Application.Model;
using System.Threading.Tasks;

namespace Account.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
