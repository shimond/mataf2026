using System;
using System.Collections.Generic;
using System.Text;

namespace ArraysAndMore
{
    public class Program
    {
        static void Main(string[] args)
        {
            //string s = "shimon";
            //ChangeTheString(s);

            ////Ex1();
            string[] names = new string[2] { "SHIMON", "David" };
           // names[2] = 12;
            ChangeTheName(names);
            Console.WriteLine(names[0]);

            int value = Random.Shared.Next(0, 500);
        }

        //static void Print(string[] names, double[] grades, string[] addresses)
        //{

        //}

        static void ChangeTheString(string s)
        {
            StringBuilder db = new StringBuilder(s);
            for (int i = 0; i < 1000000; i++)
            {
                //s += "A";
                db.Append(s);
            }
        }

        static void ChangeTheName(string[] arr)
        {
            arr[0] = "WOW!";
        }

        private static void Ex1()
        {
            string[] names = new string[5];
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine("Enter name NO." + (i + 1));
                names[i] = Console.ReadLine();
            }
            Console.WriteLine("________________________");
            for (int i = names.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(names[i]);
            }
        }

    }
}
