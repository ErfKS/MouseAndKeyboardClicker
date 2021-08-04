using System.IO;
using System;

namespace AutoClickerMouseAndKeyboard
{
    public class FileManagment
    {
        public static void WriteFile(string fileName, string Context)
        {
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter(fileName);
                //Write a line of text
                sw.Write(Context);
                //Close the file
                sw.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}