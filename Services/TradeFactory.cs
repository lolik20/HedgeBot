using HedgeBot.Interfaces;
using HedgeBot.Models;
using QuickFix.Transport;

namespace HedgeBot.Services
{
    public class TradeFactory : ITradeFactory
    {

        public TradeServiceCompositeModel CreateTradeService(string senderCompId)
        {
            string config;
            using TextReader configReader = File.OpenText("./tradeclient.cfg");
            config = configReader.ReadToEnd();
            config = config.Replace("$senderCompId", senderCompId);
            using TextReader stringReader = new StringReader(config);
            QuickFix.SessionSettings settings = new QuickFix.SessionSettings(stringReader);
            QuickFix.IMessageStoreFactory storeFactory = new QuickFix.FileStoreFactory(settings);
            TradeService tradeService = new TradeService();
            QuickFix.Transport.SocketInitiator initiator = new QuickFix.Transport.SocketInitiator(tradeService, storeFactory, settings);

            return new TradeServiceCompositeModel(tradeService, initiator);
        }
    }
}
