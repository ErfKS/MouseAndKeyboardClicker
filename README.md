# MouseAndKeyboardClicker

This program can use command line or \*.ini file to create timed commands for virtual input actions.

### This program include three mode:
1:Simple Mode<br>
2:Command_INI<br>
3:INI_Creator<br>

#
### Simple Mode:
#### Step One:
Move cursor to specific postition and press one of this key(R, L, k, K, F, E, P, T)
* R:RightClick
* L:Left Click
* K:Double Left Click
* F:Double Right Click
* E:Exit Rocording
* P:Set Cursor Position
* T:Paragraph Type
After that enter time delay to act this command.
#### Step Two:
After exit recording, enter date and time to start recorded commands.
#
### Command_INI:
Enter \*.ini file name to run ordered commands in this file.

### INI_Creator:
#### Step One:
Enter file name you want create.
#### Step Two:
Enter can looping value (True/False) Or (1/0)
* if it true: this file can run again.
* if it false: this file can't run again.
#### Step Three:
Enter date and time to start recorded commands. (n = now)
#### Step Three:
Enter number of command type:

0: Right click <br>
1: Double Left Click <br>
2: Right Double Click <br>
3: Left Click Down <br>
4: Left Click Up <br>
5: Left Click <br>
6: Mouse Position <br>
7: Paragraph Type <br>

#### Step Four:
Move cursor to specific position and press enter to set position of cursor.
#### Step Five:
Enter time delay to act this command.
#### Step Six:
Press 'Y' to create next step or 'N' to create your \*.ini file.
#
### Example
This is \*.ini example:
[Main] <br>
Year = n <br>
Month = n <br>
Day = n <br>
Hour = 14 <br>
Minute = 30 <br>
Second = 0 <br>
canLoop = False //False:This file can't run again        True:This file can run again <br>
Capacity = 1 //Number of 'Step' sections <br>

[Step0] <br>
Type = 5 //This is type of command (read step three) <br>
PosX = 228 //This is position of cursor in x-axis <br>
PosY = 483 //This is position of cursor in y-axis <br>
Delay = 1000 //Delay to run this 'Step' section<br>
paragraphType =  //To type a text (If 'Type' key is not equal to 7 value, this value 'paragraphType' is not working)<br>

#
Sorry if my English is not good.
