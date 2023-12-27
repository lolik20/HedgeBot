using HedgeBot.Interfaces;
using Microsoft.AspNetCore.Mvc;
using QuickFix.Fields;

namespace HedgeBot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MainController: ControllerBase
    {
        private readonly ITradeService _tradeService;
        public MainController(ITradeService tradeService)
        {
            _tradeService = tradeService;
        }
        [HttpGet("test")]
        public IActionResult Test()
        {
            _tradeService.NewOrder("1","EURUSD", Side.BUY,9999);
            return Ok();
        }
        [HttpGet("data")]
        public IActionResult Data()
        {
            _tradeService.GetMarketData("");
            return Ok();
        }

    }
}
