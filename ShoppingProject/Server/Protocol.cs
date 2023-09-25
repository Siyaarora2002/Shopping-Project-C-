using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace ShoppingProject
{
    public class Protocol
    {
        public static void Connect(object obj)
        {
            (TcpClient client, string[] paramaters) = ((TcpClient, string[]))obj;
            try
            {
                NetworkStream stream = client.GetStream();
                StreamReader reader = new StreamReader(stream);
                StreamWriter writer = new StreamWriter(stream);
                writer.AutoFlush = true;

                int accNo = Int32.Parse(paramaters[0]);
                string name = "";
                bool login = Database.TABLE_ACCOUNTS.TryGetValue(accNo, out name);

                // if accNo doesn't exist in our db
                if (!login)
                {
                    writer.WriteLine("CONNECT_ERROR");
                    Console.WriteLine("CONNECT_ERROR");
                    return;
                }

                // check if client already connected
                if (!State.ACTIVE_CLIENTS.TryAdd(client.GetHashCode(), ((client, name, accNo))))
                {
                    writer.WriteLine("CONNECTION_EXISTS");
                    Console.WriteLine("CONNECTION_EXISTS");
                    return;
                }

                writer.WriteLine($"CONNECTED:{name}");
                Console.WriteLine($"CONNECTED:{name}");

            }
            catch (IOException ex) // Exception takes us out of the loop, so client handler thread will end
            {
                Console.WriteLine("***Network Error***");
            }
            catch (ObjectDisposedException)
            {
                Console.WriteLine("***Network Error***"); // May occur if read  or write is attempted after stream is closed
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("That user does not have an account!"); // May occur if read  or write is attempted after stream is closed
            }
        }

        public static void GET_PRODUCTS(object obj)
        {
            (TcpClient client, string[] paramaters) = ((TcpClient, string[]))obj;

            // gets all products and writes them to the client
            try
            {
                NetworkStream stream = client.GetStream();
                StreamReader reader = new StreamReader(stream);
                StreamWriter writer = new StreamWriter(stream);
                writer.AutoFlush = true;

                // check if client already connected
                if (!State.ACTIVE_CLIENTS.ContainsKey(client.GetHashCode()))
                {
                    writer.WriteLine("NOT_CONNECTED");
                    Console.WriteLine("NOT_CONNECTED");
                    return;
                }

                foreach (KeyValuePair<string, int> entry in Database.TABLE_PRODUCTS)
                {
                    writer.WriteLine($"{entry.Key},{entry.Value}");
                    Console.WriteLine($"{entry.Key},{entry.Value}");
                }

                writer.WriteLine("END");
                Console.WriteLine("END");
            }
            catch (IOException ex) // Exception takes us out of the loop, so client handler thread will end
            {
                Console.WriteLine("***Network Error***");
            }
            catch (ObjectDisposedException)
            {
                Console.WriteLine("***Network Error***"); // May occur if read  or write is attempted after stream is closed
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("That user does not have an account!"); // May occur if read  or write is attempted after stream is closed
            }
        }

        public static void GET_ORDERS(object obj)
        {
            (TcpClient client, string[] paramaters) = ((TcpClient, string[]))obj;

            try
            {
                NetworkStream stream = client.GetStream();
                StreamReader reader = new StreamReader(stream);
                StreamWriter writer = new StreamWriter(stream);
                writer.AutoFlush = true;

                // check if client already connected
                if (!State.ACTIVE_CLIENTS.ContainsKey(client.GetHashCode()))
                {
                    writer.WriteLine("NOT_CONNECTED");
                    Console.WriteLine("NOT_CONNECTED");
                    return;
                }

                // if no orders we shouldn't send back
                if (Database.TABLE_ORDERS.Count == 0)
                {
                    writer.WriteLine("NOT_AVAILABLE");
                    Console.WriteLine("NOT_AVAILABLE");
                    return;
                }

                foreach (KeyValuePair<int, List<ValueTuple<string, string, int>>> entry in Database.TABLE_ORDERS)
                {
                    foreach (ValueTuple<string, string, int> order in entry.Value)
                    {
                        writer.WriteLine($"{order.Item1},{order.Item2},{order.Item3}");
                        Console.WriteLine($"{order.Item1},{order.Item2},{order.Item3}");
                    }

                }
                writer.WriteLine("END");

            }
            catch (Exception ex)
            {

            }
        }
        public static void TRANSACTION_PURCHASE(object obj)
        {
            (TcpClient client, string[] paramaters) = ((TcpClient, string[]))obj;

            try
            {
                NetworkStream stream = client.GetStream();
                StreamReader reader = new StreamReader(stream);
                StreamWriter writer = new StreamWriter(stream);
                writer.AutoFlush = true;

                string product = paramaters[0];
                // check if client already connected
                if (!State.ACTIVE_CLIENTS.ContainsKey(client.GetHashCode()))
                {
                    writer.WriteLine("NOT_CONNECTED");
                    Console.WriteLine("NOT_CONNECTED");
                    return;
                }

                // check if product is valid
                if (!Database.TABLE_PRODUCTS.ContainsKey(product))
                {
                    writer.WriteLine("NOT_VALID");
                    Console.WriteLine("NOT_VALID");
                    return;
                }

                // check if enough product
                if (Database.TABLE_PRODUCTS[product] == 0)
                {
                    writer.WriteLine("NOT_AVAILABLE");
                    Console.WriteLine("NOT_AVAILABLE");
                    return;
                }

                //perform transaction & update orders database
                int hash = client.GetHashCode();
                string clientName = State.ACTIVE_CLIENTS[hash].Item2;

                if (Database.TABLE_ORDERS.ContainsKey(hash))
                {
                    foreach (KeyValuePair<int, List<ValueTuple<string, string, int>>> entry in Database.TABLE_ORDERS)
                    {
                        int index = entry.Value.FindIndex(item => product == item.Item2);

                        if (index == -1)
                        {
                            entry.Value.Add(ValueTuple.Create(
                            clientName,
                            product,
                            1));
                            Database.TABLE_PRODUCTS[product]--;
                            writer.WriteLine("SUCCESS");
                            Console.WriteLine("SUCCESS");
                            return;
                        }
                        else
                        {
                            entry.Value[index] = ValueTuple.Create(
                            clientName,
                            product,
                            entry.Value[index].Item3 + 1);
                            Database.TABLE_PRODUCTS[product]--;
                            writer.WriteLine("SUCCESS");
                            Console.WriteLine("SUCCESS");
                            return;
                        }


                    }
                }

                List<ValueTuple<string, string, int>> temp = new List<ValueTuple<string, string, int>>();
                temp.Add(
                    ValueTuple.Create(
                            clientName,
                            product,
                            1
                    )
                );

                Database.TABLE_ORDERS.TryAdd(hash, temp);
                Database.TABLE_PRODUCTS[product]--;
                writer.WriteLine("SUCCESS");
                Console.WriteLine("SUCCESS");

            }
            catch (IOException ex) // Exception takes us out of the loop, so client handler thread will end
            {
                Console.WriteLine("***Network Error***");
            }
            catch (ObjectDisposedException)
            {
                Console.WriteLine("***Network Error***"); // May occur if read  or write is attempted after stream is closed
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("That user does not have an account!"); // May occur if read  or write is attempted after stream is closed
            }
        }

        public static void Disconnect(object obj)
        {
            (TcpClient client, string[] paramaters) = ((TcpClient, string[]))obj;
            Console.WriteLine($"Client with id#{client.GetHashCode()} Disconnected.");
            State.ACTIVE_CLIENTS.TryRemove(client.GetHashCode(), out _);
        }
    }
}
