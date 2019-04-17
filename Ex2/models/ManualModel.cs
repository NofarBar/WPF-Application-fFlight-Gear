using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2.models
{
    public class ManualModel
    {
        public Commands command;
        public ManualModel()
        {
            this.command = Commands.commandInstance;
        }

        public void sentToClient(string input)
        {
            this.command.connect();
            this.command.sendCommand(input);
            this.command.disconnect();
        }
    }
}
