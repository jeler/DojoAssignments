using System;

using System.Collections.Generic;

namespace boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> boxing = new List<object>();
            boxing.Add(7);
            boxing.Add(28);
            boxing.Add(-1);
            boxing.Add(true);
            boxing.Add("chair");
            int sum = 0;
            foreach(var entry in boxing) {
                // Console.WriteLine(entry);
                if(entry is int) {
                    sum+=(int)entry;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
