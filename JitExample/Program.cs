using System.Diagnostics;

namespace JitExample
{
    public static class Program
    {                    
        public static void Main(string[] args)
        {        
            MyApp myApp = new MyApp();

            while (true)
            {
                Console.WriteLine($"[{Process.GetCurrentProcess().Id}] waiting for input...");
                string value = Console.ReadLine();
                if (value == "1")
                {
                    myApp.SayHello1();
                }

                if (value == "2")
                {
                    myApp.SayHello2();
                }

                if (value == "3")
                {
                    myApp.SayHello3();
                }
            }
        }
    }

    public class MyApp
    {
        public void SayHello1()
        {
            Console.WriteLine("Hello 1 ;-) " + DateTime.Now.ToLongTimeString());
        }
        
        public void SayHello2()
        {
            Console.WriteLine("Hello 2 ;-) " + DateTime.Now.ToLongTimeString());
        }

        public void SayHello3()
        {
            string value = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";

            Console.WriteLine("Hello 3 ;-) " + value);
        }

    }
}