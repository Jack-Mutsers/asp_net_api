using Entities.Models;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace API.External
{
    public class ArduinoConnector
    {
        const int PORT_NO = 8088;
        const string SERVER_IP = "192.168.43.210";
        public bool Send_Data(Component comp, Category cat)
        {
            string ip_Adress = "192.168.43.210";//comp.ip_adress;

            //---data to send to the server---
            string textToSend = "";

            if (cat.name == "Lamp")
            {
                switch (comp.value)
                {
                    case 1:
                        textToSend = "LED-OFF";
                        break;
                    case 0:
                        textToSend = "LED-ON";
                        break;
                }
            }
            else if (cat.name == "Deur")
            {
                switch (comp.value)
                {
                    case 1:
                        textToSend = "DOOR-CLOSE";
                        break;
                    case 0:
                        textToSend = "DOOR-OPEN";
                        break;
                }
            }
            else if (cat.name == "Lock")
            {
                switch (comp.value)
                {
                    case 1:
                        textToSend = "LOCK-CLOSE";
                        break;
                    case 0:
                        textToSend = "LOCK-OPEN";
                        break;
                }
            }
            else
            {
                switch (comp.value)
                {
                    case 1:
                        textToSend = "WINDOW-CLOSE";
                        break;
                    case 0:
                        textToSend = "WINDOW-OPEN";
                        break;
                }
            }

            //---create a TCPClient object at the IP and port no.---
            TcpClient client = new TcpClient(ip_Adress, PORT_NO);
            NetworkStream nwStream = client.GetStream();
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);

            //---send the text---
            Console.WriteLine("Sending : " + textToSend);
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);

            client.Close();
            return true;
        }
    }
}
