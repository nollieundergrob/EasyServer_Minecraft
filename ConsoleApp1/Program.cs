using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public static string Dot(string ucx, string ucy)
        {
            int x = Convert.ToInt32(ucx);
            int y = Convert.ToInt32(ucy);   
            int[] all_digits_by_x = new int[x.ToString().Length];
            int[] all_digits_by_y = new int[y.ToString().Length];
            for (int i = 0; i < all_digits_by_x.Length; i++) 
            {
                all_digits_by_x[i] = x % 10;
                x/= 10;
            }
            for (int j = 0; j < all_digits_by_y.Length; j++)
            {
                all_digits_by_y[j] = y % 10;
                y /= 10;
            }
            int [] stepdot = new int[all_digits_by_x.Length];
            int temp = 0;
            int count =0;
            foreach (int ix in all_digits_by_x)
            {
                foreach (int iy in all_digits_by_y)
                {  
            
                    stepdot[count] += ix*iy%10+temp;
                    temp = (int)Math.Round(ix*iy / 10.0);
                    Console.WriteLine(stepdot[Array.IndexOf(all_digits_by_x, ix)]);
                    count++;

                }
            }
            if (stepdot.Length == 1)
            {
                stepdot[count - 1] += temp*10;
            }
            else
            {
                stepdot[count - 1] += temp;
            }
            string result = "";
            count = 0;
            Array.Reverse(stepdot);
            foreach(int iter in stepdot)
            {
                result = result + Convert.ToString(iter);
            }
            return result;
        }
        static void Main(string[] args)
        {
            string x;
            string y;
            x = Console.ReadLine();
            y = Console.ReadLine();

            string result;
            result = Dot(x, y);
            int cx = Convert.ToInt32(x);
            int cy = Convert.ToInt32(y);
            Console.WriteLine(result.ToString(), '\t',x,"+",y,"=\t", cx * cy);
            Console.ReadKey();
        }
    }
}
