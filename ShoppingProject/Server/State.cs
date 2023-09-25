using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace ShoppingProject
{
    public struct State
    {
        public static int PORT_NUMBER;
        public static IPAddress IP_ADDRESS;
        public static TcpListener LISTENER;
        public static TcpClient TCP_CLIENT;
        public static CancellationToken CANCELLATION_TOKEN;
        public static ConcurrentDictionary<int, ValueTuple<TcpClient, string, int>> ACTIVE_CLIENTS = new ConcurrentDictionary<int, ValueTuple<TcpClient, string, int>>();
        public static ConcurrentDictionary<string, Action<object>> PROTOCOL_TABLE = new ConcurrentDictionary<string, Action<object>>(
          new Dictionary<string, Action<object>>()
          {
              {"CONNECT", (object obj) => { Protocol.Connect(obj);  } },
              {"DISCONNECT",  (object obj) => { Protocol.Disconnect(obj);  } },
              {"GET_PRODUCTS", (object obj) => { Protocol.GET_PRODUCTS(obj);  } },
              {"GET_ORDERS",  (object obj) => { Protocol.GET_ORDERS(obj);  } },
              {"PURCHASE",  (object obj) => { Protocol.TRANSACTION_PURCHASE(obj);  } }
          }
       );
    };

}
