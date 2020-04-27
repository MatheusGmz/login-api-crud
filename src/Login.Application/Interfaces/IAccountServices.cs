using Login.Application.ViewModel;

namespace Login.Application.Interfaces
{
    public interface IAccountServices
    {
        int GetIdByEmail(string email, string password);
        string CreateAccount(AccountViewModel accountViewModel);
        string DeleteAccount(string login);
        string UpdateEmail(AccountViewModel accountViewModel);
        
    }
}
