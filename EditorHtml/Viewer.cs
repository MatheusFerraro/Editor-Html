using EditoHtml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EditorHtml
{
    public class Viewer
    {
        public static void Show(string text)
        {

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("VIEWER MODE");
            Console.WriteLine("----------------");
            Replace(text);
            Console.WriteLine("-----------------");
            Console.ReadKey();
            Menu.Display();

        }

        public static void Replace(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                Console.WriteLine("No text to display");
                return;
            }

            var strongRegex = new Regex(@"<\s*strong[^>]*>(.*?)<\s*/\s*strong>", RegexOptions.IgnoreCase);
            var lines = text.Split(new[] {'\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var matches = strongRegex.Matches(line);

                if (matches.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(line);  
                }   
                else
                {
                    //process the line to highlight <strong> content
                    int lastIndex = 0;
                    foreach(Match match in matches)
                    {
                        //print text before the match
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(line.Substring(lastIndex, match.Index - lastIndex));

                        //print the content inside <strong> tags in blue
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(match.Groups[1].Value);

                        lastIndex = match.Index + match.Length;
                    }
                    //print the remaining text after the last match
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(line.Substring(lastIndex));
                }
            }

        }


    }
}
