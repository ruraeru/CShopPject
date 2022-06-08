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
            bool WB = false;
            bool confor = false;
            int a = X;
            int b = Y;
            //0, 0     0, 14
            //14, 0    14, 14

            //흑돌
            if (omok[X, Y] == Stone.black)
            {
                cnt = 0;
                //오른쪽 위    14     14 0
                for (int i = Y; i < omok.GetLength(0); i++)
                {
                    if (i <= 14)
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
                    }

                    if (cnt == 5)
                    {
                        WB = true;
                        return WB;
                    }
                }
                a = X;
                b = Y;
                cnt = 0;
                //오른쪽 아래   14    14
                for (int i = Y; i < omok.GetLength(0); i++)
                {         // a = 14;
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
                        WB = true;
                        return WB;
                    }
                }
                a = X;
                b = Y;
                cnt = 0;
                //왼쪽 아래
                // X = 14 Y = 0
                //A = 14 B = 0

                //왼쪽 아래
                // 7, 7      7 6 5 4 3 2 1 0  
                for (int i = Y; i >= 0; i--)
                {
                    if (omok[a, i] == Stone.black)
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
                        WB = true;
                        return WB;
                    }
                }
                a = X;
                b = Y;
                cnt = 0;
                //왼쪽 위
                for (int i = Y; i >= 0; i--)
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
                        WB = true;
                        return WB;
                    }
                }
                a = X;
                b = Y;
                cnt = 0;
                //위
                // y : 7 6 5 4 3 2 1 0
                for (int i = X; i >= 0; i--)
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
                        WB = true;
                        return WB;
                    }
                }
                a = X;
                b = Y;
                cnt = 0;
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
                        WB = true;
                        return WB;
                    }
                }
                a = X;
                b = Y;
                cnt = 0;
                //아래
                // 15  X ~ 14     X : 7 8 9 10 11 12 13 14
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
                        WB = true;
                        return WB;
                    }
                }
                a = X;
                cnt = 0;
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
                        WB = true;
                        return WB;
                    }
                }
            }

            //흰돌

            if (omok[X, Y] == Stone.white)
            {
                cnt = 0;
                //오른쪽 위    14     14 0
                for (int i = Y; i < omok.GetLength(0); i++)
                {
                    if (i <= 14)
                    {
                        if (omok[a, i] == Stone.white)
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
                        WB = true;
                        return WB;
                    }
                }
                a = X;
                b = Y;
                cnt = 0;
                //오른쪽 아래   14    14
                for (int i = Y; i < omok.GetLength(0); i++)
                {         // a = 14;
                    if (omok[a, i] == Stone.white)
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
                        WB = true;
                        return WB;
                    }
                }
                a = X;
                b = Y;
                cnt = 0;
                //왼쪽 아래
                // X = 14 Y = 0
                //A = 14 B = 0

                //왼쪽 아래
                // 7, 7      7 6 5 4 3 2 1 0  
                for (int i = Y; i >= 0; i--)
                {
                    if (omok[a, i] == Stone.white)
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
                        WB = true;
                        return WB;
                    }
                }
                a = X;
                b = Y;
                cnt = 0;
                //왼쪽 위
                for (int i = Y; i >= 0; i--)
                {
                    if (omok[a, i] == Stone.white)
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
                        WB = true;
                        return WB;
                    }
                }
                a = X;
                b = Y;
                cnt = 0;
                //위
                // y : 7 6 5 4 3 2 1 0
                for (int i = X; i >= 0; i--)
                {
                    if (omok[i, b] == Stone.white)
                    {
                        cnt++;
                    }
                    else
                    {
                        cnt = 0;
                    }
                    if (cnt == 5)
                    {
                        WB = true;
                        return WB;
                    }
                }
                a = X;
                b = Y;
                cnt = 0;
                //오른쪽
                for (int i = Y; i < omok.GetLength(1); i++)
                {
                    if (omok[a, i] == Stone.white)
                    {
                        cnt++;
                    }
                    else
                    {
                        cnt = 0;
                    }
                    if (cnt == 5)
                    {
                        WB = true;
                        return WB;
                    }
                }
                a = X;
                b = Y;
                cnt = 0;
                //아래
                // 15  X ~ 14     X : 7 8 9 10 11 12 13 14
                for (int i = X; i < omok.GetLength(0); i++)
                {
                    if (omok[i, b] == Stone.white)
                    {
                        cnt++;
                    }
                    else
                    {
                        cnt = 0;
                    }
                    if (cnt == 5)
                    {
                        WB = true;
                        return WB;
                    }
                }
                a = X;
                cnt = 0;
                //왼쪽
                for (int i = Y; i >= 0; i--)
                {
                    if (omok[a, i] == Stone.white)
                    {
                        cnt++;
                    }
                    else
                    {
                        cnt = 0;
                    }
                    if (cnt == 5)
                    {
                        WB = true;
                        return WB;
                    }
                }
            }
            return WB;
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
                        Console.WriteLine(WB ? "백돌 차례" : "흑돌 차례");
                        //Console.WriteLine("omok : {0} X : {1} Y : {2} cursorX : {3} cursorY : {4}", omok[X, Y], X, Y, cursorX, cursorY);
                        if (omok[X, Y] == Stone.black)
                        {
                            if (CheckWin(omok, X, Y))
                            {
                                Console.SetCursorPosition(omok.GetLength(0) / 2, omok.GetLength(1) / 2);
                                Console.WriteLine("===== 흑돌 승리 =====");
                                Thread.Sleep(1000);
                                Console.Clear();
                                Delete(omok);
                                PrintOmok(omok);
                                WB = false;
                            }
                        }
                        else
                        {
                            if (CheckWin(omok, X, Y))
                            {
                                Console.SetCursorPosition(omok.GetLength(0) / 2, omok.GetLength(1) / 2);
                                Console.WriteLine("===== 백돌 승리 =====");
                                Thread.Sleep(1000);
                                Console.Clear();
                                Delete(omok);
                                PrintOmok(omok);
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
                        Console.Clear();
                        Delete(omok);
                        PrintOmok(omok);
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
        }
    }
}