using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;

namespace Client
{
    class serverAPI
    {
        async public static Task<string> Connect()
        {
            try
            {
                // create instance of TcpClient
                if(State.TCP_CLIENT == null)
                    State.TCP_CLIENT = new TcpClient();

                if(!State.TCP_CLIENT.Connected)
                    State.TCP_CLIENT.Connect(State.HOST_IP, State.HOST_PORT);
                
                // if successful we need to send over the accountNo so the server may send back the client name
                NetworkStream stream = State.TCP_CLIENT.GetStream();
                StreamWriter writer = new StreamWriter(stream); // to write the account No to the Server
                StreamReader reader = new StreamReader(stream); // to read back the name as a response
                writer.AutoFlush = true;
                writer.WriteLine($"CONNECT:{State.ACCOUNT_NUMBER.ToString()}");
                string response = await reader.ReadLineAsync();
                return response;
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
                return "CONNECT_ERROR";
            }
        }

        async public static Task<string> GET_PRODUCTS()
        {
            try
            {
                // create instance of TcpClient
                if (State.TCP_CLIENT == null)
                    State.TCP_CLIENT = new TcpClient();

                if (!State.TCP_CLIENT.Connected)
                    State.TCP_CLIENT.Connect(State.HOST_IP, State.HOST_PORT);

                NetworkStream stream = State.TCP_CLIENT.GetStream();
                StreamWriter writer = new StreamWriter(stream); // to write the account No to the Server
                StreamReader reader = new StreamReader(stream); // to read back the name as a response
                writer.AutoFlush = true;
                string line = "";
                // SEND THE REQUEST THE SERVER
                writer.WriteLine("GET_PRODUCTS");
                // GET THE RESPONSE, PARSE IT AND 
                while ((line = reader.ReadLine()) != "END")
                {
                    if (line == "NOT_CONNECTED")
                        return line;

                    string[] tokens = line.Split(',');
                    State.PRODUCTS.Add((tokens[0], tokens[1]));
                }
                return "SUCCESS";
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
                return "NOT_CONNECTED";
            }
        }

        async public static Task<string> GET_ORDERS()
        {
            try
            {
                // create instance of TcpClient
                if (State.TCP_CLIENT == null)
                    State.TCP_CLIENT = new TcpClient();

                if (!State.TCP_CLIENT.Connected)
                    State.TCP_CLIENT.Connect(State.HOST_IP, State.HOST_PORT);

                NetworkStream stream = State.TCP_CLIENT.GetStream();
                StreamWriter writer = new StreamWriter(stream); // to write the account No to the Server
                StreamReader reader = new StreamReader(stream); // to read back the name as a response
                writer.AutoFlush = true;
                string line = "";
                // SEND THE REQUEST THE SERVER
                writer.WriteLine("GET_ORDERS");

                while ((line = await reader.ReadLineAsync()) != "END")
                {
                    if (line == "NOT_CONNECTED" || line == "NOT_AVAILABLE")
                        return line;
                    string[] tokens = line.Split(',');
                    State.ORDERS.Add((tokens[0], tokens[1], tokens[2]));
                }

                return "SUCCESS";
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
                return "NOT_CONNECTED";
            }
        }

        public static string PURCHASE_TRANSACTION(string productName)
        {
            try
            {
                NetworkStream stream = State.TCP_CLIENT.GetStream();
                StreamWriter writer = new StreamWriter(stream); // to write the account No to the Server
                StreamReader reader = new StreamReader(stream); // to read back the name as a response
                writer.AutoFlush = true;
                writer.WriteLine($"PURCHASE:{productName}");
                string response = reader.ReadLine();
                return response;
            }
            catch (SocketException ex)
            {
                Console.WriteLine("Server Error");
                return "";
            }
        }
        async public static void Disconnect()
        {
            try
            {
                NetworkStream stream = State.TCP_CLIENT.GetStream();
                StreamWriter writer = new StreamWriter(stream); // to write the account No to the Server
                StreamReader reader = new StreamReader(stream); // to read back the name as a response
                writer.AutoFlush = true;
                string line = "";
                await writer.WriteLineAsync("DISCONNECT");
                freeResources();
                stream.Close();
                writer.Close();
                reader.Close();
            } catch(InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Server has Disconnected unexpectedly.", ex.Message);
            }
        }
        private static void freeResources()
        {
            State.TCP_CLIENT?.Close();
            State.TCP_CLIENT = null;
        }

    }
}
