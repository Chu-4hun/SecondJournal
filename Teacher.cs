using Second_Journal;
﻿using System;
using System.IO;
using static Second_Journal.Program;

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
                New.T_disciplines = reader.ReadInt32();
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
                        CreateJournal();
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

        public void CreateJournal()
        {
            
        }
    }
}