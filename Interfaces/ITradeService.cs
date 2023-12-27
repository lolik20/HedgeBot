using QuickFix.Fields;

namespace HedgeBot.Interfaces
{
    public interface ITradeService
    {
        void NewOrder(string id, string symbol, char side,int amount);
        void GetMarketData(string symbol);
    }
}
