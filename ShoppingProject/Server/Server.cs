using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ShoppingProject
{
    public class Server
    {
        public static void Init()
        {
            try
            {
                State.IP_ADDRESS = IPAddress.Loopback;
                State.PORT_NUMBER = 55055;
                Database.InitDatabase();
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static void Start()
        {
            try
            {
                State.LISTENER = new TcpListener(State.IP_ADDRESS, State.PORT_NUMBER);
                State.LISTENER.Start(); // bind to port 
                State.CANCELLATION_TOKEN.Register(State.LISTENER.Stop); // Stop the server port listener if a cancellation is requested
                while (!State.CANCELLATION_TOKEN.IsCancellationRequested)
                {
                    int connections = 0;
                    Console.WriteLine("Waiting for a client connection...");
                    TcpClient client = State.LISTENER.AcceptTcpClient(); // blocks till we get a clients
                    connections++;
                    Console.WriteLine($"Client has connected with Client id#{client.GetHashCode()}");
                    Console.WriteLine($"Total number of connections: {connections}");
                    Thread thClientHandler = new Thread(handleRequest); // Run the client handler in a new thread
                    thClientHandler.Start(client); // pass a handle to that specific client

                }
            }
            catch (SocketException ex) 
            {
                return;
            }
        }

        public static void handleRequest(Object threadInfo)
        {
            TcpClient client = (TcpClient)threadInfo;
            // first check what kind of request we getting
            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            string line = "";
            try
            {
                while ((line = reader.ReadLine()) != null)
                {
                    // parse till a colon (for parameters)
                    string[] reqTokens = line.Split(':');
                    // first token should be the request type
                    // rest of the string should be the 
                    string requestType = reqTokens[0];

                    string[] paramaters = { };

                    if (reqTokens.Length > 1)
                    {
                        paramaters = reqTokens[1].Split(',');
                    }

                    // lookup our request type
                    switch (requestType)
                    {
                        case "CONNECT":
                            State.PROTOCOL_TABLE["CONNECT"].Invoke((client, paramaters));
                            Console.WriteLine($"Current number of Active Clients (Logged in) = {State.ACTIVE_CLIENTS.Count}");
                            break;
                        case "DISCONNECT":
                            State.PROTOCOL_TABLE["DISCONNECT"].Invoke((client, paramaters));
                            break;
                        case "GET_PRODUCTS":
                            State.PROTOCOL_TABLE["GET_PRODUCTS"].Invoke((client, paramaters));
                            break;
                        case "GET_ORDERS":
                            State.PROTOCOL_TABLE["GET_ORDERS"].Invoke((client, paramaters));
                            break;
                        case "PURCHASE":
                            State.PROTOCOL_TABLE["PURCHASE"].Invoke((client, paramaters));
                            break;
                        default:
                            Console.WriteLine("UNSUPPORTED_REQUEST");
                            break;
                    }
                }
                // Free
                stream.Close();
                writer.Close();
                reader.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Client#{client.GetHashCode()} shut down unexpectedly. ERROR: {ex.Message}");
                // Free
                stream.Close();
                writer.Close();
                reader.Close();
            }

        }
    }
}
