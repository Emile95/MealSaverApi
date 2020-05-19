using Application.Meal.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Application.Meal.DataModel.Sended;

namespace WebApi.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("meals")]
    public class MealController : Controller
    {
        #region Properties and Constructor
        
        private readonly IMealCommand _command;
        private readonly IMealQuery _query;

        public MealController(
            IMealCommand command,
            IMealQuery query)
        {
            _command = command;
            _query = query;
        }
        
        #endregion

        [HttpPost("")]
        public IActionResult Add([FromBody]MealModel body)
        {
            return this.Return(() => _command.Add(body));
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return this.Return(() => _command.RemoveById(id));
        }

        [HttpPut("")]
        public IActionResult Update([FromBody]MealModel body)
        {
            return this.Return(() => _command.Update(body));
        }
    }
}
