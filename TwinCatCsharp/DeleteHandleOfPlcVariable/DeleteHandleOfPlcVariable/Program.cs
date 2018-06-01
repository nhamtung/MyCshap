/*
 * https://infosys.beckhoff.com/english.php?content=../content/1033/tcsample/html/tcsample_intro.htm&id=2105283098444985027
 * 
 * Function: delete a handle of a PLC variable
 */

using System;
using TwinCAT.Ads;

namespace DeleteHandleOfPlcVariable
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Create a new instance of class TcAdsClient
            TcAdsClient tcClient = new TcAdsClient();
            int iHandle = 0;

            try
            {
                // Connect to local PLC - Runtime 1 - TwinCAT2 Port=801, TwinCAT3 Port=851
                tcClient.Connect(851);

                //Get the handle of the PLC variable "PLCVar"
                iHandle = tcClient.CreateVariableHandle("MAIN.PLCVar");

                //Release the specific handle of "PLCVar"
                tcClient.DeleteVariableHandle(iHandle);
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
