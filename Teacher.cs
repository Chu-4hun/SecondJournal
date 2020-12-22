using Second_Journal;
﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            string groupcode = "";
            int groupIdentifier = 0;
            switch (helper.Menu(journal,0))
            {
                case 0:
                {
                    if (!(Directory.Exists($@"{Directory.GetCurrentDirectory()}\user\journals")))
                    {
                        Directory.CreateDirectory($@"{Directory.GetCurrentDirectory()}\user\journals");
                    }

                    if (New.T_groups == 1)
                    {
                        path = path + @"\user\journals";
                        groupcode = "g1";
                        groupIdentifier = 1;
                        JournalCreate(groupcode,groupIdentifier);
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
                    if (!(Directory.Exists($@"{Directory.GetCurrentDirectory()}\user\journals")))
                    {
                        Directory.CreateDirectory($@"{Directory.GetCurrentDirectory()}\user\journals");
                    }
                    
                    if (New.T_groups == 2 || New.T_groups == 23)
                    {
                        path = path + @"\user\journals";
                        groupcode = "g2";
                        groupIdentifier = 2;
                        JournalCreate(groupcode,groupIdentifier);
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
                    if (!(Directory.Exists($@"{Directory.GetCurrentDirectory()}\user\journals")))
                    {
                        Directory.CreateDirectory($@"{Directory.GetCurrentDirectory()}\user\journals");
                    }
                    if (New.T_groups == 3 || New.T_groups == 23)
                    {
                        path = path + @"\user\journals";
                        groupcode = "g3";
                        groupIdentifier = 3;
                        JournalCreate(groupcode,groupIdentifier);
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

        
        public void JournalCreate(string groupcode,int identifier)
        {
            Console.Clear();
            Helper helper = new Helper();
            string studpath = Directory.GetCurrentDirectory() + @"\user\student";
            
            Journal journal = new Journal();
            int filesCount  = Directory.EnumerateFiles(studpath).Count();
            string[] studmas = new string[filesCount];
            string[] Allfile = Directory.GetFiles(studpath);

            for (int i = 0; i < filesCount; i++)
            {
                studmas[i] = Path.GetFileNameWithoutExtension(Allfile[i]);
            }
            
            journal.J_Group = identifier;
            journal.J_Student = studmas;

            int[] Marksmas = new int[filesCount];

            for (int i = 0; i < filesCount; i++)
            {
                Console.WriteLine($"{studmas[i]}:");
                try
                {
                    Marksmas[i] = Convert.ToInt32(Console.ReadLine());
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                
            }
            
            journal.J_Time = DateTime.Now;
            
            for (int i = 0; i < filesCount; i++)
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(
                        $@"{Directory.GetCurrentDirectory()}\user\journals\{groupcode}.dat", FileMode.Append)))
                    {
                        writer.Write(journal.J_Student[i]);
                        writer.Write(journal.J_Marks[i]);
                        writer.Write(journal.J_Time.ToString("g"));
                    }
            }
            Console.WriteLine("Complete!");
            

        }

        public void JpurnalUpdate()
        {
            Console.Clear();
            Helper helper = new Helper();
            
            
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