using EditorHtml;
using System; 

namespace EditoHtml
{
    public static class Menu
    {
        private const int ScreenWidth = 32;
        private const int ScreenHeight = 12;

        public static void Display()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Yellow;
            DrawScreen(ScreenWidth, ScreenHeight);
            WriteOption();

            var option = short.Parse(Console.ReadLine());
            HandleMenuOption(option);
        }

        public static void DrawScreen(int width, int height)
        {
            DrawHorizontalBorder(width);

            for(int lines = 0; lines < height - 2; lines++)
            {
                DrawVerticalBorder(width);
               
            }
            DrawHorizontalBorder(width);
                  
        }
        private static void DrawHorizontalBorder(int width)
        {
            Console.Write("+");
            for (int i = 0; i < width - 2; i++)
            {
                Console.Write("*");
            }
            Console.Write("+");
            Console.WriteLine();
        }
        private static void DrawVerticalBorder(int width)
        {
            Console.Write("|");
            for(int i = 0; i < width - 2; i++)
            {
                Console.Write(" ");
            }
            Console.Write("|");
            Console.WriteLine();
        }

        public static void WriteOption()
        {
           
            Console.SetCursorPosition(3, 1);
            Console.WriteLine("HTML Editor");
            Console.SetCursorPosition(3, 2);
            Console.WriteLine("===================");
            Console.SetCursorPosition(3, 3);
            Console.WriteLine("Select a Option Below");
            Console.SetCursorPosition(3, 5);
            Console.WriteLine("1 - New File");
            Console.SetCursorPosition(3, 6);
            Console.WriteLine("2 - Open");
            Console.SetCursorPosition(3, 7);
            Console.WriteLine("0 - Exit");
            Console.SetCursorPosition(3, 9);
            Console.Write("Option: ");
            
        }

        public static void HandleMenuOption(short option)
        {
            switch (option)
            {
                case 1:
                    Editor.Show();
                    break;
                case 2:
                    Console.WriteLine("View");
                    break;
                case 0:
                    {
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    }
                default: Display();
                    break;
            }
        }
    }


}