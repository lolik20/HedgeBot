using HedgeBot.Interfaces;
using HedgeBot.Services;
using QuickFix.Transport;

namespace HedgeBot.Models
{
    public class TradeServiceCompositeModel : IDisposable
    {
        public ITradeService _service;
        public SocketInitiator _socket;
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
        ~TradeServiceCompositeModel()
        {
            Dispose();
        }
    }
}
