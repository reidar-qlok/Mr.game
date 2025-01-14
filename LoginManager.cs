﻿namespace MrRoboT;

public class LoginManager
{
    public static string userName;
    public static void Show()
    {

        while (true)
        {

            var backgroundColor = ConsoleColor.Black;
            var borderColor = ConsoleColor.DarkGreen;
            var textColor = ConsoleColor.White;
            var inputColor = ConsoleColor.Green;

            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = borderColor;
            Console.Clear();

            var formWidth = 60;
            var formHeight = 14;
            var leftPadding = (Console.WindowWidth - formWidth) / 2;
            var topPadding = (Console.WindowHeight - formHeight) / 2;

            for (var i = 0; i < formHeight; i++)
            {
                Console.SetCursorPosition(leftPadding, topPadding + i);
                if (i == 0 || i == formHeight - 1)
                    Console.Write(new string('═', formWidth));
                else
                    Console.Write("║" + new string(' ', formWidth - 2) + "║");
            }

            Console.SetCursorPosition(leftPadding + 2, topPadding + 4);
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = textColor;
            PrintCenteredText("Login to start your mission");

            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = inputColor;

            Console.SetCursorPosition(leftPadding + 2, topPadding + 6);
            Console.Write("Username: ");
            LoginManager.userName = Console.ReadLine();

            Console.SetCursorPosition(leftPadding + 2, topPadding + 7);
            Console.Write("Password: ");
            var userPass = GetHiddenInput();

            if (userName == userName && userPass == "startx")
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                PrintCenteredText("Login Successful!\n");
                PrintCenteredText("Loading...");

                var totalProgress = 100;
                for (var i = 0; i <= totalProgress; i++)
                {
                    Console.Write(" \r");
                    Console.Write(new string('▐', i));
                    Console.Write(new string(' ', totalProgress - i));
                    Console.Write(" " + i * 3 + " %");
                    Thread.Sleep(50);
                }
                Console.Clear();


                //Game.StartGame(); // 

                break;
            }

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            PrintCenteredText("Login Failed. Please try again.");
            Thread.Sleep(2000);
        }
    }

    private static string GetHiddenInput()
    {
        var input = "";
        ConsoleKeyInfo keyInfo;

        do
        {
            keyInfo = Console.ReadKey(true);

            if (keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.Backspace)
            {
                input += keyInfo.KeyChar;
                Console.Write("*");
            }
            else if (keyInfo.Key == ConsoleKey.Backspace && input.Length > 0)
            {
                input = input.Remove(input.Length - 1);
                Console.Write("\b \b");
            }
        } while (keyInfo.Key != ConsoleKey.Enter);

        Console.WriteLine();
        return input;
    }

    private static void PrintCenteredText(string text)
    {
        var leftPadding = (Console.WindowWidth - text.Length) / 2;
        Console.SetCursorPosition(leftPadding, Console.CursorTop);
        Console.WriteLine(text);
    }
}