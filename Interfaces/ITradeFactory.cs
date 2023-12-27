using QuickFix.Transport;

namespace HedgeBot.Interfaces
{
    public interface ITradeFactory
    {
        Tuple<ITradeService, SocketInitiator> CreateTradeService(string senderCompId);
    }
}
