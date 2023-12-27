using HedgeBot.Interfaces;
using QuickFix;
using QuickFix.Config;
using QuickFix.Fields;
using QuickFix.FIX44;
using System.Reflection.PortableExecutable;
using static System.Net.Mime.MediaTypeNames;

namespace HedgeBot.Services
{
    public class TradeService : MessageCracker, IApplication, ITradeService
    {
        private Session _session = null;

        public ITradeService CreateTradeService(string senderCompId)
        {
            string config;
            using TextReader configReader = File.OpenText("./tradeclient.cfg");
            config = configReader.ReadToEnd();
            config = config.Replace("$senderCompId", senderCompId);
            using TextReader stringReader = new StringReader(config);
            QuickFix.SessionSettings settings = new QuickFix.SessionSettings(stringReader);
            QuickFix.IMessageStoreFactory storeFactory = new QuickFix.FileStoreFactory(settings);
            QuickFix.Transport.SocketInitiator initiator = new QuickFix.Transport.SocketInitiator(this, storeFactory, settings);
            initiator.Start();
            return this;
        }
        public void OnCreate(SessionID sessionID)
        {
            _session = Session.LookupSession(sessionID);
        }

        public void FromAdmin(QuickFix.Message message, SessionID sessionID)
        {
        }

        public void FromApp(QuickFix.Message message, SessionID sessionID)
        {
            Console.WriteLine($"IN: {message.ToString()}");
        }

        public void NewOrder(string id, string symbol, char side, int amount)
        {
            var orderSide = new Side(side);

            var message = new NewOrderSingle(new ClOrdID(id), new Symbol(symbol), orderSide, new TransactTime(DateTime.UtcNow), new OrdType(OrdType.MARKET));
            message.OrderQty = new OrderQty(amount);
            _session.Send(message);
        }
        public void GetMarketData(string symbol)
        {
            var message = new MarketDataRequest(new MDReqID(), new SubscriptionRequestType(SubscriptionRequestType.SNAPSHOT), new MarketDepth(1));
            _session.Send(message);
        }

        //public async Task<bool> CancelOrder()
        //{
        //    var message = new OrderCancelRequest();
        //}

        public void OnLogon(SessionID sessionID)
        {
            Console.WriteLine("Logon - " + sessionID.ToString());
        }

        public void OnLogout(SessionID sessionID)
        {
            Console.WriteLine("Logout - " + sessionID.ToString());
        }

        public void ToAdmin(QuickFix.Message message, SessionID sessionID)
        {
        }

        public void ToApp(QuickFix.Message message, SessionID sessionId)
        {
            Console.WriteLine("OUT: " + message);
        }
    }
}
