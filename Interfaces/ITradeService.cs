using QuickFix.Fields;

namespace HedgeBot.Interfaces
{
    public interface ITradeService
    {
        void GetMarketData(string symbol);
        void NewOrder(string id, string symbol, char side, int amount);
    }
}
