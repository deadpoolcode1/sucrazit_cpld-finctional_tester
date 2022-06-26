using System;

namespace sucrazit // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var serPort = new Serial_c();

            serPort.serialPortFind(Const.port_detect_msg_send, Const.port_detect_msg_rcv);
        }
    }

    public static class Const
    {
        public const string port_detect_msg_send = "";
        public const string port_detect_msg_rcv = "";
    }
}