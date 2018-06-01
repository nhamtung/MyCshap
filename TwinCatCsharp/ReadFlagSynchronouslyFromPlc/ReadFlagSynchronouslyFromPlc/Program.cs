/*
 * https://infosys.beckhoff.com/english.php?content=../content/1033/tcsample/html/tcsample_intro.htm&id=2105283098444985027
 * 
 * Function: the value in flag double word 0 in the PLC is read and displayed on the screen
 */

using System;
using TwinCAT.Ads;

namespace ReadFlagSynchronouslyFromPlc
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
                tcClient.Connect(801);

                //Specify IndexGroup, IndexOffset and read SPSVar 
                int iFlag = (int)tcClient.ReadAny(0x4020, 0x0, typeof(Int32));

                Console.WriteLine("" + iFlag);
                Console.ReadKey();
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
