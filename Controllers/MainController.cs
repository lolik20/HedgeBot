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
            var _tradeService = _tradeFactory.CreateTradeService(senderCompId);
            _tradeService.Item2.Start();
            _tradeService.Item1.NewOrder("1", "EURUSD", Side.BUY, 9999);
            _tradeService.Item2.Stop();
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
