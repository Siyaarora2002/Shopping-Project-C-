using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ShoppingProject
{

    class Program
    {
        static void Main(string[] args)
        {
            // create a server thread, the server thread will also create a sub thread for each client
            CancellationTokenSource cts = new CancellationTokenSource();
            Thread serverThread = new Thread(() =>
            {
                Server.Init();
                State.CANCELLATION_TOKEN = cts.Token;
                Server.Start();
            });

            Console.WriteLine("Welcome to the Simple Shopping Server! Author: Siya Arora");
            Console.WriteLine("Enter 'q' or 'Q' ANYTIME to stop the server!");

            serverThread.Start();
            char c = '0';

            while (c != 'q')
            {
                c = Console.ReadKey().KeyChar;
                if (c == 'Q' || c == 'q')
                {
                    cts.Cancel();
                }
                    
            }
            serverThread.Join();
            Console.WriteLine("Server Stopped! Press any key to exit...");
            Console.ReadKey();
        }
    }
}
