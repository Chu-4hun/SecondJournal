using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace Second_Journal
{
    public class Helper
    {
        public int Menu(string[] menu, int StartString)
        {
            ConsoleKeyInfo key;
            int index = StartString;
            int currentpos = index;
            while (true)
            {
                Console.Clear();
                foreach (string m in menu)
                    Console.WriteLine(m);

                Console.SetCursorPosition(0, index);
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                    {
                        index--;
                        if (index < 0)
                        {
                            index = menu.Length - 1;
                        }
                        break;
                    }
                    case ConsoleKey.DownArrow:
                    {
                        index++;
                        if (index >= menu.Length)
                        {
                            index = 0;
                        }
                        break;
                    }
                    case ConsoleKey.Enter:
                    {
                        Console.Clear();
                        return index;
                    }
                }
            }
        }
        public string InfoUsers(string colums)
        {
            string name = "";
            if (colums == "Login" || colums == "Password")
            {
                do
                {
                    Console.Write($"{colums}: ");
                    name = Console.ReadLine();
                } while((ValidationENG(name)==false)|| (colums == "Login" && ValidationLogin(name)==false));
            }
            else if (colums == "ФИО")
            {
                do
                {
                    Console.Write($"{colums}: ");
                    name = Console.ReadLine();
                } while (ValidationRUS(name)==false);
            }
            else
            {
                do
                {
                    Console.Write($"{colums}: ");
                    name = Console.ReadLine();
                } while (ValidationNUM(name)==false);
            }
            return name;
        }
        public bool ValidationENG(string name)
        {
            bool validation = true;
            if (Regex.IsMatch(name, @"[а-яА-Я]"))
            {
                validation = false;
                Console.WriteLine("ERR 3! Russian symbols");
            }
            return validation;
        }
        public bool ValidationRUS(string name)
        {
            bool validation = true;
            if (Regex.IsMatch(name, @"[a-zA-Z]"))
            {
                validation = false;
                Console.WriteLine("ERR! English symbols");
            }
            return validation;
        }

        public bool ValidationNUM(string num)
        {
            bool validation = true;
            if (Regex.IsMatch(num, @"[-!#\$%&'\*\+/=\?\^`\{\}]"))
            {
                validation = false;
                Console.WriteLine("ERR! Wrong symbols");
            }
            return validation;
        }
        public bool ValidationLogin(string login)
        {
            bool validation = true;
            if (File.Exists(Directory.GetCurrentDirectory() + $@"\user\{login}.dat"))
                validation = false;
            else if (File.Exists(Directory.GetCurrentDirectory() + $@"\user\admin\{login}.dat"))
                validation = false;
            else if (File.Exists(Directory.GetCurrentDirectory() + $@"\user\student\{login}.dat"))
                validation = false;
            else if (File.Exists(Directory.GetCurrentDirectory() + $@"\user\teacher\{login}.dat"))
                validation = false;
            if (validation == false)
                Console.WriteLine("ERR! This login already exist");
            return validation;
        }
    }
}