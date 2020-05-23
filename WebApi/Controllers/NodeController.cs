using Application.Node.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Application.Node.DataModel.Sended;

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
            return this.Return(() => _command.Login(body));
        }
    }
}
