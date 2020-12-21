using Second_Journal;
﻿using System;
using System.IO;
using static Second_Journal.Program;
using static Second_Journal.Helper;

 namespace MPT_Journal
{
    public class Teacher
    {
        public string[] Menu = new string[] {"CreateJournal", "Journals","LogOut" };
        Helper helper = new Helper();

        TeacherSruct New;
        string path = Directory.GetCurrentDirectory();
        public void MainTeacher(string login)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(path + $@"\user\teacher\{login}.dat", FileMode.Open)))
            {
                New.T_login = Path.GetFileNameWithoutExtension(path);
                New.T_password = reader.ReadString();
                New.T_fio = reader.ReadString();
                New.T_groups = reader.ReadInt32();
                New.T_groups = kostil(New.T_groups);
                New.T_disciplines = reader.ReadString();
                New.T_burthdate = reader.ReadInt32();
                New.T_age = 2020 - New.T_burthdate;
            }
            
            bool flag = true;
            while (flag)
            {
                switch (helper.Menu(Menu, 0))
                {
                    case 0:
                    {
                        SwitchJournal();
                        break;
                    }
                    case 1:
                    {
                        Console.WriteLine("Not ready yet");
                        break;
                    }
                    case 2:
                    {
                        flag = false;
                        break;
                    }
                }
                Console.ReadKey();
            }
        }

        public void SwitchJournal()
        {
            Console.Clear();
            string[] journal = new string[]{"1ая группа","2ая группа","3я группа"};
            switch (helper.Menu(journal,0))
            {
                case 0:
                {
                    if (!(Directory.Exists($@"{Directory.GetCurrentDirectory()}\user\journals\g1")))
                    {
                        Directory.CreateDirectory($@"{Directory.GetCurrentDirectory()}\user\journals\g1");
                    }

                    if (New.T_groups == 1)
                    {
                        path = path + @"\user\journals\g1";
                    }
                    else
                    {
                        Console.WriteLine("Wrong group!!");
                        break;
                    }
                    
                    
                    break;
                }
                case 1:
                {
                    if (!(Directory.Exists($@"{Directory.GetCurrentDirectory()}\user\journals\g2")))
                    {
                        Directory.CreateDirectory($@"{Directory.GetCurrentDirectory()}\user\journals\g2");
                    }
                    
                    if (New.T_groups == 2 || New.T_groups == 23)
                    {
                        path = path + @"\user\journals\g2";
                    }
                    else
                    {
                        Console.WriteLine("Wrong group!!");
                        break;
                    }
                    
                    break;
                }
                case 2:
                {
                    if (!(Directory.Exists($@"{Directory.GetCurrentDirectory()}\user\journals\g3")))
                    {
                        Directory.CreateDirectory($@"{Directory.GetCurrentDirectory()}\user\journals\g3");
                    }
                    if (New.T_groups == 3 || New.T_groups == 23)
                    {
                        path = path + @"\user\journals\g3";
                    }
                    else
                    {
                        Console.WriteLine("Wrong group!!");
                        break;
                    }
                    
                    
                    break;
                }
            }
        }

        
        public void JournalCreate(string path)
        {
            
        }
        public int kostil(int input)
        {
            int res = input;
            switch (input)
            {
                case 1:
                {
                    res = 1;
                    break;
                }
                case 12:
                {
                    goto case 1;
                    break;
                }
                case 13:
                {
                    goto case 1;
                    break;
                }
                case 21:
                {
                    res = 2;
                    break;
                }
                case 23:
                {
                    res = 23;
                    break;
                }
                case 31:
                {
                    res = 3;
                    break;
                }
                case 32:
                {
                    goto case 23;
                }
            }

            return res;
        }
    }
}