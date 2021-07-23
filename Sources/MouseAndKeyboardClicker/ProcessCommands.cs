using System.Threading;
using WindowsInput.Native;
using System;

namespace AutoClickerMouseAndKeyboard
{
    public struct ProcessCommands
    {
        private static void ProcessOneCommand(OneCommand thisCommand)
        {
            switch (thisCommand.CommandTypes)
            {
                case ListCommandTypes.Rightclick: 
                    Thread.Sleep(thisCommand.Delay);
                    Rightclick(thisCommand.CursorPoint.X , thisCommand.CursorPoint.Y); 
                    break;
                case ListCommandTypes.DoubleLeftClick:
                    Thread.Sleep(thisCommand.Delay);
                    DoubleLeftClick(thisCommand.CursorPoint.X , thisCommand.CursorPoint.Y);
                    break;
                case ListCommandTypes.RightDoubleClick:
                    Thread.Sleep(thisCommand.Delay);
                    RightDoubleClick(thisCommand.CursorPoint.X , thisCommand.CursorPoint.Y);
                    break;
                case ListCommandTypes.LeftClickDown:
                    Thread.Sleep(thisCommand.Delay);
                    LeftClickDown(thisCommand.CursorPoint.X , thisCommand.CursorPoint.Y);
                    break;
                case ListCommandTypes.LeftClickUp:
                    Thread.Sleep(thisCommand.Delay);
                    LeftClickUp(thisCommand.CursorPoint.X , thisCommand.CursorPoint.Y);
                    break;
                case ListCommandTypes.LeftClick:
                    Thread.Sleep(thisCommand.Delay);
                    LeftClick(thisCommand.CursorPoint.X , thisCommand.CursorPoint.Y);
                    break;
                case ListCommandTypes.MousePosition:
                    Thread.Sleep(thisCommand.Delay);
                    MousePosition(thisCommand.CursorPoint.X , thisCommand.CursorPoint.Y);
                    break;
                case ListCommandTypes.ParagraphType:
                    Thread.Sleep(thisCommand.Delay);
                    ParagraphType(thisCommand.ParagraphType);
                    break;
                default:
                    Console.WriteLine("This value is not Undefined!\nValue:"+Enum.GetName(typeof(ListCommandTypes),(int)thisCommand.CommandTypes));
                    RestartProgram();
                    break;
            }
        }
        
        /// <summary>
        /// To right click.
        /// </summary>
        /// <param name="posX">Position of cursor x-axis</param>
        /// <param name="posY">Position of cursor y-axis</param>
        private static void Rightclick(uint posX , uint posY){
            VirtualMouse.sendMouseRightclick(new Point(posX , posY));
        }
        
        /// <summary>
        /// To double left click.
        /// </summary>
        /// <param name="posX">Position of cursor x-axis</param>
        /// <param name="posY">Position of cursor y-axis</param>
        private static void DoubleLeftClick(uint posX , uint posY){
            VirtualMouse.sendMouseDoubleLeftClick(new Point(posX , posY));
        }
        
        /// <summary>
        /// To right double click
        /// </summary>
        /// <param name="posX">Position of cursor x-axis</param>
        /// <param name="posY">Position of cursor y-axis</param>
        private static void RightDoubleClick(uint posX , uint posY){
            VirtualMouse.sendMouseRightDoubleClick(new Point(posX , posY));
        }
        
        /// <summary>
        /// To left click down
        /// </summary>
        /// <param name="posX">Position of cursor x-axis</param>
        /// <param name="posY">Position of cursor y-axis</param>
        private static void LeftClickDown(uint posX , uint posY){
            VirtualMouse.sendMouseLeftClickDown(new Point(posX , posY));
        }
        
        /// <summary>
        /// To left click up
        /// </summary>
        /// <param name="posX">Position of cursor x-axis</param>
        /// <param name="posY">Position of cursor y-axis</param>
        private static void LeftClickUp(uint posX , uint posY){
            VirtualMouse.sendMouseLeftClickUp(new Point(posX , posY));
        }

        /// <summary>
        /// To left click 
        /// </summary>
        /// <param name="posX">Position of cursor x-axis</param>
        /// <param name="posY">Position of cursor y-axis</param>
        private static void LeftClick(uint posX, uint posY)
        {
            VirtualMouse.sendMouseLeftClick(new Point(posX , posY));
        }
        
        /// <summary>
        /// To set mouse position
        /// </summary>
        /// <param name="posX">Position of cursor x-axis</param>
        /// <param name="posY">Position of cursor y-axis</param>
        private static void MousePosition(uint posX , uint posY){
            VirtualMouse.sendMousePosition(new Point(posX , posY));
        }
        
        /// <summary>
        /// To type text.
        /// </summary>
        /// <param name="text">Text to type</param>
        private static void ParagraphType(string text)
        {
            Virtual_Keyboard.Type(text);
        }

        /// <summary>
        /// To restart all of program values.
        /// </summary>
        private static void RestartProgram()
        {
            Command_INI.RestartProgram();
        }
    }
}