using System;

namespace MenuProductsAccounting
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(Accountant.GetReport(
                System.IO.File.ReadAllText(@"C:\Users\ihorm\source\repos\MenuProductsAccounting\menu.txt"),
                System.IO.File.ReadAllText(@"C:\Users\ihorm\source\repos\MenuProductsAccounting\pricelist.txt")
                ));
            Console.Read();
        }
    }
}
