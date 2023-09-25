using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShoppingProject
{

    public class Database
    { 
        public static ConcurrentDictionary<int, string> TABLE_ACCOUNTS = new ConcurrentDictionary<int, string>(
           new Dictionary<int, string>()
           {
              {138894209, "Siya Arora"},
              {000000000, "Jane Smith"},
              {111111111, "John Smith"}
           }
        );

        public static ConcurrentDictionary<string, int> TABLE_PRODUCTS = new ConcurrentDictionary<string, int>();

        public static ConcurrentDictionary<int, List<ValueTuple<string, string, int>>> TABLE_ORDERS = new ConcurrentDictionary<int, List<ValueTuple<string, string, int>>>();

        public static void InitDatabase()
        {
            string[] ProductArray = { "Apple", "Banana", "Cherry", "Dates", "Grape" };
            Random rand = new Random();

            for(int i = 0; i < 5; ++i)
            {
                TABLE_PRODUCTS[ProductArray[i]] = rand.Next(1, 4);
            }
        }
    }
}
