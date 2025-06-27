# Redbox MQTT Server Recration

## What is it?
The Redbox MQTT Server is responsible for the update client for sending commands and configuration to the redbox machine
The configuration is stored at `C:\ProgramData\Redbox\Configuration\Configuration.json`

## Setup
Build the code using MQTTNet 3.1.1 on .net core 6.0
then after that place your Server.pfx in the same folder as the exe just make sure it has no password.


One more thing make sure the certificate's root is trusted in windows and also make sure it has CRL or OCSP some method of checking for
revocation or else updateclient will reject the certificate.
