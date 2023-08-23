using Microsoft.EntityFrameworkCore;
using ProjectManagementPRN221.Models;

namespace ProjectManagementPRN221.Repository
{
    public class AccountRepo : IRepository<Account>
    {
        public AccountRepo(ProjectManagementContext context) : base(context)
        {
        }

        public Account GetByEmailAndPass(string email, string pass)
        {
            Account account = _context.Accounts.Where(a => a.Email == email&&a.Password == pass).FirstOrDefault();
            return account;
        }
    }
}
