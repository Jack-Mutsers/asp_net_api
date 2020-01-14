using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;

namespace API.External
{
    public class ArduinoConnector
    {
        //Private fields for use in conjuction with constructors and properties.
        private int _baudRate;
        private string _portName;
        private SerialPort port;


        //Constructors for Object instantiation.
        public ArduinoConnector()
        {

        }


        public ArduinoConnector(int baud, string portName)
        {
            this._portName = portName;
            this._baudRate = baud;
        }


        //Public properties for limiting interaction with private fields.
        public int BaudRate
        {
            get => _baudRate;
            set => _baudRate = value;
        }

        public string PortName
        {
            get => _portName;
            set => _portName = value;
        }

        //Method for opening a Serial connection with a COM-Port.
        public bool OpenConnection()
        {
            try
            {
                port = new SerialPort { BaudRate = this._baudRate, PortName = this._portName };
                port.Open();
                return true;

            }
            catch (Exception e)
            {
                e = new Exception("Can't open the serial connection to Master.\n");
                return false;
            }


        }

        //Simple method for writing a string to a Node.
        
        public bool Write(string instruction)
        {
            try
            {
                port.Write(instruction);
                System.Threading.Thread.Sleep(500);
                return true;

            }
            catch (Exception e)
            {
                e = new Exception("Can't read serial connection.\n");
                return false;
            }
        }
    }
}
