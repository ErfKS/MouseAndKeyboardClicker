using System;
namespace AutoClickerMouseAndKeyboard
{
    public struct Boolean_Question
    {
        public static bool SetQuestion(bool defult , string question)
        {
            Console.WriteLine(question);
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Y:
                    Console.WriteLine();
                    return true;
                    
                case ConsoleKey.N:
                    Console.WriteLine();
                    return false;
                    
                default:
                    Console.WriteLine("This is incorrect, So We change defult valeu ({0})" , defult.ToString());
                    return defult;
            }
        }
        
        public static bool SetQuestion(bool defult)
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Y:
                    Console.WriteLine();
                    return true;
                    
                case ConsoleKey.N:
                    Console.WriteLine();
                    return false;
                    
                default:
                    Console.WriteLine("This is incorrect, So We change defult valeu ({0})" , defult.ToString());
                    return defult;
                    
            }
        }
        
        public static bool SetQuestionCanLooping(bool defult , string question)
        {
            Console.WriteLine(question);
            while (true)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Y:
                        Console.WriteLine();
                        return true;
                        
                    case ConsoleKey.N:
                        Console.WriteLine();
                        return false;
                        
                    default:
                        Console.WriteLine("This is incorrect!");
                        break;
                }
            }
        }

        public static bool SetQuestionCanLooping()
        {
            while (true)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Y:
                        Console.WriteLine();
                        return true;

                    case ConsoleKey.N:
                        Console.WriteLine();
                        return false;

                    default:
                        Console.WriteLine("This is incorrect!");
                        break;
                }
            }
        }
        
        public static bool SetQuestionCanLooping(string question)
        {
            Console.WriteLine(question);
            while (true)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Y:
                        Console.WriteLine();
                        return true;

                    case ConsoleKey.N:
                        Console.WriteLine();
                        return false;

                    default:
                        Console.WriteLine("This is incorrect!");
                        break;
                }
            }
        }
        
        public static int SetQuestionCanNullable(string question)
        {
            Console.WriteLine(question);
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Y:
                    Console.WriteLine();
                    return 1;
                case ConsoleKey.N:
                    Console.WriteLine();
                    return 0;
                default:
                    Console.WriteLine("This is incorrect!");
                    return -1;
            }
        }
        
        public static int SetQuestionCanNullable()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Y:
                    Console.WriteLine();
                    return 1;

                case ConsoleKey.N:
                    Console.WriteLine();
                    return 0;

                default:
                    Console.WriteLine("This is incorrect!");
                    return -1;

            }
        }
    }
}