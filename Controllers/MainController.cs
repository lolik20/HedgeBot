using HedgeBot.Interfaces;
using Microsoft.AspNetCore.Mvc;
using QuickFix.Fields;

namespace HedgeBot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MainController : ControllerBase
    {
        private readonly ITradeFactory _tradeFactory;

        public MainController(ITradeFactory tradeFactory)
        {
            _tradeFactory = tradeFactory;
        }
        [HttpGet("test")]
        public IActionResult Test([FromQuery] string senderCompId)
        {
            using var tradeServiceModel = _tradeFactory.CreateTradeService(senderCompId);
            tradeServiceModel._service.NewOrder("my_custom_id", "EURUSD", Side.BUY, 9999);
            return Ok();
        }
        //[HttpGet("data")]
        //public IActionResult Data()
        //{
        //    _tradeService.GetMarketData("");
        //    return Ok();
        //}

    }
}
