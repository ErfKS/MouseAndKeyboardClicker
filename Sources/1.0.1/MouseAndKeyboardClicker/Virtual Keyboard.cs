using WindowsInput;

namespace AutoClickerMouseAndKeyboard
{
    public static class Virtual_Keyboard
    {
        /// <summary>
        /// To virtual text typing
        /// </summary>
        /// <param name="text">to typing</param>
        public static void Type(string text)
        {
            InputSimulator Simulator = new InputSimulator();

            Simulator.Keyboard.TextEntry(text);
        }

    }
}