/*
 * @Author Niels de Boer
 * @Date 18-03-20
 * 
 * This file contains two classes:
 * Serial:
 *      The serial class manages the connection with a serial device
 * SerialData:
 *      The serial data class represents an incoming ADC value
 */
using System;
using System.IO.Ports;
using ScopeOnMicrocontroller.Messages;

namespace ScopeOnMicrocontroller
{
    class Serial
    {
        private SerialPort _serialPort;
        private IncomingMessage CurrentMessage = null;
        private static Serial Instance;
        public delegate void ADCSerialDataReceivedHandler(IncomingMessage incomingADC);
        public event ADCSerialDataReceivedHandler ADCSerialDataReceived;

        private bool[] ChannelEnabled = new bool[] { false, false };
        

        /// <summary>
        /// Returns wether the serialport is connected.
        ///  - _serialPort is not null
        ///  - _serialPort.IsOpen is true
        /// </summary>
        public bool IsConnected { 
            get {
                return _serialPort != null && _serialPort.IsOpen;
            }
        }

        private Serial()
        {
            // NOOP
        }

        /// <summary>
        /// Get the instance of the serial class
        /// </summary>
        /// <returns>Instance</returns>
        public static Serial GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Serial();
            }

            return Instance;
        }

        /// <summary>
        /// Connect to a serial port
        /// </summary>
        /// <exception cref="System.IO.IOException">On open error</exception>
        /// <param name="comName">The com name to use</param>
        /// <param name="baudrate">The baud rate to use</param>
        public void Connect(string comName, int baudrate)
        {
            // Disconnect the current device
            Disconnect();

            // Create new instance of serialport class
            _serialPort = new SerialPort(comName, baudrate, Reference.PARITY, Reference.DATA_BITS, Reference.STOP_BITS);

            // Add event listener for new data
            _serialPort.DataReceived += _serialPort_DataReceived;

            // Open the connection
            _serialPort.Open();

            // Set both scopes to the default value
            SetScopeEnabled(false, false);
        }

        

        /// <summary>
        /// The event listener for new serial data
        /// - Processes the incoming data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                // Do until there is no data left to read
                while (_serialPort.IsOpen && _serialPort.BytesToRead > 0)
                {
                    int dataIn = _serialPort.ReadByte();

                    if (CurrentMessage == null)
                    {
                        if (dataIn == IncomingADC.START_BYTE)
                        {
                            CurrentMessage = new IncomingADC();
                        }
                        else if (dataIn == IncomingTimerOverflow.START_BYTE)
                        {
                            CurrentMessage = new IncomingTimerOverflow();
                        }
                    }
                    else
                    {
                        CurrentMessage.AddByte((byte)dataIn);
                    }

                    if (CurrentMessage != null && CurrentMessage.BytesNeeded == 0)
                    {
                        CurrentMessage.Done();
                        ADCSerialDataReceived(CurrentMessage);
                        CurrentMessage = null;
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }

        /// <summary>
        /// Disconnect the serial port connection.
        /// Also disables the ADC's
        /// </summary>
        public void Disconnect()
        {
            if (_serialPort != null)
            {
                if (_serialPort.IsOpen)
                {
                    SetScopeEnabled(false, false);
                    _serialPort.Close();
                }

                _serialPort.Dispose();
                _serialPort = null;
            }
        }

        /// <summary>
        /// Enable/disable the scopes that are on the devices
        /// </summary>
        /// <param name="channel1Enabled">Is channel 1 enabled?</param>
        /// <param name="channel2Enabled">Is channel 2 enabled</param>
        public void SetScopeEnabled(bool channel1Enabled, bool channel2Enabled)
        {
            // Create the message to send
            // The two LSB determine wether the channels are enabled
            // 0bMMMMMMxy
            // M = message code
            // x = channel 2 enabled (1=enabled, 0=disabled)
            // y = channel 1 enabled (1=enabled, 0=disabled)
            int messageToSend = Reference.MSG_ENABLE_ADC + Convert.ToByte(channel1Enabled) + (Convert.ToByte(channel2Enabled) << 1);

            SendMessage((byte)messageToSend);
        }

        public void EnableChannel(int channel, bool enabled)
        {
            ChannelEnabled[channel] = enabled;

            SetScopeEnabled(ChannelEnabled[0], ChannelEnabled[1]);
        }

        /// <summary>
        /// Send a message to the connected device
        /// </summary>
        /// <param name="message">The message that will be sent</param>
        public void SendMessage(byte message)
        {
            if (IsConnected)
            {
                _serialPort.Write(new byte[] { message }, 0, 1);
            }
        }
    }
}
