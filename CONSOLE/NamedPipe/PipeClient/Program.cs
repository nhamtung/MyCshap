using System;
using System.IO.Pipes;

namespace PipeClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var stream = new NamedPipeClientStream("FooPipe"))
            {
                stream.Connect();

                var buffer = new byte[1000];
                // read received data into buffer
                stream.Read(buffer, 0, 1000);

                Console.WriteLine(GetString(buffer));
            }

            Console.Read();
        }

        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
    }
}
