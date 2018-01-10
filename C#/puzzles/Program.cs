using System;
using System.Collections.Generic;
namespace puzzles
{
    class Program
    {
        public static void RandomArray() {
            Random rand = new Random();
            int [] arr = new int[10];
            for (int i = 0; i < 9; i++) {
                arr[i] = rand.Next(5, 25);
            }
            int sum = 0;
            int min = arr[0];
            int max = arr[0];
            for (int i = 0; i < 9; i++) {
                if(arr[i] > max ) {
                    max = arr[i];
                }
                if(arr[i] < min) {
                    min = arr[i];
                    Console.Write("This is min" + min);
                }
                sum+=arr[i];
            }
            Console.WriteLine("This is max" + max);
            Console.WriteLine("This is min" + min);
            Console.WriteLine("This is sum" + sum);

        }
        public static void TossCoin() {
            Random rand = new Random();
            string head = "heads";
            string tail = "tails";
            Console.Write("Tossing a Coin!");
            int toss = rand.Next(0,2);
            if (toss == 1) {
                Console.WriteLine("You rolled {0} which is {1}", toss, head);
            }
            if (toss == 0) {
                Console.WriteLine("You rolled {0} which is {1}", toss, tail);  
            }
        }
        public static double TossMultipleCoins(int num) {
            Random rand = new Random();
            int count = 0;
            for (int i =0; i < num; i++) {
                int toss = rand.Next(1,3);
                if (toss == 2) {
                    count++;
                }
            }
            Console.Write("This is count" + count);
            Console.WriteLine("This is num" + num);
            double DoubleCount = count;
            double DoubleNum = num; 
            double headsratio = DoubleCount/DoubleNum;
            Console.WriteLine(headsratio);
            return headsratio;
        }
        public static void Names() {
            string [] names = new string[5] {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            List<string> names2 = new List<string>();
            Random rand = new Random();
            for (int i = 0; i < names.Length; i++) {
                int random = rand.Next(0,names.Length);
                string temp = names[i];
                names[i] = names[random];
                names[random] = temp;
            }
            for (int i = 0; i< names.Length; i++) {
                if (names[i].Length > 5) {
                    names2.Add(names[i]);
                }
            }
            for (int i = 0; i <names.Length; i++) {
                Console.WriteLine(names[i]);
            }
            
        }
        static void Main(string[] args)
        {
            // RandomArray();
            // TossCoin();
            // TossMultipleCoins(50);
            Names();
        }
    }
}