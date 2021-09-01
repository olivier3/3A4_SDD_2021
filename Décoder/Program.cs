using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cstjean.info.fg.consoleplus;

namespace Décoder
{
    public class Program
    {
        public static string Décoder(string message)
        {
            var pile = new Stack<char>();
            string messageFinal = "";
            int longueurMessage = message.Count();

            for (int i = 0; i < longueurMessage; i++)
            {
                if (message[i].Equals('*'))
                {
                    try
                    {
                        messageFinal += pile.Pop();
                    }
                    catch
                    {
                        var sb = new StringBuilder();

                        for (int j = 0; j < longueurMessage; j++)
                        {
                            if (i.Equals(j))
                            {
                                sb.Append($"[{message[j]}]");
                            }
                            else
                            {
                                sb.Append($"{message[j]}");
                            }
                        }
                        throw new FormatException($" ERREUR: Message secret invalide - stack underflow {sb}");
                    }
                }
                else
                {
                    pile.Push(message[i]);
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

                try
                {
                    ConsolePlus.WriteLine(ConsoleColor.Green, $"          {Décoder(message)}");
                }
                catch (FormatException ex)
                {
                    ConsolePlus.WriteLine(ConsoleColor.Red, ex.Message);
                    Console.WriteLine();
                }
            }

            ConsolePlus.WriteLine(ConsoleColor.DarkYellow, "Au revoir");
        }
    }
}
