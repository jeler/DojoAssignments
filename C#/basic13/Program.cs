using System;

using System.Collections.Generic;

namespace basic13
{
    class Program
    {
        public static void print() 
        {
            for (int i = 1; i < 256; i++) {
                Console.WriteLine(i);
            }
        }
        public static void oddnumbers() 
        {
            for (int i = 1; i < 256; i++) {
                if(i % 2 !=0) {
                    Console.WriteLine(i);
                }
            }
        }
        public static void sumnumbers() 
        {
            int sum = 0;
            for (int i =0; i < 256; i++) {
                sum+=i;
            }
            Console.WriteLine(sum);
        }
        public static void PrintArray(int[] arr) 
        {
            for (int i =0; i < arr.Length; i++) {
                Console.WriteLine(arr[i]);
            }
        }
        public static void FindMax(int [] arr)
        {
            int max = arr[0];
            for(int i =0; i<arr.Length; i++) {
                if (arr[i] > max) 
                {
                    max = arr[i];
                }
            }
            Console.WriteLine(max);
        }
        public static void FindAverage(int [] arr)
        {
            int sum = 0;
            for (int i =0; i < arr.Length; i++) {
                sum+=arr[i];
            }
            Console.WriteLine("This is sum" + sum);
            int average = sum / arr.Length;
            Console.WriteLine(average);
        }
        public static void GreaterThanY(int [] arr, int y) 
        {
            int count = 0;
            for(int i = 0; i < arr.Length; i++) {
                if(arr[i] > y) {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
        public static void SquareValues(int [] arr) {
            for(int i = 0; i < arr.Length; i++) {
                arr[i] = arr[i] * arr[i];
                Console.WriteLine(arr[i]);
            }
        }
        public static void NoNegs(int [] arr) {
            for(int i = 0; i < arr.Length; i++) {
                if(arr[i] < 0) {
                    arr[i] =0;
                }
            Console.WriteLine(arr[i]);
            }
        }
        public static void MinMaxAvg(int [] arr) {
            int max = arr[0];
            int min = arr[0];
            int sum = 0;
            for (int i = 0; i < arr.Length; i++) {
                if(arr[i] > max) {
                    max = arr[i];
                }
                if (arr[i] < min) {
                    min = arr[i];
                }
                sum+=arr[i];
            }
            Console.WriteLine(sum);
            Console.WriteLine("Arr.Length is" + arr.Length);
            int avg = sum / arr.Length;
                Console.WriteLine(max);
                Console.WriteLine(min);
                Console.WriteLine("Average is" + avg);
                Console.WriteLine("{0},{1},{2}",max,min,avg);
        }
        public static void ShiftArray(int [] arr) {
            for (int i =0; i< arr.Length-1; i++) {
            int temp = arr[i+1];
            arr[i] = temp;
            // arr[arr.Length-1] = 0;
            Console.WriteLine(arr[i]);
            }
            arr[arr.Length-1] =0;
            Console.WriteLine(arr[arr.Length-1]);            
        }
        // public static void NumberToString(object [] arr) 
        // {
        //     for(int i=0; i<arr.Length; i++) 
        //     {
        //         if (arr[i] is int) 
        //         {
        //             if(int)arr[i] < 0) 
        //             {
        //                 arr[i] = "Dojo";
        //             }
        //         }
        //     Console.WriteLine(arr[i]);
        //     }
        // }
        static void numToString(object[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i] is int)
                {
                    if((int)arr[i] < 0)
                    {
                        arr[i] = "Dojo";
                    }
                }
                System.Console.WriteLine(arr[i]);
            }
        }
        static void Main(string[] args)
        {
            // print();
            // oddnumbers();
            // sumnumbers();
            // PrintArray(new int[] { 1,3,5,7,9,13 });
            // FindMax(new int[] {-3, -5, -7, 0, 1,2,3});
            // FindAverage(new int[] {2, 10, 3});
            // GreaterThanY(new int[] {1, 3, 5, 7}, 3);
            // SquareValues(new int[] {1, 5, 10, -2});
            // NoNegs(new int[] {1, 5, 10, -2});
            MinMaxAvg(new int[] {1, 5, 10, -2});
            // ShiftArray(new int[] {1, 5, 10, 7, -2});
            // NumberToString(new object[] {-1, -3, 2});
            // numToString(new object[] {-1, -3, 2});
        }
    }
}
