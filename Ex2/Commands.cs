using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Ex2
{
    public class Commands
    {
        private string ip;
        private int port;
        private IPEndPoint ep;
        private TcpClient client;
        private static Commands instance = null;
        private bool isConnect=false;

        private  Commands()
        {
          
        }
        public static Commands commandInstance
        {
            get {
                if (instance == null) {
                    instance = new Commands();
                }
                return instance;
                }
        }
        public void connect()
        {
            if(!isConnect)
            {
                try
                {
                    this.ip = models.ApplicationSettingsModel.Instance.FlightServerIP;
                    this.port = models.ApplicationSettingsModel.Instance.FlightCommandPort;
                    ep = new IPEndPoint(IPAddress.Parse(this.ip), this.port);
                    client = new TcpClient();
                    client.Connect(ep);
                    Console.WriteLine("Command - You are connected");
                    isConnect = true;
                }
                catch (System.Exception) { }
            }
        }

        public bool isConnection()
        {
            return isConnect;
        }
        public void disconnect()
        {
            if (isConnect)
            {
                client.Close();
                isConnect = false;
            }
        }
        public void sendCommand(string command)
        {
            if (command != "")
            {
                try
                {
                    using (NetworkStream stream = client.GetStream())
                    using (StreamReader reader = new StreamReader(stream))
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.WriteLine(command);
                    }
                }
                catch (System.Exception)
                {

                }
            }
        }
    }
       
}
