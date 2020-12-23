using System;
using System.IO;
using static Second_Journal.Program;
namespace Second_Journal
{
    public class Student
    {
        public string[] Menu = new string[] {"Journals", "LogOut",};
        Helper helper = new Helper();
        StudentStrtuct New;
        string path = Directory.GetCurrentDirectory();
        public void MainSudent(string login)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(path + $@"\user\student\{login}.dat", FileMode.Open)))
            {
                New.S_login = Path.GetFileNameWithoutExtension(path);
                New.S_password = reader.ReadString();
                New.S_fio = reader.ReadString();
                New.S_group = reader.ReadInt32();
                New.S_burthdate = reader.ReadInt32();
                New.S_age = 2020 - New.S_burthdate;
            }

            bool flag = true;
            while (flag)
            {
                switch (helper.Menu(Menu, 0))
                {
                    case 0:
                    {
                        Console.WriteLine("Not ready yet");
                        break;
                    }
                    case 1:
                    {
                        flag = false;
                        break;
                    }
                    
                }
                Console.ReadKey();
            }
        }
    }
}