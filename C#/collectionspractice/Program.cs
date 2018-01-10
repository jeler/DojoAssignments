using System;

using System.Collections.Generic;

using System.Linq;

// using System.Collections.Concurrent.ConcurrentDictionary<>;

namespace collectionspractice
{
    class Program
    {
        static void Main(string[] args)
        {
            // int[] numArray = {0,1,2,3,4,5,6,7,8,9};
            // for (int idx = 0; idx < numArray.Length; idx++)
            // {
            //     Console.WriteLine(numArray[idx]);
            // }
            string[] names = {"Martin", "Nikki", "Sara"};
            // for (int idx = 0; idx < stringArray.Length; idx++) 
            // {
            //     Console.WriteLine(stringArray[idx]);                
            // }
            // bool[] boolArray = {true, false, true, false, true, false, true, false, true, false}; 
            // for (int idx = 0; idx < boolArray.Length; idx++) 
            // {
            //     Console.WriteLine(boolArray[idx]);                
            // }
            // int [,] multiplicationtable = new int[10,10];
            // var rowLength = multiplicationtable.GetLength(0);
            // var colLength = multiplicationtable.GetLength(1);
            // for (int i = 1; i < rowLength; i++) {
            //     multiplcationtable[i-1] = new int[i];
            //     Console.WriteLine(multiplicationtable[i]);   
            // }

            List<string> icecreamflavors = new List<string>();
            icecreamflavors.Add("Chocolate");
            icecreamflavors.Add("Vanilla");
            icecreamflavors.Add("Strawberry");
            icecreamflavors.Add("Chocolate Chip");
            icecreamflavors.Add("Mint");
            // {
            //     Console.WriteLine(icecreamflavors.Count);
            // }
            // {
            //     Console.WriteLine(icecreamflavors[2]);
            // }
            // icecreamflavors.Remove(icecreamflavors[2]);
            // {
            //     Console.WriteLine(icecreamflavors.Count);
            // }
            // for(var idx = 0; idx < icecreamflavors.Count; idx++) {
            //     Console.WriteLine(icecreamflavors[idx]);
            // }

            Dictionary<string,string> dict = new Dictionary<string,string>();

            foreach(string name in names) {
                dict.Add(name, null);
            }
            Random rand = new Random();
            foreach(string name in names) {
                dict[name] = icecreamflavors[rand.Next(0,icecreamflavors.Count)];
            }
            foreach (var entry in dict) {
                Console.WriteLine(entry.Key + " " + entry.Value);
            }
        }
    }
}
