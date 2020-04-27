using AutoMapper;
using Login.Application.Interfaces;
using Login.Application.ViewModel;
using Login.Domain.Entities;
using Login.Domain.Interfaces;

namespace Login.Application.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;

        public AccountServices(IMapper mapper, IAccountRepository accountRepository)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
        }

        public string CreateAccount(AccountViewModel accountViewModel)
        {
            var loginExistanceCheck = _accountRepository.GetAccountByLogin(accountViewModel.Login);
            var emailExistanceCheck = _accountRepository.GetAccountByEmail(accountViewModel.Email);

            if (loginExistanceCheck != null)
            {
                return "Login already registered. Choose another one";
            }
            else if (emailExistanceCheck != null)
            {
                return "E-mail already registered. Choose another one";
            }
            else
            {
                var entity = _mapper.Map<Account>(accountViewModel);
                _accountRepository.CreateAccount(entity);
                var creationCheck = _accountRepository.GetAccountByLogin(accountViewModel.Login);
                return creationCheck != null ? "Created!" : "Error on account creation, try again";
            }
        }

        public int GetIdByEmail(string email, string password)
        {
            var account = _accountRepository.GetAccountByEmail(email);
            return password == account.Password && !account.Deleted ? account.Id : 0;
        }
        public string DeleteAccount(string login)
        {
            var entity = _accountRepository.GetAccountByLogin(login);
            entity.Deleted = true;

            _accountRepository.DeleteAccount(entity);
            var accountDeletationCheck = _accountRepository.GetAccountById(entity.Id);
            return accountDeletationCheck != null && accountDeletationCheck.Deleted ? "Account deleted." : "Error on deleting account";

        }
        public string UpdateEmail(AccountViewModel account)
        {
            var emailExistanceCheck = _accountRepository.GetAccountByEmail(account.Email);
            if (emailExistanceCheck != null)
            {
                return "E-mail already registered. Choose another one";
            }
            else if (emailExistanceCheck.Deleted)
            {
                return "Account deleted.";
            }
            else
            {
                var entity = _accountRepository.GetAccountById(account.Id);
                entity.Email = account.Email;
                _accountRepository.DeleteAccount(entity);
                return string.Concat("Sucess! E-mail changed to: ", account.Email);
            }
        }
    }
}
