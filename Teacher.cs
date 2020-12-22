using System;
using System.IO;
using System.Linq;
using static Second_Journal.Program;

namespace Second_Journal
{
    public class Teacher
    {
        public string[] Menu = new string[] {"CreateJournal", "View Journals","edit marks","LogOut" };
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
                        ViewJournals(New.T_groups);
                        break;
                    }
                    case 2:
                    {
                        ViewJournals(New.T_groups);
                        break;
                    }
                    case 3:
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
                    if (!(Directory.Exists($@"{Directory.GetCurrentDirectory()}\user\journals")))
                    {
                        Directory.CreateDirectory($@"{Directory.GetCurrentDirectory()}\user\journals");
                    }

                    if (New.T_groups == 1)
                    {
                        path = path + @"\user\journals";
                        JournalCreate("g1",1);
                    }
                    else
                    {
                        Console.WriteLine("Wrong group!!");
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
                        JournalCreate("g2",2);
                    }
                    else
                    {
                        Console.WriteLine("Wrong group!!");
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
                        JournalCreate("g3",3);
                    }
                    else
                    {
                        Console.WriteLine("Wrong group!!");
                    }
                    
                    
                    break;
                }
            }
        }

        
        public void JournalCreate(string groupcode,int identifier)
        {
            Console.Clear();
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

            journal.J_Marks = Marksmas;
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

        public void ViewJournals(int groups)
        {
            Console.Clear();
            Helper helper1 = new Helper();
            
            string studpath = Directory.GetCurrentDirectory() + @"\user\student";
            
            int filesCount  = Directory.EnumerateFiles(studpath).Count();
            string[] journalnames = new[]{"g1","g2","g3","<----"};
            
            Console.Clear();
            
            bool flag = true;
            while (flag)
            {
                switch (helper1.Menu(journalnames, 0))
                {
                    case 0:
                    {
                        if (New.T_groups == 1)
                        {
                            string Jname = "g1";
                            Console.WriteLine($"Журнал Номер - {Jname}");
                            for (int i = 0; i < filesCount; i++)
                            {
                                using (BinaryReader reader  = new BinaryReader(File.Open(
                                    $@"{Directory.GetCurrentDirectory()}\user\journals\{Jname}.dat", FileMode.Open)))
                                {
                                    Console.WriteLine(reader.ReadString());
                                    Console.WriteLine(reader.ReadInt32());
                                    Console.WriteLine(reader.ReadString());
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Wrong group!!");
                        }

                        break;
                    }
                    case 1:
                    {
                        if (New.T_groups == 2 || New.T_groups == 23)
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
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Wrong group!!");
                        }
                        break;
                    }
                    case 2:
                    {
                        if (New.T_groups == 3 || New.T_groups == 23)
                        {
                            string Jname = "g3";
                            Console.WriteLine($"Журнал Номер - {Jname}");
                            for (int i = 0; i < filesCount; i++)
                            {
                                using (BinaryReader reader  = new BinaryReader(File.Open(
                                    $@"{Directory.GetCurrentDirectory()}\user\journals\{Jname}.dat", FileMode.Open)))
                                {
                                    Console.WriteLine(reader.ReadString());
                                    Console.WriteLine(reader.ReadInt32());
                                    Console.WriteLine(reader.ReadString());
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Wrong group!!");
                        }
                        break;
                    }
                    case 3:
                    {
                        flag = false;
                        break;
                    }
                }
                Console.ReadKey();
            }
            
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
                }
                case 13:
                {
                    goto case 1;
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