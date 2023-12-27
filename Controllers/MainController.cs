using HedgeBot.Interfaces;
using Microsoft.AspNetCore.Mvc;
using QuickFix.Fields;

namespace HedgeBot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MainController : ControllerBase
    {
        private readonly ITradeService _tradeFactory;

        public MainController(ITradeService tradeService)
        {
            _tradeFactory = tradeService;
        }
        [HttpGet("test")]
        public IActionResult Test([FromQuery] string senderCompId)
        {
            var _tradeService = _tradeFactory.CreateTradeService(senderCompId);
            _tradeService.NewOrder("1", "EURUSD", Side.BUY, 9999);
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
