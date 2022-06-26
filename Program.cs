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
            var m_Command = new Commands();
            m_Command.controller_set_gpio(GpioGroupConst.A, 1);
            m_Command.controller_get_gpio(GpioGroupConst.A, 1);
        }
    }

    public static class Const
    {
        public const string port_detect_msg_send = "";
        public const string port_detect_msg_rcv = "";
    }
}