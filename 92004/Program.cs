using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace _92004
{
    internal class Program
    {
        // Golad variables
        static float totalInsurance = 0;
        static int num1 = (int)0.95;

        // Methods
        static int Months(float costDevice,string deviceName,int num1)
        {
            // Display value lost of 6 months
            
           int months = Convert.ToInt32(($"{deviceName}'s Value over 6 months\n1.{costDevice * num1}\n2.{costDevice * num1}\n3.{costDevice * num1}\n4.{costDevice * num1}\n5.{costDevice * num1}\n6.{costDevice * num1}\n"));
            return months;

        }



        // Sum up everything
        static string Summary(string deviceName, float insuranceCost,string deviceCategory,float costDevice, int numDevice,int months)
        {
            string insuranceDetails = string.Join(", ", totalInsurance);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            return "---- Summary ---- \n" +
                $"Device Name: {deviceName}\n" +
                $"Insurance: ${insuranceCost}\n" +
                $"Categroy: {deviceCategory}\n" +
                $"total Cost of device: ${numDevice * costDevice}\n" +
                $"Number of Devices: {numDevice}\n" +
                $"Device value lost over six months: ${months}\n";
            

        }

        

        // Checks the ategory to see if they are between 1 and 3 and Error if they are below or highter
        static int CheckCategory()
        {
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Plase pick the Category of your device(S)\n1.Laptops\n2.Decktops\n3.Other");
                    int deviceCategory = Convert.ToInt32(Console.ReadLine());

                    if (deviceCategory == 1 && deviceCategory == 3)
                    {
                        return deviceCategory;
                    }
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Error plase enter number between 1 and 3");
                }

                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Error: You must enter a valid number");
                }

            }
            
              

        }


        static string CheckProceed()
        {
            string proceed;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("press <Enter> to add another Device type 'STOP' to quit");
                proceed = Console.ReadLine().ToUpper();

                if (proceed.Equals("") || proceed.Equals("STOP"))
                {
                    return proceed;
                }
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Error: Invaild input");

            }
        }

        // calculate the Insurance
        static float CalInsurance(float costDevice, int numDevice)
        {
            int num = 5;

            if (numDevice <= 5)
            {
                // Calculate Insurance if it is 5 or lass
                float totalInsurance = costDevice * numDevice;
                return totalInsurance;
            }
            else
            {
                // Calculate NewnumDevice
                int NewNumDevice = numDevice - num;
                // Calculate Insurance
                float Insurance = costDevice * 0.9f * NewNumDevice;
                float AddInsurance = costDevice * num;
                float totalInsurance = Insurance + AddInsurance;
                return totalInsurance;

            }

        }



        //Ceate OneDevice
        static void OneDevice()
        {

            // enter category of devices
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Plase pick the Category of your device(S)\n1.Laptops\n2.Decktops\n3.Other");
            string deviceCategory = Console.ReadLine();


            // enter name of devices
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("plase enter the name of device(S)");
            string deviceName = Console.ReadLine();


            // enter number of devices
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("plase enter the number of device(S)");
            string numDevice = Console.ReadLine();
            int number = Convert.ToInt32(numDevice);

            // enter cost of devices
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("plase enter the cost of each device or devices");
          
            float costDevice = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);
           



            // Display summary
            Console.WriteLine(Summary(deviceName,CalInsurance(costDevice,Convert.ToInt32(numDevice)),deviceCategory,costDevice,Convert.ToInt32(numDevice)),Months(costDevice,deviceName,num1));
          
        }



        // When Run 
        static void Main(string[] args)
        {
            //Display Title
            Console.ForegroundColor = ConsoleColor.DarkBlue;
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
