/*
 * @Author Niels de Boer
 * @Date 18-03-20
 * 
 * This file contains reference values that can be used during runtime.
 */
using System.Collections.Generic;
using System.IO.Ports;

namespace ScopeOnMicrocontroller
{
    class Reference
    {
        /// <summary>
        /// This dictionary can be used to convert SI-seconds to a factor
        /// </summary>
        public static readonly Dictionary<string, double> TimePrefixFactors = new Dictionary<string, double>() {
            {"ns", 1e-9 },
            {"us", 1e-6 },
            {"ms", 1e-3 },
            {"s", 1 },
        };

        /// <summary>
        /// This dictionary could be used to format the labels on the x-axis
        /// </summary>
        public static readonly Dictionary<string, string> TimePrefixFormatters = new Dictionary<string, string>()
        {
            {"ns", "" },
            {"us", "" },
            {"ms", "" },
            {"s", "" },
        };

        /// <summary>
        /// This dictionary can be used to convert SI-volts to a factor
        /// </summary>
        public static readonly Dictionary<string, double> VoltagePrefixFactors = new Dictionary<string, double>
        {
            {"uV", 1e-6 },
            {"mV", 1e-3 },
            {"V", 1 },
        };

        /// <summary>
        /// The baudrate that will be used to communicate with the device
        /// </summary>
        public const int BAUD_RATE = 256000;

        /// <summary>
        /// The parity that will be used to communicate with the device
        /// </summary>
        public const Parity PARITY = Parity.None;

        /// <summary>
        /// The amount of stopbits that will be used to communicate with the device
        /// </summary>
        public const StopBits STOP_BITS = StopBits.One;

        /// <summary>
        /// The amount of data bits that will be read and send to the device
        /// </summary>
        public const int DATA_BITS = 8;

        /// <summary>
        /// The maximum possible voltage of the ADC
        /// </summary>
        public const double MAX_ADC_VOLTAGE = 3.3;

        /// <summary>
        /// The message code for enabling/disabling ADC channels
        /// Format: 0bMMMMMMxy
        /// M = message code
        /// x = channel 2 enabled (1=enabled, 0=disabled)
        /// y = channel 1 enabled (1=enabled, 0=disabled)
        /// </summary>
        public const byte MSG_ENABLE_ADC = 0b10101100;

        /// <summary>
        /// The message for starting a bode plot (this must be followed by the configuration)
        /// FORMAT: 0b1101101x
        /// x = DSP enabled
        /// </summary>
        public const byte MSG_START_BODE = 0b11011010;

        public const byte MSG_DEBUG_MSG = 0b01101101;

        /// <summary>
        /// Determine the factor for the timestamp (in seconds).
        /// Currently the factor is 100 us.
        /// This means that 1 count equals 100us
        /// </summary>
        public const double TIMESTAMP_FACTOR = 0.0001;
    }
}
