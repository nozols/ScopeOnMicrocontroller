/*
 * @Author Niels de Boer
 * 
 * Display an incoming debug message in the console
 */
using System;
using System.Linq;
using System.Text;

namespace ScopeOnMicrocontroller.Messages
{
    class IncomingDebugMessage : IncomingMessage
    {

        public static readonly int MESSAGE_SIZE = 100;
        public static readonly byte START_BYTE = Reference.MSG_DEBUG_MSG;

        public override void Done()
        {
            Console.Write(Encoding.ASCII.GetString(ReceivedBytes.Take(ReceivedBytesCount).ToArray()));
        }

        protected override int GetMessageSize()
        {
            return MESSAGE_SIZE;
        }

        protected override byte GetStartByte()
        {
            return START_BYTE;
        }

        /// <summary>
        /// This message is finished once a newline character has been received
        /// </summary>
        /// <returns></returns>
        public override bool IsFinished()
        {
            if (ReceivedBytesCount == 0)
            {
                return false;
            }
            else
            {
                return ReceivedBytes[ReceivedBytesCount - 1] == '\n';
            }
        }
    }
}
