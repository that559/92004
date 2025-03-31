using System.Diagnostics;
using System.Globalization;

namespace _92004
{
    internal class Program
    {
        // Golad variables



        // Methods

        static string CheckProceed()
        {
            string proceed;

            while (true)
            {
                Console.WriteLine("press <Enter> to add another Device type 'STOP' to quit");
                proceed = Console.ReadLine().ToUpper();

                if (proceed.Equals("") || proceed.Equals("STOP"))
                {
                    return proceed;
                }
                Console.WriteLine("Error: Invaild input");

            }
        }

        // cals the Insurance
        static float CalInsurance(float costDevice, int numDevice,int num1)
        {
            num1 = 5;

            if (numDevice <= 5)
            {
                // Calculate Insurance if it is 5 or lass
                float totalInsurance = costDevice * numDevice;
                return totalInsurance;
            }
            else
            {
                // Calculate NEWnumDevice
                int NewNumDevice = numDevice - num1;
                // Calculate Insurance
                float totalInsurance = costDevice * 0.9f * NewNumDevice;
                float AddInsurance = costDevice * num1;
                float ppotato = totalInsurance + AddInsurance;
                return ppotato;

            }

        }



        //Ceate OneDevice

        static void OneDevice()
        {

            // enter category of devices
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Plase pick the Category of your device(S)\n1.Laptops\n2.Decktops\n3.Other");
            string deviceCategory = Console.ReadLine();

            // enter name of devices
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Plase enter the name of your device(S)");
            string deviceName = Console.ReadLine();

            // enter number of devices
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("plase enter the number of device(S)");
            string numDevice = Console.ReadLine();
            int number = Convert.ToInt32(numDevice);

            // enter cost of devices
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("plase enter the cost of device(S)");
          
            float costDevice = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);


        }





        // When Run 
        static void Main(string[] args)
        {
            //Display Title
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" ___                                               _                \r\n|_ _|_ __  ___ _   _ _ __ __ _ _ __   ___ ___     / \\   _ __  _ __  \r\n | || '_ \\/ __| | | | '__/ _` | '_ \\ / __/ _ \\   / _ \\ | '_ \\| '_ \\ \r\n | || | | \\__ \\ |_| | | | (_| | | | | (_|  __/  / ___ \\| |_) | |_) |\r\n|___|_| |_|___/\\__,_|_|  \\__,_|_| |_|\\___\\___| /_/   \\_\\ .__/| .__/ \r\n                                                       |_|   |_|    ");
            
         
            string proceed = "";
            while (proceed.Equals(""))
            {
                // Call OneDevice Method
                OneDevice();
                   
                proceed = CheckProceed();
               
            }
        }
    }
}
