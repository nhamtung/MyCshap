/*
 * 
 * https://infosys.beckhoff.com/english.php?content=../content/1033/tcsample/html/tcsample_intro.htm&id=2105283098444985027
 * 
 * Function: the value that the user has entered is written into flag double word 0
 */

using System;
using TwinCAT.Ads;

namespace WriteFlagSynchronouslyIntoPlc
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a new instance of class TcAdsClient
            TcAdsClient tcClient = new TcAdsClient();

            try
            {
                // Connect to local PLC - Runtime 1 - TwinCAT2 Port=801, TwinCAT3 Port=851
                tcClient.Connect(851);

                //Specify IndexGroup, IndexOffset and write SPSVar 
                int iNewValue = 0;
                tcClient.WriteAny(0x4020, 0x0, iNewValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
            finally
            {
                tcClient.Dispose();
            }
        }
    }
}
