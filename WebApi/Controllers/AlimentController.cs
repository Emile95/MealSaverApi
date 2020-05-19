using Application.Aliment.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Application.Aliment.DataModel.Sended;

namespace WebApi.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("aliments")]
    public class AlimentController : Controller
    {
        #region Properties and Constructor
        
        private readonly IAlimentCommand _command;
        private readonly IAlimentQuery _query;

        public AlimentController(
            IAlimentCommand command,
            IAlimentQuery query)
        {
            _command = command;
            _query = query;
        }
        
        #endregion

        [HttpPost("")]
        public IActionResult Add([FromBody]AlimentModel body)
        {
            return this.Return(() => _command.Add(body));
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return this.Return(() => _command.RemoveById(id));
        }

        [HttpPut("")]
        public IActionResult Update([FromBody]AlimentModel body)
        {
            return this.Return(() => _command.Update(body));
        }
    }
}
