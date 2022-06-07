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

        static bool CheckWin(Stone[,] omok, int X, int Y)
        {
            int cnt = 0;
            bool W = false;
            int a = X;
            int b = Y;

            //오른쪽 위
            if (omok[X, Y] == Stone.black)
            {
                cnt = 0;
                for (int i = Y; i < omok.GetLength(0); i++)
                {
                    if (omok[a, i] == Stone.black)
                    {
                        if (a != 0)
                        {
                            a--;
                        }
                        cnt++;
                    }
                    else
                    {
                        cnt = 0;
                    }
                    if (cnt == 5)
                    {
                        W = true;
                        return W;
                    }
                }
                a = X;
                cnt = 0;
                //오른쪽 아래
                for (int i = Y; i < omok.GetLength(0); i++)
                {
                    if (omok[a, i] == Stone.black)
                    {
                        if (a != omok.GetLength(0) - 1)
                        {
                            a++;
                        }
                        cnt++;
                    }
                    else
                    {
                        cnt = 0;
                    }
                    if (cnt == 5)
                    {
                        W = true;
                        return W;
                    }
                }
                a = X;
                cnt = 0;
                //왼쪽 아래
                // X = 14 Y = 0
                //A = 14 B = 0
                for (int i = 0; i < 5; i++)
                {
                    if (omok[a, b] == Stone.black)
                    {               //a <= 14 && b >= 0 a-- b++
                        if (a != omok.GetLength(0) - 1 && b != 0)
                        {
                            a++;
                            b--;
                        } else
                        {
                            a--; 
                            b++; 
                        }
                        cnt++;
                    }
                    else
                    {
                        cnt = 0;
                    }
                    if (cnt == 5)
                    {
                        W = true;
                        return W;
                    }
                }
                a = X;
                cnt = 0;
                //왼쪽 위
                for (int i = Y; i > 0; i--)
                {
                    if (omok[a, i] == Stone.black)
                    {
                        if (a != 0)
                        {
                            a--;
                        }
                        cnt++;
                    }
                    else
                    {
                        cnt = 0;
                    }
                    if (cnt == 5)
                    {
                        W = true;
                        return W;
                    }
                }
                a = X;
                cnt = 0;
                //위
                for (int i = Y; i >= 0; i--)
                {
                    if (omok[i, a] == Stone.black)
                    {
                        cnt++;
                    }
                    else
                    {
                        cnt = 0;
                    }
                    if (cnt == 5)
                    {
                        W = true;
                        return W;
                    }
                }
                //오른쪽
                for (int i = Y; i < omok.GetLength(1); i++)
                {
                    if (omok[a, i] == Stone.black)
                    {
                        cnt++;
                    }
                    else
                    {
                        cnt = 0;
                    }
                    if (cnt == 5)
                    {
                        W = true;
                        return W;
                    }
                }
                //아래
                for (int i = X; i < omok.GetLength(0); i++)
                {
                    if (omok[i, b] == Stone.black)
                    {
                        cnt++;
                    }
                    else
                    {
                        cnt = 0;
                    }
                    if (cnt == 5)
                    {
                        W = true;
                        return W;
                    }
                }
                //왼쪽
                for (int i = Y; i >= 0; i--)
                {
                    if (omok[a, i] == Stone.black)
                    {
                        cnt++;
                    }
                    else
                    {
                        cnt = 0;
                    }
                    if (cnt == 5)
                    {
                        W = true;
                        return W;
                    }
                }
            }

            return W;
        }

        static void Main(string[] args)
        {
            Stone[,] omok = new Stone[15, 15];
            Delete(omok);
            PrintOmok(omok);


            ConsoleKeyInfo k = Console.ReadKey();
            int cursorX = 0, cursorY = 0;
            int X = 0, Y = 0;
            bool WB = false;
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
                        Y = cursorX / 2;
                        break;
                    case ConsoleKey.RightArrow:
                        cursorX += 2;
                        Y = cursorX / 2;
                        break;
                    case ConsoleKey.Spacebar:
                        if (omok[X, Y] == Stone.board)
                        {
                            if (WB)
                            {
                                omok[X, Y] = Stone.white;
                                WB = !WB;
                            }
                            else
                            {
                                omok[X, Y] = Stone.black;
                                WB = !WB;
                            }
                        }
                        Console.Clear();
                        PrintOmok(omok);
                        Console.WriteLine(!WB ? "흑돌 차례" : "백돌 차례");
                        Console.WriteLine("omok : {0} X : {1} Y : {2} cursorX : {3} cursorY : {4}", omok[X, Y], X, Y, cursorX, cursorY);

                        if (CheckWin(omok, X, Y))
                        {
                            if (WB)
                            {
                                Console.WriteLine("black");
                            }
                            else
                            {
                                Console.WriteLine("white");
                            }
                        }
                        break;
                    case ConsoleKey.C:
                        Console.Clear();
                        break;
                    case ConsoleKey.L:
                        Console.Clear();
                        PrintOmok(omok);
                        break;
                    case ConsoleKey.F:
                    case ConsoleKey.Delete:
                        Console.Clear();
                        Delete(omok);
                        PrintOmok(omok);
                        WB = false;
                        break;
                }
                if (cursorX > omok.GetLength(1) * 2 - 1)
                {
                    cursorX = 28;
                    Y = cursorX / 2;
                }
                else if (cursorX < 0)
                {
                    cursorX = 0;
                    Y = cursorX / 2;
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