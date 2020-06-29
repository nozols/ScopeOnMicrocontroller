/*
 * @Author Niels de Boer
 * 
 * Base class for incoming messages from the serial port
 */

namespace ScopeOnMicrocontroller.Messages
{
    public abstract class IncomingMessage
    {

        protected byte[] ReceivedBytes;

        /// <summary>
        /// The amounts of bytes that this message has already received (excluding start byte)
        /// </summary>
        protected int ReceivedBytesCount = 0;

        /// <summary>
        /// The amount of bytes that is still needed to complete this message
        /// </summary>
        public int BytesNeeded
        {
            get
            {
                return GetMessageSize() - ReceivedBytesCount;
            }
        }

        public IncomingMessage()
        {
            ReceivedBytes = new byte[GetMessageSize()];
        }

        /// <summary>
        /// Get the amount of bytes this message requires
        /// </summary>
        /// <returns>Message byte count</returns>
        protected abstract int GetMessageSize();

        /// <summary>
        /// Get the start byte
        /// </summary>
        /// <returns>Start byte</returns>
        protected abstract byte GetStartByte();

        /// <summary>
        /// Called when all bytes are received
        /// </summary>
        public abstract void Done();

        /// <summary>
        /// Add a byte to this message
        /// </summary>
        /// <param name="data">The byte to add</param>
        public void AddByte(byte data)
        {
            ReceivedBytes[ReceivedBytesCount] = data;
            ReceivedBytesCount++;
        }

        /// <summary>
        /// Determine wether this message is finished
        /// By default it is finished if there are no more bytes needed
        /// </summary>
        /// <returns></returns>
        public virtual bool IsFinished()
        {
            return BytesNeeded == 0;
        }

    }
}
