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
            for (int i = 0; i < omok.GetLength(0); i++)
            {
                for (int j = 0; j < omok.GetLength(1); j++)
                {
                    switch (omok[i, j])
                    {
                        case Stone.black:
                            Console.Write("x ");
                            break;
                        case Stone.white:
                            Console.Write("o ");
                            break;
                        case Stone.board:
                            Console.Write("_ ");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
        static void setCoord(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        static void Delete(Stone[,] omok)
        {
            for (int i = 0; i < omok.GetLength(0); i++)
            {
                for (int j = 0; j < omok.GetLength(1); j++)
                {
                    omok[i, j] = Stone.board;
                }
            }
        }
        static Boolean CheckWin(Stone[,] omok, int X, int Y)
        {
            int coordX = X;
            int coordY = Y;
            int cnt = 0;
            Boolean bo = false;

            if (omok[coordX, coordY] == Stone.black)
            {
                for (int a = 0; a < 5; a++)
                {
                    coordX--;
                }
                for (int b = 0; b < 5; b++)
                {
                    coordX--;
                    coordY++;
                }
                for (int c = 0; c < 5; c++)
                {
                    coordY++;
                }
                for (int d = 0; d < 5; d++)
                {
                    coordX++;
                    coordY++;
                }
                for (int e = 0; e < 5; e++)
                {
                    coordX++;
                }
                for (int f = 0; f < 5; f++)
                {
                    coordX++;
                    coordY--;
                }
                for (int g = 0; g < 5; g++)
                {
                    coordY--;
                }
                for (int h = 0; h < 5; h++)
                {
                    coordX--;
                    coordY--;
                }
                Console.WriteLine(cnt);
                cnt++;
            } 
            else if(omok[coordX, coordY] == Stone.white)
            {

            }

            if (cnt == 5)
            {
                bo = true;
            }

            return bo;
        }
        static void Main(string[] args)
        {
            Stone[,] omok = new Stone[15, 15];
            Delete(omok);
            PrintOmok(omok);


            ConsoleKeyInfo k = Console.ReadKey();
            int cursorX = 0, cursorY = 0;
            int X = 0, Y = 0;
            Boolean WB = true;
            while (k.Key != ConsoleKey.Escape)
            {
                k = Console.ReadKey();

                switch (k.Key)
                {
                    case ConsoleKey.UpArrow:
                        cursorY--;
                        X = cursorY;
                        break;
                    case ConsoleKey.DownArrow:
                        cursorY++;
                        X = cursorY;
                        break;
                    case ConsoleKey.LeftArrow:
                        cursorX -= 2;
                        Y = cursorX;
                        break;
                    case ConsoleKey.RightArrow:
                        cursorX += 2;
                        Y = cursorX;
                        break;
                    case ConsoleKey.Spacebar:
                        if (omok[X, Y / 2] == Stone.board)
                        {
                            if (WB)
                            {
                                omok[X, Y / 2] = Stone.white;
                                WB = !WB;
                            }
                            else
                            {
                                omok[X, Y / 2] = Stone.black;
                                WB = !WB;
                            }
                        }
                        Console.Clear();
                        PrintOmok(omok);
                        Console.WriteLine(!WB ? "흑돌 차례" : "백돌 차례");
                        if (CheckWin(omok, X, Y/2))
                        {
                            Console.WriteLine("흑돌이 이김");
                            return;
                        }
                        break;
                    case ConsoleKey.C:
                        Console.Clear();
                        break;
                    case ConsoleKey.L:
                        Console.Clear();
                        PrintOmok(omok);
                        break;
                    case ConsoleKey.Delete:
                        Console.Clear();
                        Delete(omok);
                        PrintOmok(omok);
                        break;
                }
                if (cursorX > omok.GetLength(1) * 2 - 1)
                {
                    cursorX = 28;
                    Y = cursorX;
                }
                else if (cursorX < 0)
                {
                    cursorX = 0;
                    Y = cursorX;
                }
                if (cursorY > 14)
                {
                    cursorY = 14;
                    X = cursorY;
                }
                else if (cursorY < 0)
                {
                    cursorY = 0;
                    X = cursorY;
                }
                setCoord(cursorX, cursorY);
            }
        }
    }
}
