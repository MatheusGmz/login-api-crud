using Login.Application.Interfaces;
using Login.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Login.Api.Controllers
{
    [ApiController]
    [Route("Login")]
    public class LoginController : ControllerBase
    {
        private readonly IAccountServices _accountServices;

        public LoginController(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }
        [HttpGet]
        public IActionResult GetIdByEmail(string email, string password)
        {
            var id = _accountServices.GetIdByEmail(email, password);
            return id != 0 ? Ok(id) : Ok("Invalid e-email or password");
        }
        [HttpPost]
        public IActionResult CreateAccount(AccountViewModel accountViewModel)
        {
            var sucessCheck = _accountServices.CreateAccount(accountViewModel);
            return Ok(sucessCheck);
        }
        [HttpDelete]
        public IActionResult DeleteAccount(string login)
        {
            var sucessCheck = _accountServices.DeleteAccount(login);
            return Ok(sucessCheck);
        }
        [HttpPut]
        public IActionResult UpdateEmail(AccountViewModel accountViewModel)
        {
            var sucessCheck = _accountServices.UpdateEmail(accountViewModel);
            return Ok(sucessCheck);
        }
    }
}
