/*
 * @Author Niels de Boer
 * 
 * This class represents an incoming timer overflow message.
 * A timer overflow message indicates that the 100us counter on the
 * microcontroller has overflown. This means that this should be taken
 * into account when the timestamp is calculated.
 */

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
