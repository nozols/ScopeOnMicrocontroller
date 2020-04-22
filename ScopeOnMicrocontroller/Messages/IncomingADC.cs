using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScopeOnMicrocontroller.Messages
{
    class IncomingADC : IncomingMessage
    {
        public static readonly int MESSAGE_SIZE = 4;
        public static readonly byte START_BYTE = 0b11001100;

        /// <summary>
        /// The amount of timer overflows that have occured
        /// </summary>
        private int TimerOverflows = 0;

        /// <summary>
        /// Get the volts of this measurement
        /// </summary>
        public double Volts
        {
            get
            {
                int rawADC = ((ReceivedBytes[2] << 8) + ReceivedBytes[3]) & 0x0FFF;

                return (rawADC / Math.Pow(2, 12)) * Reference.MAX_ADC_VOLTAGE;
            }
        }

        /// <summary>
        /// Get the timestamp in seconds.
        /// One count in the timestamp equals 100 us. 
        /// </summary>
        public double Timestamp
        {
            get
            {
                int rawTimestamp = ((ReceivedBytes[0] << 8) + ReceivedBytes[1]) & 0xFFFF;

                // Add the timer 
                rawTimestamp += TimerOverflows * 65536;

                return (double)rawTimestamp * Reference.TIMESTAMP_FACTOR;
            }
        }
        
        /// <summary>
        /// Get the channel this measurement was received from
        /// </summary>
        public int Channel
        {
            get
            {
                return (ReceivedBytes[2] & 0x10) >> 4;
            }
        }

        public IncomingADC() : base()
        {

        }

        protected override int GetMessageSize()
        {
            return MESSAGE_SIZE;
        }

        protected override byte GetStartByte()
        {
            return START_BYTE;
        }

        public override void Done()
        {
            
        }

        /// <summary>
        /// This is used to calculate the timestamp
        /// </summary>
        /// <param name="timerOveflows">The amount of timeroverflows that have occured</param>
        public void SetTimerOverflows(int timerOveflows)
        {
            TimerOverflows = timerOveflows;
        }

        public override string ToString()
        {
            string byteformat = "";
            foreach (var b in ReceivedBytes)
            {
                byteformat += Convert.ToString(b, 2) + " ";
            }
            return string.Format("C:{0} D:{1} T:{2} -> {3}", Channel, Volts, Timestamp, byteformat);
        }


    }
}
