using System;
using System.Threading;

namespace CShopPject
{
    class Program
    {
        enum Stone
        {
            black, white, board
        }
        static void PrintOmok(Stone[,] omok)
        {
            Console.Write("   ");
            for (int i = 0; i < 19; i++)
            {
                if (i < 9)
                {
                    Console.Write("{0}  ", i);
                }
                else Console.Write("{0} ", i);
            }
            Console.WriteLine();
            for (int i = 0; i < omok.GetLength(0); i++)
            {
                for (int j = 0; j < omok.GetLength(1); j++)
                {
                    omok[i, j] = Stone.board;
                }
            }
            for (int i = 0; i < omok.GetLength(0); i++)
            {
                Console.Write(" {0}", (char)(65 + i));
                for (int j = 0; j < omok.GetLength(1); j++)
                {
                    switch (omok[i, j])
                    {
                        case Stone.black:
                            Console.Write("●");
                            break;
                        case Stone.white:
                            Console.Write("○");
                            break;
                        case Stone.board:
                            Console.Write(" . ");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
        static void gotoxy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }
        static void Main(string[] args)
        {
            Stone[,] omok = new Stone[19, 19];
            /*PrintOmok(omok);*/



            ConsoleKeyInfo k = Console.ReadKey();
            int X = 0, Y = 0;
            Boolean WB = true;
            while (k.Key != ConsoleKey.Escape)
            {
                k = Console.ReadKey();

                switch (k.Key)
                {
                    case ConsoleKey.UpArrow:
                        Y--;
                        break;
                    case ConsoleKey.DownArrow:
                        Y++;
                        break;
                    case ConsoleKey.LeftArrow:
                        X--;
                        break;
                    case ConsoleKey.RightArrow:
                        X++;
                        break;
                    case ConsoleKey.Spacebar:
                        if (omok[X / 2, Y] == Stone.board)
                        {
                            if (WB) omok[X / 2, Y] = Stone.white;
                            else omok[X / 2, Y] = Stone.black;
                            WB = !WB;
                        }
                        gotoxy(X, Y);
                        Console.Write("o");
                        break;
                    case ConsoleKey.C:
                        Console.Clear();
                        break;
                }
                if (X > omok.GetLength(0) * 2 - 1)
                {
                    X = omok.GetLength(0) * 2 - 1;
                }
                else if (X < 1) X = 0;
                if (Y > omok.GetLength(1) - 1)
                {
                    Y = omok.GetLength(1) - 1;
                }
                else if (Y < 1) Y = 0;
                gotoxy(X, Y);
            }
        }
    }
}
