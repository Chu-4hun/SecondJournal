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
        public void MainTeacher()
        {
            
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
            //Path.GetDirectoryName()
        }
    }
}