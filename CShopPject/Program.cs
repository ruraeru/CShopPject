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
            setCoord(0, 0);
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
            int a = X;
            int b = Y;
            bool result = false;

            Stone WB = (omok[X, Y] == Stone.white ? Stone.white : Stone.black);

            //오른쪽 위
            for (int i = Y; i < omok.GetLength(0); i++)
            {
                if (i <= 14)
                {
                    if (omok[a, i] == WB)
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
                }
                if (cnt == 5)
                {
                    result = true;
                }
            }
            a = X;
            cnt = 0;

            //오른쪽 아래
            for (int i = Y; i < omok.GetLength(0); i++)
            {         // a = 14;
                if (omok[a, i] == WB)
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
                    result = true;
                }
            }
            a = X;
            cnt = 0;

            //왼쪽 아래
            for (int i = Y; i >= 0; i--)
            {
                if (omok[a, i] == WB)
                {
                    if (a != 14)
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
                    result = true;
                }
            }
            a = X;
            cnt = 0;

            //왼쪽 위
            for (int i = Y; i >= 0; i--)
            {
                if (omok[a, i] == WB)
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
                    result = true;
                }
            }
            //b = Y;
            cnt = 0;

            //위
            for (int i = X; i >= 0; i--)
            {
                if (omok[i, b] == WB)
                {
                    cnt++;
                }
                else
                {
                    cnt = 0;
                }
                if (cnt == 5)
                {
                    result = true;
                }
            }
            a = X;
            cnt = 0;

            //오른쪽
            for (int i = Y; i < omok.GetLength(1); i++)
            {
                if (omok[a, i] == WB)
                {
                    cnt++;
                }
                else
                {
                    cnt = 0;
                }
                if (cnt == 5)
                {
                    result = true;
                }
            }
            b = Y;
            cnt = 0;

            //아래
            for (int i = X; i < omok.GetLength(0); i++)
            {
                if (omok[i, b] == WB)
                {
                    cnt++;
                }
                else
                {
                    cnt = 0;
                }
                if (cnt == 5)
                {
                    result = true;
                }
            }
            a = X;
            cnt = 0;

            //왼쪽
            for (int i = Y; i >= 0; i--)
            {
                if (omok[a, i] == WB)
                {
                    cnt++;
                }
                else
                {
                    cnt = 0;
                }
                if (cnt == 5)
                {
                    result = true;
                }
            }
            return result;
        }

        static void Default(Stone[,] omok)
        {
            Console.Clear();
            Delete(omok);
            PrintOmok(omok);
        }

        static void Main(string[] args)
        {
            Stone[,] omok = new Stone[15, 15];
            Default(omok);
            //Console.SetWindowSize(50, 20);

            ConsoleKeyInfo k = Console.ReadKey();
            int cursorX = 0, cursorY = 0;
            int X = 0, Y = 0;
            bool WB = false;
            Console.WriteLine(WB ? "백돌 차례" : "흑돌 차례");
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
                            }
                            else
                            {
                                omok[X, Y] = Stone.black;
                            }
                            WB = !WB;
                        }
                        Console.Clear();
                        PrintOmok(omok);
                        Console.WriteLine(WB ? "백돌 차례" : "흑돌 차례");
                        Console.WriteLine("omok : {0} X : {1} Y : {2} cursorX : {3} cursorY : {4}", omok[X, Y], X, Y, cursorX, cursorY);
                        if (omok[X, Y] == Stone.black)
                        {
                            if (CheckWin(omok, X, Y))
                            {
                                Console.Clear();
                                setCoord(omok.GetLength(0) / 2, omok.GetLength(1) / 2);
                                Console.WriteLine("===== 흑돌 승리 =====");
                                Thread.Sleep(1000);
                                Default(omok);
                                WB = false;
                            }
                        }
                        else
                        {
                            if (CheckWin(omok, X, Y))
                            {
                                Console.Clear();
                                setCoord(omok.GetLength(0) / 2, omok.GetLength(1) / 2);
                                Console.WriteLine("===== 백돌 승리 =====");
                                Thread.Sleep(1000);
                                Default(omok);
                                WB = false;
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
                        Default(omok);
                        WB = false;
                        break;
                }
                if (cursorX > omok.GetLength(0) * 2 - 1)
                {
                    cursorX = 28;
                    Y = cursorX / 2;
                }
                else if (cursorX < 0)
                {
                    cursorX = 0;
                    Y = cursorX / 2;
                }
                if (cursorY > omok.GetLength(1) - 1)
                {
                    cursorY = omok.GetLength(1) - 1;
                    X = cursorY;
                }
                else if (cursorY < 0)
                {
                    cursorY = 0;
                    X = cursorY;
                }
                setCoord(cursorX, cursorY);
            }
            Console.Clear();
        }
    }
}