﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using static Second_Journal.Program;

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
        public int AdminMenu (List<AdminStrtuct> menu, int StartString)
        {
            ConsoleKeyInfo key;
            int index = StartString;
            int currentpos = index;
            while (true)
            {
                Console.Clear();
                int id = 0;
                foreach (AdminStrtuct m in menu)
                {
                    Console.WriteLine($"{id} {m.A_login}");
                    id++;
                }

                Console.SetCursorPosition(0, index);
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                    {
                        index--;
                        if (index < 0)
                        {
                            index = id - 1;
                        }
                        break;
                    }
                    case ConsoleKey.DownArrow:
                    {
                        index++;
                        if (index >= id)
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
        public int StudentMenu (List<StudentStrtuct> menu, int StartString)
        {
            ConsoleKeyInfo key;
            int index = StartString;
            int currentpos = index;
            while (true)
            {
                Console.Clear();
                int id = 0;
                foreach (StudentStrtuct m in menu)
                {
                    Console.WriteLine($"{id} {m.S_login}");
                    id++;
                }

                Console.SetCursorPosition(0, index);
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                    {
                        index--;
                        if (index < 0)
                        {
                            index = id - 1;
                        }
                        break;
                    }
                    case ConsoleKey.DownArrow:
                    {
                        index++;
                        if (index >= id)
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
        public int TeacherMenu (List<TeacherStrtuct> menu, int StartString)
        {
            ConsoleKeyInfo key;
            int index = StartString;
            int currentpos = index;
            while (true)
            {
                Console.Clear();
                int id = 0;
                foreach (TeacherStrtuct m in menu)
                {
                    Console.WriteLine($"{id} {m.T_login}");
                    id++;
                }

                Console.SetCursorPosition(0, index);
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                    {
                        index--;
                        if (index < 0)
                        {
                            index = id - 1;
                        }
                        break;
                    }
                    case ConsoleKey.DownArrow:
                    {
                        index++;
                        if (index >= id)
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
                } while (ValidationRUS(name)==false);
            }

            return name;
        }

        public string[] InfoStudents(string colums)
        {
            JournalStruct New = new JournalStruct();
            for (int i = 0; i != 10; i++)
            {
                Console.Write($"{colums}  {i}:");
                New.J_Student[i] = Console.ReadLine();
            }

            return New.J_Student;
        }
        public int intInfoUsers(string colums)
        {
            int num = 0;
            do
            {
                Console.Write($"{colums}: ");
                num = Convert.ToInt32(Console.ReadLine());
            } 
            while (ValidationNUM(num) == false);

            return num;
        }
        
        public int intInfoJournals(string colums, string input)
        {
            int num = 0;
            do
            {
                Console.Write($"{colums}: ");
                num = Convert.ToInt32(Console.ReadLine());
            } 
            while (ValidationNUM(num) == false);
            return num;
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
        public bool ValidationNUM(int num)
        {
            bool validation = true;
            string strNum = Convert.ToString(num) ;
            if (Regex.IsMatch(@"[-!#\$%&'\*\+/=\?\^`\{\}]", strNum))
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