/*
 * @Author Niels de Boer
 * 
 * This message contains a timestamp and an measured value.
 * Be aware that the timestamp must be adjusted for the overflow timer
 */
using System;

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
        /// The time at which measurements were started
        /// </summary>
        private double StartTime = 0;

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

                return (double)rawTimestamp * Reference.TIMESTAMP_FACTOR - StartTime;
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

        public override void Done()
        {
            // NOOP
        }

        /// <summary>
        /// Set the amount of times the 100us counter has overflown
        /// </summary>
        /// <param name="timerOverflows">Amount of overflows</param>
        public void SetTimerOverflows(int timerOverflows)
        {
            TimerOverflows = timerOverflows;
        }

        /// <summary>
        /// Set the time at which the graphs start
        /// </summary>
        /// <param name="startTime">Time</param>
        public void SetStartTime(double startTime)
        {
            StartTime = startTime;
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
