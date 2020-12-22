using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MPT_Journal;
using static Second_Journal.Helper;
using static Second_Journal.Student;

namespace Second_Journal
{
    public class Program
    {
        
        public struct AdminStrtuct
        {
            public string A_login;
            public string A_password;
        }
        
        public struct StudentSruct
        {
            public string S_login;
            public string S_password;
            public string S_fio;
            public int S_burthdate;
            public int S_age;
            public int S_group;
        }
        public struct TeacherSruct
        {
            public string T_login;
            public string T_password;
            public string T_fio;
            public int T_burthdate;
            public int T_age;
            public string T_disciplines;
            public int T_groups;
        }

        public struct Journal
        {
            public int J_Group;
            public string[] J_Student;
            public int[] J_Marks;
            public DateTime J_Time;

            public void Dummy(string[] stud)
            {
                for (int i = 0; i <= 10; i++)
                {
                    J_Student[i] = stud[i];
                }
                
            }
        }
        

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;


            if (!(Directory.Exists($@"{Directory.GetCurrentDirectory()}\user")))
            {
                Directory.CreateDirectory($@"{Directory.GetCurrentDirectory()}\user");
                Directory.CreateDirectory($@"{Directory.GetCurrentDirectory()}\user\admin");
                Directory.CreateDirectory($@"{Directory.GetCurrentDirectory()}\user\student");
                Directory.CreateDirectory($@"{Directory.GetCurrentDirectory()}\user\teacher");
                Directory.CreateDirectory($@"{Directory.GetCurrentDirectory()}\user\journals");
            }

            if (!(File.Exists(Directory.GetCurrentDirectory()+@"\user\admin\admin.dat")))
            {
                AdminStrtuct Dan;
                Helper helper = new Helper();
                Dan.A_login = helper.InfoUsers("Login");
                Dan.A_password = helper.InfoUsers("Password");
                using (BinaryWriter writer = new BinaryWriter(File.Open(
                    $@"{Directory.GetCurrentDirectory()}\user\admin\{Dan.A_login}.dat", FileMode.OpenOrCreate)))
                {
                    writer.Write(Dan.A_password);
                }
            }
            else
            { 
                while (true)
                {
                    Console.Clear();
                    Console.Write("Login: ");
                    string login = Console.ReadLine();
                    Console.Write("Password: ");
                    string password = Console.ReadLine();

                    // try
                    // {
                        string path = Directory.GetCurrentDirectory();
                        int Role = 0;
                        if (File.Exists(path + $@"\user\admin\{login}.dat"))
                        {
                            path = path + $@"\user\admin\{login}.dat";
                            Role = 1;
                        }
                        else if (File.Exists(path + $@"\user\Student\{login}.dat"))
                        {
                            path = path + $@"\user\Student\{login}.dat";
                            Role = 2;
                        }
                        else if (File.Exists(path + $@"\user\teacher\{login}.dat"))
                        {
                            path = path + $@"\user\teacher\{login}.dat";
                            Role = 3;
                        }

                        string Pass;
                        using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                        {
                            Pass = reader.ReadString();
                        }

                        if (password == Pass)
                        {
                            switch (Role)
                            {
                                case 1:
                                    Admin admin = new Admin();
                                    admin.MainAdmin();
                                    Console.WriteLine(Role);
                                    break;
                                case 2:
                                    Student student = new Student();
                                    student.MainSudent(login);
                                    Console.WriteLine(Role);
                                    break;
                                case 3:
                                    Teacher teacher = new Teacher();
                                    teacher.MainTeacher(login);
                                    Console.WriteLine(Role);
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("ERR 2! Wrong Password - press ENTER");
                            Console.ReadKey();
                        }
                    // }
                    // catch
                    // {
                    //     Console.WriteLine("ERR 1! press ENTER");
                    //     Console.ReadKey();
                    // }
                }

            }
        }
    }
}