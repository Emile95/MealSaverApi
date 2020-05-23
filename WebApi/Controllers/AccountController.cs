using Application.Account.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Application.Account.DataModel.Sended;

namespace WebApi.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("accounts")]
    public class AccountController : Controller
    {
        #region Properties and Constructor
        
        private readonly IAccountCommand _accountCommand;
        private readonly IAccountQuery _accountQuery;

        public AccountController(
            IAccountCommand accountCommand,
            IAccountQuery accountQuery)
        {
            _accountCommand = accountCommand;
            _accountQuery = accountQuery;
        }
        
        #endregion

        [HttpPost("")]
        public IActionResult AddAccount([FromBody]AccountModel body)
        {
            return this.Return(() => _accountCommand.Add(body));
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody]LoginModel body)
        {
            return this.Return(() => _accountQuery.GetAccountIdByLogin(body));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAccount(int id)
        {
            return this.Return(() => _accountCommand.RemoveById(id));
        }

        [HttpPut("")]
        public IActionResult UpdateAccount([FromBody]AccountModel body)
        {
            return this.Return(() => _accountCommand.Update(body));
        }
    }
}
