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
            int cptEtoile = 0;
            int cptLettre = 0;

            foreach (char elem in message)
            {
                if (elem.Equals('*'))
                {
                    cptEtoile++;
                }
                else
                {
                    cptLettre++;
                }
            }

            if (cptEtoile < cptLettre)
            {
                int nbManquant = cptLettre - cptEtoile;

                throw new FormatException($" ERREUR: Message secret invalide - étoiles manquantes '{String.Concat(Enumerable.Repeat('*', nbManquant))}' à la fin");
            }

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

            for (; ; )
            {
                ConsolePlus.Write(ConsoleColor.Blue, "Décoder> ");
                message = Console.ReadLine();

                if (message.Equals("exit")) break;

                try
                {
                    ConsolePlus.WriteLine(ConsoleColor.Green, $"          {Décoder(message)}");
                    Console.WriteLine();
                }
                catch (FormatException ex)
                {
                    ConsolePlus.WriteLine(ConsoleColor.Red, ex.Message);
                    Console.WriteLine();
                }
            }

            ConsolePlus.Write(ConsoleColor.DarkYellow, "Au revoir");
        }
    }
}
