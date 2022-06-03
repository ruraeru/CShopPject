using System;

namespace CShopPject
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();

            for (int i = 0; i < 100; i++)
            {
                int a = r.Next(1, 100);
                Console.WriteLine(a);
            }
        }
    }
}
