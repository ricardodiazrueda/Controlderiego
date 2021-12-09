using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Comunicacion
{
    public delegate void SerialCallback(string data);
    public class Serial
    {
        SerialPort serialPort = null;
        SerialCallback callback;

        public Serial()
        {
            callback = (data) => { };
        }
        public Serial(SerialCallback callback)
        {
            this.callback = callback;
        }

        public string Open(string portName)
        {
            serialPort = new SerialPort();
            serialPort.BaudRate = 115200;
            serialPort.PortName = portName;
            serialPort.Parity = Parity.None;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            serialPort.ReadBufferSize = 2000000;
            serialPort.DataReceived += Receive;
            
            try
            {
                serialPort.Open();
                return "Connected to " + portName;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Close()
        {
            try
            {
                serialPort.Close();
                return "Disconnected to " + serialPort.PortName;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }


        public string[] GetPorts()
        {
            return SerialPort.GetPortNames(); ;
        }

        public void Send(string data)
        {
            serialPort.WriteLine(data);
        }
        private void Receive(object sender, SerialDataReceivedEventArgs e)
        {
            string data = serialPort.ReadLine();
            callback(data);
        }
    }
}
