using HedgeBot.Models;
using QuickFix.Transport;

namespace HedgeBot.Interfaces
{
    public interface ITradeFactory
    {
        TradeServiceCompositeModel CreateTradeService(string senderCompId);
    }
}
