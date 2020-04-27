using Login.Domain.Entities;
using Login.Domain.Interfaces;
using Login.Infrastructure.Context;
using System.Linq;

namespace Login.Infrastructure.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly LoginContext _loginContext;

        public AccountRepository(LoginContext loginContext)
        {
            _loginContext = loginContext;
        }
        public Account GetAccountById(int id)
        {
            return _loginContext.Accounts.Where(x => x.Id == id).FirstOrDefault();
        }
        public Account GetAccountByEmail(string email)
        {
            return _loginContext.Accounts.Where(x => x.Email == email).FirstOrDefault();
        }
        public Account GetAccountByLogin(string login)
        {
            return _loginContext.Accounts.Where(x => x.Login == login).FirstOrDefault();
        }
        public void CreateAccount(Account account)
        {
            _loginContext.Add(account);
            _loginContext.SaveChanges();
        }
        public void DeleteAccount(Account account)
        {
            _loginContext.Update(account);
            _loginContext.SaveChanges();
        }

    }
}
