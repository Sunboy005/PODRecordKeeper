using System;

namespace AppClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Record Keeper");
            Console.WriteLine("Todays date: " + DateTime.Now.ToShortDateString());
            Console.WriteLine("\n");
            App.Run();
        }
    }

}
