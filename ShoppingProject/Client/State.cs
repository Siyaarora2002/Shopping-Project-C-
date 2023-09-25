using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Client
{
    public struct State
    {
        public static string HOST_IP;
        public static int HOST_PORT;
        public static TcpClient TCP_CLIENT = null; 
        public static int ACCOUNT_NUMBER;
        public static string ACCOUNT_NAME;
        public static bool LOGGED_IN = false;
        public static List<ValueTuple<string, string>> PRODUCTS = new List<ValueTuple<string, string>>();
        public static List<ValueTuple<string, string, string>> ORDERS = new List<ValueTuple<string, string, string>>();
        public static List<ValueTuple<string, string>> RECENT_ORDERS = new List<ValueTuple<string, string>>();

        async public static void UpdateProductsTable(DataGridView table)
        {
            State.PRODUCTS.Clear();
            table.Rows.Clear();
            await serverAPI.GET_PRODUCTS();
            foreach (ValueTuple<string, string> pair in State.PRODUCTS)
                table.Rows.Add(pair.Item1, pair.Item2);
        }

        async public static Task<string> UpdateOrdersTable(DataGridView table)
        {
            State.ORDERS.Clear();
            table.Rows.Clear();
            string response = await serverAPI.GET_ORDERS();
            foreach (ValueTuple<string, string, string> pair in State.ORDERS)
                table.Rows.Add(pair.Item1, pair.Item2, pair.Item3);
            return response;
        }

        async public static Task<string> UpdateRecentsTable(DataGridView table)
        {
            State.ORDERS.Clear();
            table.Rows.Clear();
            string response = await serverAPI.GET_ORDERS();
            foreach (ValueTuple<string, string, string> pair in State.ORDERS)
            {
                if(State.ACCOUNT_NAME == pair.Item1)
                    table.Rows.Add(pair.Item2, pair.Item3);
            }
                
            return response;
        }
    }
}
