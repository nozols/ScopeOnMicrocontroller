using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScopeOnMicrocontroller.Messages
{
    class IncomingStartBode : IncomingMessage
    {

        public static readonly int MESSAGE_SIZE = 5;
        public static readonly byte START_BYTE = Reference.MSG_START_BODE;

        public override void Done()
        {
            byte[] t = ReceivedBytes;
            foreach (byte b in t)
            {
                Console.WriteLine(b);
            }
        }

        protected override int GetMessageSize()
        {
            return MESSAGE_SIZE;
        }

        protected override byte GetStartByte()
        {
            return START_BYTE;
        }
    }
}
