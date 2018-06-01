/*
 * https://infosys.beckhoff.com/english.php?content=../content/1033/tcsample/html/tcsample_intro.htm&id=2105283098444985027
 * 
 * Function: The following program accesses a PLC variable that does not have an address. 
 * Access must therefore be made by the variable name. 
 * Once the PLC variable in the example program exceeds 10 it is reset to 0
 */

using System;
using TwinCAT.Ads;

namespace AccessByVariableName
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a new instance of class TcAdsClient
            TcAdsClient tcClient = new TcAdsClient();
            AdsStream dataStream = new AdsStream(4);
            AdsBinaryReader binReader = new AdsBinaryReader(dataStream);

            int iHandle = 0;
            int iValue = 0;

            try
            {
                // Connect to local PLC - Runtime 1 - TwinCAT2 Port=801, TwinCAT3 Port=851
                tcClient.Connect(851);

                //Get the handle of the PLC variable "PLCVar"
                iHandle = tcClient.CreateVariableHandle("MAIN.PLCVar");

                Console.WriteLine("Press enter to continue and any other key to abort..");

                do
                {
                    //Use the handle to read PLCVar
                    tcClient.Read(iHandle, dataStream);
                    iValue = binReader.ReadInt32();
                    dataStream.Position = 0;

                    Console.WriteLine("Current value is: " + iValue);

                    if (iValue >= 10)
                    {
                        //Reset PLC variable to zero
                        tcClient.WriteAny(iHandle, 0);
                    }

                } while (Console.ReadKey().Key.Equals(ConsoleKey.Enter));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
            finally
            {
                //Delete variable handle
                tcClient.DeleteVariableHandle(iHandle);
                tcClient.Dispose();
            }
        }
    }
}
