using System.ComponentModel.Design;
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
        static List<string> NumMonths = new List<string>() { "1", "2", "3", "4", "5", "6" };

        // Constant Variable
        static float lossvaule = 0.95f;
       
        // Methods
        static int checkNum(int numDevice)
        {
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("plase enter the number of device or devices");
                    int number = Convert.ToInt32(numDevice);
                    if (numDevice >= 0)
                    {
                        return numDevice;
                    }
                    Console.WriteLine("Error");
                }
                catch
                {
                    Console.WriteLine("Error: You must enter a valid number");
                }
                
            }

        }
        static float Months(float costDevice)
        {

            // Display value lost of 6 months
            foreach (var NumMonths in NumMonths)
            {

                // will only do one month and will say the same number
                float months = costDevice * lossvaule;
                return months;
            }

            return 0;

        }
        // calls the categroy you picked by the name (for Summary)
        static string CategoryName(int deviceCategory)
        {
            if (deviceCategory == 1) 
            {
                return "Laptop";
            }
            else if (deviceCategory == 2)
            {
                return "Decktop";
            }
            else
            {
                return "Other";
            }
            
        }
        

        // Sum up everything
        static string Summary(string deviceName, float insuranceCost,int deviceCategory,float costDevice, int numDevice,float months)
        {
            string insuranceDetails = string.Join(", ", totalInsurance);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            return "---- Summary ---- \n" +
                $"Device Name: {deviceName}\n" +
                $"Insurance: ${insuranceCost}\n" +
                $"Categroy: {CategoryName(deviceCategory)}\n" +
                $"total Cost of device: ${numDevice * costDevice}\n" +
                $"Number of Devices: {numDevice}\n" +
                $"Device value lost over six months:\n1:${months}\n2:${months}\n3:${months}\n4:${months}\n5:${months}\n6:${months}\n";
            

        }



        // Checks the ategory to see if they are between 1 and 3 and Error if they are below or highter
        static int CheckCategory()
        {
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Please pick the category of your device(s):\n1. Laptops\n2. Desktops\n3. Other");

                    int deviceCategory = Convert.ToInt32(Console.ReadLine()); 

                    if (deviceCategory >= 1 && deviceCategory <= 3)
                    {
                        return deviceCategory;
                    }

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Error: Please enter a number between 1 and 3.");
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Error: You must enter a valid number.");
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

                return totalInsurance ;
            }
            else
            {
                // Calculate NewnumDevice
                int NewNumDevice = numDevice - num;
                // Calculate Insurance
                float Insurance = costDevice * 0.9f * NewNumDevice;
                float AddInsurance = costDevice * num;
                return (float)Math.Round(totalInsurance = Insurance + AddInsurance, 2);
              

            }

        }



        //Ceate OneDevice
        static void OneDevice()
        {

          

            // enter name of devices
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("plase enter the name of device or devices");
            string deviceName = Console.ReadLine();


            // enter number of devices
            
          
            string numDevice = Console.ReadLine();
            int number = Convert.ToInt32(numDevice);

            // enter cost of devices
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("plase enter the cost of each device or devices");
          
            float costDevice = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);




            // Display summary
            Console.WriteLine(Summary(deviceName, CalInsurance(costDevice, Convert.ToInt32(numDevice)), CheckCategory(), costDevice, Convert.ToInt32(numDevice), Months(costDevice)));


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
