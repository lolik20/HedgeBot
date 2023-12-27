using HedgeBot.Interfaces;
using HedgeBot.Services;
using QuickFix.Transport;

namespace HedgeBot.Models
{
    public class TradeServiceCompositeModel : IDisposable
    {
        public readonly ITradeService _service;
        public readonly SocketInitiator _socket;
        public TradeServiceCompositeModel(TradeService tradeService, SocketInitiator socketInitiator)
        {
            _socket = socketInitiator;
            _service = tradeService;
            _socket.Start();
        }

        public void Dispose()
        {
            _socket.Stop();
        }
       
    }
}
