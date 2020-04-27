using Login.Domain.Entities;

namespace Login.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Account GetAccountById(int id);
        Account GetAccountByEmail(string email);
        Account GetAccountByLogin(string login);
        void CreateAccount(Account account);
        void DeleteAccount(Account account);

    }
}
