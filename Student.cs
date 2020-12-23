using System;
using System.IO;
using System.Linq;
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
                        ViewJournals();
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
        public void ViewJournals()
        {
            Console.Clear();

            string studpath = Directory.GetCurrentDirectory() + @"\user\student";
            
            int filesCount  = Directory.EnumerateFiles(studpath).Count();
            string[] journalnames = new[]{"g1","g2","g3","<----"};
            
            Console.Clear();
            
            bool flag = true;
            while (flag)
            {
                switch (helper.Menu(journalnames, 0))
                {
                    case 0:
                    {
                        if (New.S_group == 1)
                        {
                            string Jname = "g1";
                            Console.WriteLine($"Журнал Номер - {Jname}");


                            using (BinaryReader reader = new BinaryReader(File.Open(
                                $@"{Directory.GetCurrentDirectory()}\user\journals\{Jname}.dat", FileMode.Open)))
                            {
                                for (int i = 0; i < filesCount; i++)
                                {
                                    Console.WriteLine(reader.ReadString());
                                    Console.WriteLine(reader.ReadInt32());
                                    Console.WriteLine(reader.ReadString());
                                    Console.WriteLine("___________________________");
                                }
                            }

                            Console.ReadKey();

                        }
                        else
                        {
                            Console.WriteLine("Wrong group!!");
                            Console.ReadKey();
                        }

                        break;
                    }
                    case 1:
                    {
                        if (New.S_group == 2)
                        {
                            string Jname = "g2";
                            Console.WriteLine($"Журнал Номер - {Jname}");
                            using (BinaryReader reader = new BinaryReader(File.Open(
                                $@"{Directory.GetCurrentDirectory()}\user\journals\{Jname}.dat", FileMode.Open)))
                            {
                                for (int i = 0; i < filesCount; i++)
                                {
                                    Console.WriteLine(reader.ReadString());
                                    Console.WriteLine(reader.ReadInt32());
                                    Console.WriteLine(reader.ReadString());
                                    Console.WriteLine("___________________________");
                                }
                            }
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Wrong group!!");
                            Console.ReadKey();
                        }
                        break;
                    }
                    case 2:
                    {
                        if (New.S_group == 3)
                        {
                            string Jname = "g3";
                            Console.WriteLine($"Журнал Номер - {Jname}");
                            
                            using (BinaryReader reader = new BinaryReader(File.Open(
                                $@"{Directory.GetCurrentDirectory()}\user\journals\{Jname}.dat", FileMode.Open)))
                            {
                                for (int i = 0; i < filesCount; i++)
                                {
                                    Console.WriteLine(reader.ReadString());
                                    Console.WriteLine(reader.ReadInt32());
                                    Console.WriteLine(reader.ReadString());
                                    Console.WriteLine("___________________________");
                                }
                            }
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Wrong group!!");
                            Console.ReadKey();
                        }
                        break;
                    }
                    case 3:
                    {
                        flag = false;
                        break;
                    }
                }
            }
        }
    }
}