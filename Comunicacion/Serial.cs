using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Comunication
{
    public delegate void SerialCallback(string data);
    public static class Serial
    {
        static SerialPort serialPort = null;
        public static SerialCallback callback { get; set; } = (data) => { };
        public static bool Open(string portName)
        {
            try
            {
                serialPort = new SerialPort();
                serialPort.BaudRate = 115200;
                serialPort.PortName = portName;
                serialPort.Parity = Parity.None;
                serialPort.DataBits = 8;
                serialPort.StopBits = StopBits.One;
                serialPort.ReadBufferSize = 2000000;
                serialPort.DataReceived += Receive;
                serialPort.Open();
                Console.WriteLine("Connected to " + portName);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public static bool Close()
        {
            try
            {
                serialPort.Close();
                Console.WriteLine("Disconnected from " + serialPort.PortName);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public static string[] GetPorts()
        {
            return SerialPort.GetPortNames();
        }

        public static void Send(string data)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            try
            {
                Console.WriteLine(time + " Sending: " + data);
                if (serialPort == null)
                    throw new Exception("Serial not initialized");
                serialPort.WriteLine(data);
                Console.WriteLine(time + "Sent: " + data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(time + " " + ex.ToString());
            }
        }
        private static void Receive(object sender, SerialDataReceivedEventArgs e)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            try
            {
                string data = serialPort.ReadLine();
                Console.WriteLine(time + "Received: " + data);
                callback(data);
            }
            catch(Exception ex)
            {
                Console.WriteLine(time + " " + ex.ToString());
            }
        }
    }
}
