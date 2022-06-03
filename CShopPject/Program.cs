using System;
using System.Threading;

namespace CShopPject
{
    class Program
    {
        enum Mark
        {
            empty, leftRight, upDown, Cross
        }
        static void Star()
        {
            Random r = new Random();
            while(true)
            {
                for (int i = 0; i < 20; i++)
                {
                    Console.SetCursorPosition(r.Next(0, 80), r.Next(0, 25));
                    Console.Write("*");
                }
                Thread.Sleep(500);
                Console.Clear();
            }
        }
        static void Print(Mark[,] Screen) 
        {
            while (true)
            {
                Thread.Sleep(500);
                for (int i = 0; i < 80; i++)
                {
                    for (int j = 0; j < 25; j++)
                    {
                        if (Screen[i, j] != Mark.empty)
                        {
                            Console.Write("╋");
                        }
                    }
                }
            }
        }
        static void Load(Mark[,] Screen)
        {
            for (int i = 0; i < Screen.GetLength(0); i++)
            {
                for (int j = 0; j < Screen.GetLength(1); j++)
                {
                    switch (Screen[i, j])
                    {
                        case Mark.empty:
                            break;
                        case Mark.leftRight:
                            Console.SetCursorPosition(i, j);
                            Console.Write("─");
                            Thread.Sleep(10);
                            break;
                        case Mark.upDown:
                            Console.SetCursorPosition(i, j);
                            Console.Write("│");
                            Thread.Sleep(10);
                            break;
                        case Mark.Cross:
                            Console.SetCursorPosition(i, j);
                            Console.Write("┼");
                            Thread.Sleep(10);
                            break;
                    }
                }
            }
        }
        static void Clear(Mark[,] Screen)
        {
            for (int i = 0; i < Screen.GetLength(0); i++)
            {
                for (int j = 0; j < Screen.GetLength(1); j++)
                {
                    Screen[i, j] = Mark.empty;
                }
            }
        }
        static void Main(string[] args)
        {
            Mark[,] Screen = new Mark[80, 25];
            Console.SetWindowSize(Screen.GetLength(0), Screen.GetLength(1));
            ConsoleKeyInfo k = Console.ReadKey();
            int cursorX = 0, cursorY = 0;
            Console.CursorVisible = false;
            for (int i = 0; i < Screen.GetLength(0); i++)
            {
                for (int j = 0; j < Screen.GetLength(1); j++)
                {
                    Screen[i, j] = Mark.empty;
                }
            }
            while (k.Key != ConsoleKey.Escape)
            {
                k = Console.ReadKey();
                switch (k.Key)
                {
                    case ConsoleKey.UpArrow:
                        cursorY--;
                        Console.SetCursorPosition(cursorX, cursorY);
                        if (Screen[cursorX, cursorY] == Mark.leftRight || Screen[cursorX, cursorY] == Mark.Cross)
                        {
                            Console.Write("┼");
                            Screen[cursorX, cursorY] = Mark.Cross;
                        }
                        else
                        {
                            Console.Write("│");
                            Screen[cursorX, cursorY] = Mark.upDown;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        cursorY++;
                        Console.SetCursorPosition(cursorX, cursorY);
                        if (Screen[cursorX, cursorY] == Mark.leftRight || Screen[cursorX, cursorY] == Mark.Cross)
                        {
                            Console.Write("┼");
                            Screen[cursorX, cursorY] = Mark.Cross;
                        }
                        else
                        {
                            Console.Write("│");
                            Screen[cursorX, cursorY] = Mark.upDown;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        cursorX++;
                        Console.SetCursorPosition(cursorX, cursorY);
                        if (Screen[cursorX, cursorY] == Mark.upDown || Screen[cursorX, cursorY] == Mark.Cross)
                        {
                            Console.Write("┼");
                            Screen[cursorX, cursorY] = Mark.Cross;
                        }
                        else
                        {
                            Console.Write("─");
                            Screen[cursorX, cursorY] = Mark.leftRight;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        cursorX--;
                        Console.SetCursorPosition(cursorX, cursorY);
                        if (Screen[cursorX, cursorY] == Mark.upDown || Screen[cursorX, cursorY] == Mark.Cross)
                        {
                            Console.Write("┼");
                            Screen[cursorX, cursorY] = Mark.Cross;
                        }
                        else
                        {
                            Console.Write("─");
                            Screen[cursorX, cursorY] = Mark.leftRight;
                        }
                        break;
                    case ConsoleKey.C:
                        Console.Clear();
                        break;
                    case ConsoleKey.L:
                        Load(Screen);
                        break;
                    case ConsoleKey.Delete:
                        Console.Clear();
                        Clear(Screen);
                        break;
                }
            }
        }
    }
}
