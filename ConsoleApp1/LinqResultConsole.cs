using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ConsoleApp1
{
    static class LinqResultConsole
    {
       public static void DisplayResult<T>(IEnumerable<T> result)
        {

            if (typeof(T) == typeof(string) || typeof(T) == typeof(int))
            {
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                //Console.WriteLine("Tulajdonságok:");

                var sajt = typeof(T).GetProperties();
                ConsoleColor[] szinek = new ConsoleColor[sajt.Length];
                for (int i = 0; i < sajt.Length; i++)
                {
                    var getattribute = sajt[i].GetCustomAttributes<ColoredPropertyAttribute>().ToArray();
                    szinek[i] = getattribute.Length > 0 ? getattribute[0].Szine : ConsoleColor.White;
                }


                for (int i = 0; i < sajt.Length; i++)
                {
                    Console.ForegroundColor = szinek[i];
                    Console.Write($"{sajt[i].Name}\t");

                }
                Console.WriteLine();
                foreach (var item in result)
                {
                    for (int i = 0; i < sajt.Length; i++)
                    //foreach (var props in sajt)
                    {
                        Console.ForegroundColor = szinek[i];
                        Console.Write($"{sajt[i].GetValue(item)}\t");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
