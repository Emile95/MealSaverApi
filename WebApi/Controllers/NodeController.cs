using Application.Node.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Application.Node.DataModel.Sended;
using Microsoft.AspNetCore.Http;
using System;

namespace WebApi.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("nodes")]
    public class NodeController : Controller
    {
        #region Properties and Constructor
        
        private readonly INodeCommand _command;
        private readonly INodeQuery _query;

        public NodeController(
            INodeCommand command,
            INodeQuery query)
        {
            _command = command;
            _query = query;
        }
        
        #endregion

        [HttpPost("login")]
        public IActionResult Login([FromBody]LoginModel body)
        {
            return this.Return(() => {
                object result = _command.Login(body);
                HttpContext.Session.SetInt32("AccountId", Convert.ToInt32(result.GetType().GetProperty("Id").GetValue(result)));
                return result;
            });
        }

        [HttpGet("session/accountId")]
        public IActionResult GetSessionAccountId()
        {
            int? value = HttpContext.Session.GetInt32("AccountId");
            return this.Return(() => new { Value = value } );
        }
    }
}
