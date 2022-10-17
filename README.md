# The Integration of Biosensors into an XR Experience
_____________________________________________________
The purpose of this project is to investigate the feasibility of using biosensors in a VR setup and implementing the use of the biosensor data processing into a multimodal Extended Reality (XR) experience through the use of a continuous feedback loop to create an immersive, individualised experience.
_____________________________________________________

Project By: Eoghan O Riain
Supervised By: David Murphy
_____________________________________________________

Hardware Required:
- Myndplay EEG Biosensor with single strip electrode.
- Empatica E4 wristband.
- Shimmer3 GSR+.
- Oculus Quest 2.
- Bluegiga Bluetooth Smart Dongle.
- USB to USB-C cable (approximately 5m).

Software Required:
- Unity Game Engine (version 2021.3.5F1)
- Empatica BLE Server (http://get.empatica.com/win/EmpaticaBLEServer.html)
- ThinkGear Connector (https://store.neurosky.com/products/pc-developer-tools)
_____________________________________________________

Project Start-Up:
- Install the Empatica BLE Server and the ThinkGear Connector to the computer. 
- Open the project with Unity 2021.3.5F1.
- All the necessary scripts have been included in the project folder and applied to the appropriate in-game objects.
- Minor alterations are required to the biosensor scripts to operate it on your computer:
	1. In the ICATEmpaticaBLEClient.cs, navigate to line 121 and change the value of "connectToServer" to the BLE Server ID now installed on your computer
	2. In the ShimmerBiosignals.cs, navigate to line 93 and change the first two values contained in the brackets with the name of your shimmer device, as recognised by the computer, and the COM port number that the Shimmer connects to.
- Make sure all biosensors are switched on before the VR environment is activated.
- The Empatica E4 BLE server application must be opened on the computer and the device connected before activating the VR environment.
- Ensure the Shimmer3 GSR+ device is paired to the computer via bluetooth before activating the VR environment.

With the above steps completed, the project should operate correctly on your computer.
