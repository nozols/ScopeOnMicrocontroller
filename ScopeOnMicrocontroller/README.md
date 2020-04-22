## Incoming messages

Incoming messages have pre-determined length and a start byte, which is called a message
identifier. Once the client has received a message identifier it will use the next incoming
bytes as the body of the message. Once a message is completed it waits for the next message
identifier.

### ADC measurement

A message that contains an ADC measurement send by the ATmega is five bytes long and
contains the following data:

 * Message identifier
 * The channel number (0 or 1)
 * A 16-bit timestamp
 * A 12-bit measurement

The measurement is structured in the following way:

```
0b11001100 0bTTTTTTTT 0bTTTTTTTT 0b000CMMMM 0bMMMMMMMM
```

Where `T` is a timestamp bit, `C` is the channel bit and `M` is a measurement bit.
`0b11001100` is the message identifier for the ADC measurement message.

It is necessary to send a timestamp with the message, because it is unreliable to rely 
on the OS's timing.

### Timer overflow

The second message that can be send by the ATmega is a timer overflow message.
This message indicates that the timer has reset to zero