using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Ex2
{
    public class AutoPilotModel
    {
        public Brush color = new SolidColorBrush(Colors.White);
        private string[] commandsArray;
        public void sendLines()
        {
            Commands client = Commands.commandInstance;
            if (!client.isConnection())
            {
                client.connect();
            }
            int len = commandsArray.Length;
            for (int i = 0; i < len; i++)
            {
                client.sendCommand(commandsArray[i]);
                Console.WriteLine(commandsArray[i]);
                Thread.Sleep(2000);
            }
            color= new SolidColorBrush(Colors.White);
            client.disconnect();
        }
        public void sendCommand(string[] command)
        {
            this.commandsArray = command;
            Thread thread = new Thread(new ThreadStart(sendLines));            thread.Start();
        }
    }
}
