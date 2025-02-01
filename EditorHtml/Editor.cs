using EditoHtml;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorHtml
{
    public class Editor
    {
        private static int width = 60;
        private static int height = 20;
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Menu.DrawScreen(width, height);
            WriteOption();
            Start();
            


        }
        public static void WriteOption()
        {
            Console.SetCursorPosition(7, 2);
            Console.WriteLine("EDITOR MODE || (Esc) To exit");
              
        }
        public static void Start()
        {
            var file = new StringBuilder();
            int currentLine = 5;


            while (true)
            {
                Console.SetCursorPosition(7, currentLine);
                string input = ReadLineWithEscape();
                
                if(input == null)
                {
                    break;
                }
                file.Append(input);
                currentLine++;

               
            }
            
            Console.SetCursorPosition(7, currentLine + 1);
            Console.WriteLine("---------------");
            Console.WriteLine("Do you want to save the file? (Y/N)");
            string option = Console.ReadLine();

            if (string.Equals(option, "Y", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Enter the path to save the file: ");
                var path = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(path))
                {
                    Console.WriteLine("Invalid file path. File not saved");
                }
                else
                { 
                    try
                    {
                        string directory = Path.GetDirectoryName(path);
                        if (!Directory.Exists(directory))
                        {
                            Directory.CreateDirectory(directory);
                        }

                        using (var writer = new StreamWriter(path))
                        {
                            writer.Write(file.ToString());
                        }
                        Console.WriteLine($"File {path} Saved Succesfully");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error Saving file: {ex.Message}");
                    }
             }  
            }
            else if(string.Equals(option, "N", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Exiting without saving.");
            }
            Console.ReadLine();
            Viewer.Show(file.ToString());

        }
        private static string ReadLineWithEscape()
        {
            var input = new StringBuilder();
            while (true)
            {
                var key = Console.ReadKey(intercept: true); // Capture key without displaying it

                if (key.Key == ConsoleKey.Escape) // If Esc is pressed, return null
                {
                    return null;
                }
                else if(key.Key == ConsoleKey.Enter) // If Enter is pressed, return the input
                {
                    Console.WriteLine();            // Move to the next line
                    return input.ToString();
                }
                else if(key.Key == ConsoleKey.Backspace && input.Length > 0) // Handle backspace
                {
                    input.Remove(input.Length - 1, 1);
                    Console.WriteLine("\b \b");        // Move cursor back, overwrite with space, move back again
                }
                else if (!char.IsControl(key.KeyChar)) // Ignore control characters
                {
                    input.Append(key.KeyChar);
                    Console.Write(key.KeyChar); // Display the character
                }
            }
        }

    }
}
