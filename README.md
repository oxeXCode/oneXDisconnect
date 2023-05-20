# oneXDisconnect

### Block traffic for the application using the **1xDisconnect**.

- 3 modes. 
- 3 devices.

![Imgur](https://imgur.com/4YHDzDy.png)

## Type hook
![Imgur](https://imgur.com/6URPyid.png)
1. Clamping
   + Key *pressed and hold* **block trafic** 
   + Key *up* **allow trafic** 
2. Switcher
   + When trafic *allowed and key pressed* then **block trafic** 
   + When trafic *blocked and key pressed* then **allowed trafic** 
3. Switcher
   + Key *pressed* **block trafic for a specified time**. Abort or updated the process cannot be
   + Integer only

## Rule config
![Imgur](https://imgur.com/9m0GnSF.png)
+ Filepath
  - Path to the target application.
+ Out/In
  - Blocking incoming/outgoing traffic

## Device and key
![Imgur](https://imgur.com/ahLknxX.png)
+ Device
   + Keyboard
   + Mouse
   + Controller
      + If it was connected after startup, it may require a restart. Not all buttons can be hooked.
+ Key
   + Press **EDIT** to assign/reassign hot-key to selected device. 
   + You have to press key on device on mode *bind* for update.