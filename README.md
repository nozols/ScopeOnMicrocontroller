# Scope On Microcontroller

This program makes an oscilloscope, function generator and a spectrum analyser of your ESP32!

# Installation
1. Install the [latest release](https://github.com/nozols/ScopeOnMicrocontroller/releases) of this program on your computer.
2. Program your ESP32 with the firmware found [here](https://gist.github.com/nozols/a7139cf9974f557dd14e37aab96a9bf0). This can be done using the Arduino IDE.
    - You can modify the digital filter by modifying the method `digitalFilter`
    - You can modify the function generator by modifying the method `generateWave`
3. Start the program, connect to your ESP32 and measure some signals!

# Usage
## Oscilloscope
The oscilloscope has two channels. Channel 1 is the signal that has been measured on the configured `ANALOG_IN_PIN` and channel 2 is the same signal, but passed through the method `digitalFilter` and thus is a filtered signal.

## Function generator
The function generator generates a signal on the configured `ANALOG_OUT_PIN`. If you want to see this signal on the scope you must connect `ANALOG_IN_PIN` and `ANALOG_OUT_PIN` physically.

## Spectrum analyser
The spectrum analyser analyses the amplification on the set spectrum. For this to work, the `ANALOG_OUT_PIN` and `ANALOG_IN_PIN` should be connected. On the `ANALOG_OUT_PIN` the set spectrum is generated and the amplification is measured on the `ANALOG_IN_PIN`.
<img width="600px" src="https://user-images.githubusercontent.com/6298632/86031506-30537e80-ba36-11ea-9d0c-6242126d2c5f.png" />
# Things to keep in mind
Please update and configure the COM-drivers as shown in the following image:
<img width="600px" src="https://user-images.githubusercontent.com/6298632/81012434-d5e4da00-8e59-11ea-9f9d-fe8accf6cd8a.png" />
