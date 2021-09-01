using System;
using System.Collections.Generic;
using cstjean.info.fg.consoleplus;

namespace Décoder
{
    public class Program
    {
        public static string Décoder(string message)
        {
            var pile = new Stack<char>();
            var messageFinal = "";
            foreach (char elem in message)
            {
                if (elem.Equals('*'))
                {
                    messageFinal += pile.Pop();
                }
                else
                {
                    pile.Push(elem);
                }
            }

            return messageFinal;
        }

        public static void Main()
        {
            ConsolePlus.IndentationGénérale = 1;
            ConsolePlus.WriteLine(ConsoleColor.DarkYellow, "" +
                "SDD - Application de décodage \n" +
                "Par Olivier Bilodeau \n" +
                "Basées sur: Stack \n");

            string message = "";

            while (message != "exit")
            {
                ConsolePlus.Write(ConsoleColor.Blue, "Décoder> ");
                message = Console.ReadLine();

                ConsolePlus.WriteLine(ConsoleColor.Green, $"          {Décoder(message)}");
                Console.WriteLine();
            }

            ConsolePlus.WriteLine(ConsoleColor.DarkYellow, "Au revoir");
        }
    }
}
