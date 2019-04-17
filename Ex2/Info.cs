using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Ex2
{
    class Info
    {
        private string ip;
        private int port;
        private IPEndPoint ep;
        private TcpListener server;
        private static Info instance = null;
        private bool isConnect = false;
        private string flightValues;
        private Info()
        {
            flightValuesP = "";
            
        }
        public string flightValuesP
        {
            get { return this.flightValues; }
            set { this.flightValues = value; }
        }
        public static Info infoInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Info();
                }
                return instance;
            }
        }
        public void clientConection() {
            Console.WriteLine("Waiting for client connections...");
            TcpClient client=null;
            try
            { 

                    client = server.AcceptTcpClient();
                    Console.WriteLine("Client connected");
                    isConnect = true;
                using (NetworkStream stream = client.GetStream())
                    using (StreamReader reader = new StreamReader(stream))
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        while (isConnection())
                        {
                            flightValuesP = reader.ReadLine();
                            writer.Flush();
                            Thread.Sleep(1000);

                        }
                    }
                }
            catch (System.Exception)
            {

            }
           // client.Close();
        }
        public void connect()
        {
            if (!isConnect)
            {
                this.ip=models.ApplicationSettingsModel.Instance.FlightServerIP;
                this.port = models.ApplicationSettingsModel.Instance.FlightInfoPort;
                Console.WriteLine("Waiting");
                ep = new IPEndPoint(IPAddress.Parse(this.ip), port);
                server = new TcpListener(ep);
                server.Start();
                Console.WriteLine("You are connected server");
            }
            clientConection();
        }

        public bool isConnection()
        {
            return isConnect;
        }
        public void disconnect()
        {
            if (isConnect)
            {
                server.Stop();
            }
        }
    }
}
