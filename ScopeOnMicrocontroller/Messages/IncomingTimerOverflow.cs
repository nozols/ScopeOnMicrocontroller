using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScopeOnMicrocontroller.Messages
{
    class IncomingTimerOverflow : IncomingMessage
    {

        public static readonly int MESSAGE_SIZE = 0;
        public static readonly byte START_BYTE = 0b00110011;

        public override void Done()
        {
            // NOOP
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
