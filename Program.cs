using System;

namespace sucrazit // Note: actual namespace depends on the project name.
{
    internal class Program
    {

        static void Main(string[] args)
        {
            String port_name = "";
            Console.WriteLine("Hello World!");

            port_name = Serial_c.serialPortFind(Const.port_detect_msg_send, "");
            var m_Command = new Commands();
            m_Command.controller_set_gpio(GpioGroupConst.A, 1);
            m_Command.controller_get_gpio(GpioGroupConst.A, 1);
            var msgGpioIn = new Tuple<int, int>(GpioGroupConst.A, 1);
            var msgGpioOut = new Tuple<int, int>(GpioGroupConst.B, 2);
            Serial_c.Connect(port_name);
            m_Command.send_test(msgGpioIn, msgGpioOut);
            Serial_c.Disconnect();
        }
    }

    public static class Const
    {
        public const string port_detect_msg_send = "";
        public const string port_detect_msg_rcv = "";
    }
}