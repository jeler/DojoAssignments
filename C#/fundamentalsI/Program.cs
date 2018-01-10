using System;

namespace fundamentalsI
{
    class Program
    {
        static void Main(string[] args)
        {
            // for (int i = 1; i <= 255; i++)
            // {
            //     Console.WriteLine(i);
            // }

            for (int i = 1; i <= 100; i++)
            {
                if (((i % 3) == 0 || (i % 5) == 0) && !((i % 5) == 0 && (i % 3) ==0)) {
                    Console.WriteLine(i);
                }
            }

            // {
            //     if (((i % 3) == 0 || (i % 5) == 0) && (i % 15) != 0) {
            //         Console.WriteLine(i);
            //     }
            // }

            // {
            //     if ((i % 3) == 0 && (i % 5) == 0) 
            //     {
            //         Console.WriteLine( "Fizz Buzz" + " " + i);
            //     }
            //     else if (i % 3 == 0) 
            //     {
            //         Console.WriteLine("Fizz" + " " + i);
            //     }
            //     else if (i % 5 == 0) {
            //         Console.WriteLine("Buzz" + " " + i);
            //     }

            //     else {
            //         Console.WriteLine(i);
            //     }
            // }     
        }
    }
}
