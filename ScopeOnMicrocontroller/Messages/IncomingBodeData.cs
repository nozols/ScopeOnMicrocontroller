/*
 * @Author Niels de Boer
 * 
 * Class that handles incoming data for the bode plot
 */

namespace ScopeOnMicrocontroller.Messages
{
    public class IncomingBodeData : IncomingMessage
    {
        public static readonly int MESSAGE_SIZE = 4;
        public static readonly byte START_BYTE = 0b11100011;

        public int Frequency
        {
            get
            {
                // First two bytes state the frequency
                return (ReceivedBytes[0] << 8) + ReceivedBytes[1];
            }
        }

        public double RelativeAmplitude
        {
            get
            {
                // The last two bytes state the relative amplitude,
                // Divide by 10000 to put the decimal point back to the right place
                return ((double)((ReceivedBytes[2] << 8) + ReceivedBytes[3])) / 10000;
            }
        }

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

        public override string ToString()
        {
            return string.Format("BodeData: {0} Hz => {1}", Frequency, RelativeAmplitude);
        }
    }
}
