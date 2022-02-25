using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;

namespace ControlRiego
{
    public delegate void SerialCallback(int radio, int solenoide, char accion);
    public static class Serial
    {
        static SerialPort serialPort = null;
        public static SerialCallback defaultCallback { get; set; } = (radio, solenoide, accion) => { };
        public static SerialCallback callback { get; set; } = (radio, solenoide, accion) => { };
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
                using (StreamWriter sw = File.AppendText("console.log"))
                {
                    Console.WriteLine("Connected to " + portName);
                    sw.WriteLine("Connected to " + portName);
                }
                return true;
            }
            catch (Exception ex)
            {
                Util.Log(ex.ToString());
                return false;
            }
        }
        public static bool Close()
        {
            try
            {
                serialPort.Close();
                Util.Log("Disconnected from " + serialPort.PortName);
                return true;
            }
            catch (Exception ex)
            {
                Util.Log(ex.ToString());
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
                Util.Log(time + " Sending: " + data);

                if (serialPort == null)
                    throw new Exception("Serial not initialized");

                serialPort.WriteLine(data);
                Util.Log(time + " Sent: " + data);
            }
            catch (Exception ex)
            {
                Util.Log(time + " " + ex.ToString());
            }
        }
        private static void Receive(object sender, SerialDataReceivedEventArgs e)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            try
            {
                string data = serialPort.ReadLine();
                data = data.Substring(0, data.Length - 1);
                Util.Log(time + " Received (" + data.Length + "): '" + data + "'");

                if (data.Length == 5)
                {
                    int radio = data[1] - '@';
                    int solenoide = data[2] - '@';
                    char accion = data[3];

                    if (solenoide == '@' && accion == 'V')
                        BaseDatos.CrearLog(new Log() { Tipo = "Bateria Baja", Info = "La radio " + radio + " ha informado baja batería" });
                    else
                        callback(radio, solenoide, accion);
                }
            }
            catch(Exception ex)
            {
                Util.Log(time + " " + ex.ToString());
            }
        }
    }
}
