using System;
using System.IO.Pipes;

namespace PipeServer
{
    class Program
    {
        static void Main()
        {
            using (var s = new NamedPipeServerStream("FooPipe", PipeDirection.InOut))
            {
                s.WaitForConnection();

                // convert the message to byte array
                var data = GetBytes("Hello! Welcome to FooPipe Server!");
                // send data to clients
                s.Write(data, 0, data.Length);
            }

            Console.Read();
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}
