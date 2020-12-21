using System;
using System.Collections.Generic;
using System.IO;
using static Second_Journal.Program;

namespace Second_Journal
{
    public class Admin
    {
        public string[] Menu = new string[] {"Create User", "UpdateUser","Delete","View","LogOut" };
        Helper helper = new Helper();
        public void MainAdmin()
        {
            bool flag = true;
            while (flag)
            {
                switch (helper.Menu(Menu, 0))
                {
                    case 0:
                    {
                        Console.WriteLine("0");
                        CreateUser();
                        break;
                    }
                    case 1:
                    {
                        Console.WriteLine("1");
                        UpdateUser();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("2");
                        DeleteUser();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("4");
                        ViewUsers();
                        break;
                    }
                    case 4:
                    {
                        flag = false;
                        break;
                    }
                }
                Console.ReadKey();
            }
        }
        public void CreateUser()
        {
            Console.Clear();
            string[] role = new string[]{"Admin","Student","Teacher"};
            string path = Directory.GetCurrentDirectory();
            switch (helper.Menu(role,0))
            {
                case 0:
                {
                    Console.WriteLine("0");
                    
                    AdminStrtuct New;
                    New.A_login = helper.InfoUsers("Login");
                    New.A_password = helper.InfoUsers("Password");
                    
                    using (BinaryWriter writer = new BinaryWriter(File.Open(
                        $@"{Directory.GetCurrentDirectory()}\user\admin\{New.A_login}.dat", FileMode.OpenOrCreate)))
                    {
                        writer.Write(New.A_password);
                    }
                    Console.WriteLine("Complete!");
                    break;
                }
                case 1:
                {
                    Console.WriteLine("1");
                    
                    StudentSruct New;
                    New.S_login = helper.InfoUsers("Login");
                    New.S_password = helper.InfoUsers("Password");
                    New.S_fio = helper.InfoUsers("ФИО");
                    
                    New.S_group =  helper.intInfoUsers("Группа");
                    New.S_burthdate =  helper.intInfoUsers("Дата рождения");
                    New.S_age = 2020 - New.S_burthdate;
                    
                    using (BinaryWriter writer = new BinaryWriter(File.Open(
                        $@"{Directory.GetCurrentDirectory()}\user\student\{New.S_login}.dat", FileMode.OpenOrCreate)))
                    {
                        writer.Write(New.S_password);
                        writer.Write(New.S_fio);
                        writer.Write(New.S_group);
                        writer.Write(New.S_burthdate);
                        writer.Write(New.S_age);
                    }
                    Console.WriteLine("Complete!");
                    break;
                }
                case 2:
                {
                    Console.WriteLine("2");
                    
                    TeacherSruct New;
                    New.T_login = helper.InfoUsers("Login");
                    New.T_password = helper.InfoUsers("Password");
                    New.T_fio = helper.InfoUsers("ФИО");
                    Console.WriteLine("*рус яз, матем, информ*");
                    New.T_disciplines = helper.InfoUsers("Дисциплины");
                    
                    New.T_burthdate = helper.intInfoUsers("Дата рождения");
                    New.T_age = 2020 - New.T_burthdate;
                    New.T_groups = helper.intInfoUsers("Группы");
                    
                    using (BinaryWriter writer = new BinaryWriter(File.Open(
                        $@"{Directory.GetCurrentDirectory()}\user\teacher\{New.T_login}.dat", FileMode.OpenOrCreate)))
                    {
                        writer.Write(New.T_password);
                        writer.Write(New.T_fio);
                        writer.Write(New.T_groups);
                        writer.Write(New.T_disciplines);
                        writer.Write(New.T_burthdate);
                        writer.Write(New.T_age);
                    }
                    Console.WriteLine("Complete!");
                    break;
                }
            }
        }
        public void UpdateUser()
        {
            Console.Clear();
            string[] role = new string[]{"Admin","Student","Teacher"};
            string path = Directory.GetCurrentDirectory();
            switch (helper.Menu(role,0))
            {
                case 0:
                {
                    path += @"\user\admin";
                    List<AdminStrtuct> adminStat = new List<AdminStrtuct>();
                    string[] Allfile = Directory.GetFiles(path);
                    foreach (string filename in Allfile)
                    {
                        using (BinaryReader reader = new BinaryReader(File.Open(filename,FileMode.Open)))
                        {
                            adminStat.Add(new AdminStrtuct()
                                {
                                    A_login = Path.GetFileNameWithoutExtension(filename),
                                    A_password = reader.ReadString(),
                                }
                            );
                        }
                    }
                    int id = helper.AdminMenu(adminStat, 0);
                    string[] parametr = new string[]{"Login", "Password"};
                    var PersonId = adminStat[id];
                    string safeLogin = PersonId.A_login;
                    switch (helper.Menu(parametr,0))
                    {
                        case 0:
                        {
                            PersonId.A_login = helper.InfoUsers("Login");
                            File.Delete(path + $@"\{safeLogin}.dat");
                            break;
                        }
                        case 1:
                        {
                            PersonId.A_password = helper.InfoUsers("Password");
                            break;
                        }
                    }

                    using (BinaryWriter writer = new BinaryWriter(File.Open(path + $@"\{PersonId.A_login}.dat", FileMode.OpenOrCreate)))
                    {
                        writer.Write(PersonId.A_password);

                    }
                    break;
                }
                case 1:
                {
                    path += @"\user\student";
                    
                    List<StudentSruct> studentSruct = new List<StudentSruct>();
                    string[] Allfile = Directory.GetFiles(path);
                    foreach (string filename in Allfile)
                    {
                        using (BinaryReader reader = new BinaryReader(File.Open(filename,FileMode.Open)))
                        {
                            studentSruct.Add(new StudentSruct()
                                {
                                    S_login = Path.GetFileNameWithoutExtension(filename),
                                    S_password = reader.ReadString(),
                                    S_fio = reader.ReadString(),
                                    S_burthdate = reader.ReadInt32(),
                                    S_age = reader.ReadInt32(),
                                    S_group = reader.ReadInt32()
                                }
                            );
                        }
                    }
                    int id = helper.StudentMenu(studentSruct, 0);
                    string[] parametr = new string[]{"Login", "Password", "ФИО","Burthdate","Group"};
                    var PersonId = studentSruct[id];
                    string safeLogin = PersonId.S_login;
                    switch (helper.Menu(parametr,0))
                    {
                        case 0:
                        {
                            PersonId.S_login = helper.InfoUsers("Login");
                            File.Delete(path + $@"\{safeLogin}.dat");
                            break;
                        }
                        case 1:
                        {
                            PersonId.S_password = helper.InfoUsers("Password");
                            break;
                        }
                        case 2:
                        {
                            PersonId.S_fio = helper.InfoUsers("ФИО");
                            break;
                        }
                        case 3:
                        {
                            PersonId.S_burthdate = helper.intInfoUsers("Дата рождения");
                            PersonId.S_age = 2020 - PersonId.S_burthdate;
                            break;
                        }
                        case 4:
                        {
                            PersonId.S_group = helper.intInfoUsers("Группа");
                            break;
                        }
                    }

                    using (BinaryWriter writer = new BinaryWriter(File.Open(path + $@"\{PersonId.S_login}.dat", FileMode.OpenOrCreate)))
                    {
                        writer.Write(PersonId.S_password); 
                        writer.Write(PersonId.S_fio);
                        writer.Write(PersonId.S_burthdate);
                        writer.Write(PersonId.S_age);
                        writer.Write(PersonId.S_group);

                    }
                    break;
                }
                case 2:
                {
                    path += @"\user\teacher";
                    
                    List<TeacherSruct> teacherSruct = new List<TeacherSruct>();
                    string[] Allfile = Directory.GetFiles(path);
                    foreach (string filename in Allfile)
                    {
                        using (BinaryReader reader = new BinaryReader(File.Open(filename,FileMode.Open)))
                        {
                            teacherSruct.Add(new TeacherSruct()
                                {
                                    T_login = Path.GetFileNameWithoutExtension(filename),
                                    T_password = reader.ReadString(),
                                    T_fio = reader.ReadString(),
                                    T_burthdate = reader.ReadInt32(),
                                    T_age = reader.ReadInt32(),
                                    T_groups = reader.ReadInt32()
                                }
                            );
                        }
                    }
                    int id = helper.TeacherMenu(teacherSruct, 0);
                    string[] parametr = new string[]{"Login", "Password", "ФИО","Burthdate","Groups"};
                    var PersonId = teacherSruct[id];
                    string safeLogin = PersonId.T_login;
                    switch (helper.Menu(parametr,0))
                    {
                        case 0:
                        {
                            PersonId.T_login = helper.InfoUsers("Login");
                            File.Delete(path + $@"\{safeLogin}.dat");
                            break;
                        }
                        case 1:
                        {
                            PersonId.T_password = helper.InfoUsers("Password");
                            break;
                        }
                        case 2:
                        {
                            PersonId.T_fio = helper.InfoUsers("ФИО");
                            break;
                        }
                        case 3:
                        {
                            PersonId.T_burthdate = helper.intInfoUsers("Дата рождения");
                            PersonId.T_age = 2020 - PersonId.T_burthdate;
                            break;
                        }
                        case 4:
                        {
                            Console.WriteLine("*рус яз, матем, информ*");
                            PersonId.T_disciplines = helper.InfoUsers("Дисциплины");
                            break;
                        }
                        case 5:
                        {
                            PersonId.T_groups = helper.intInfoUsers("Группы");
                            break;
                        }
                    }

                    using (BinaryWriter writer = new BinaryWriter(File.Open(path + $@"\{PersonId.T_login}.dat", FileMode.OpenOrCreate)))
                    {
                        writer.Write(PersonId.T_password);
                        writer.Write(PersonId.T_fio);
                        writer.Write(PersonId.T_groups);
                        writer.Write(PersonId.T_disciplines);
                        writer.Write(PersonId.T_burthdate);
                        writer.Write(PersonId.T_age);
                    }
                    break;
                }
            }
            
        }
        public void DeleteUser()
        {
            Console.Clear();
            string[] role = new string[]{"Admin","Student","Teacher"};
            string path = Directory.GetCurrentDirectory();
            switch (helper.Menu(role,0))
            {
                case 0:
                {
                    path += @"\user\admin";
                    List<AdminStrtuct> admin = new List<AdminStrtuct>();
                    string[] Allfile = Directory.GetFiles(path);
                        foreach (string filename in Allfile)
                        {
                            using (BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open)))
                            {
                                admin.Add(new AdminStrtuct()
                                    {
                                        A_login = Path.GetFileNameWithoutExtension(filename),
                                        A_password = reader.ReadString(),
                                    }
                                );
                            }
                        }
                    int id = helper.AdminMenu(admin, 0);
                    var PersonId = admin[id];
                    File.Delete(path + $@"\{PersonId.A_login}.dat");
                    break;
                }
                case 1:
                {
                    path += @"\user\student";
                    List<StudentSruct> student = new List<StudentSruct>();
                    string[] Allfile = Directory.GetFiles(path);
                        foreach (string filename in Allfile)
                        {
                            using (BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open)))
                            {
                                student.Add(new StudentSruct()
                                    {
                                        S_login = Path.GetFileNameWithoutExtension(filename),
                                        S_password = reader.ReadString(),
                                    }
                                );
                            }
                        }
                    int id = helper.StudentMenu(student, 0);
                    var PersonId = student[id];
                    File.Delete(path + $@"\{PersonId.S_login}.dat");
                    break;
                }
                case 2:
                {
                    path += @"\user\teacher";
                    List<TeacherSruct> teacher = new List<TeacherSruct>();
                    string[] Allfile = Directory.GetFiles(path);
                        foreach (string filename in Allfile)
                        {
                            using (BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open)))
                            {
                                teacher.Add(new TeacherSruct()
                                    {
                                        T_login = Path.GetFileNameWithoutExtension(filename),
                                        T_password = reader.ReadString(),
                                    }
                                );
                            }
                        }
                    int id = helper.TeacherMenu(teacher, 0);
                    var PersonId = teacher[id];
                    File.Delete(path + $@"\{PersonId.T_login}.dat");
                    break;
                }
            }
        }
        public void ViewUsers()
        {
            Console.Clear();
            string[] role = new string[]{"Admin","Student","Teacher"};
            string path = Directory.GetCurrentDirectory();
            switch (helper.Menu(role,0))
            {
                case 0:
                {
                    path += @"\user\admin";
                    List<AdminStrtuct> admin = new List<AdminStrtuct>();
                    string[] Allfile = Directory.GetFiles(path);
                        foreach (string filename in Allfile)
                        {
                            using (BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open)))
                            {
                                admin.Add(new AdminStrtuct()
                                    {
                                        A_login = Path.GetFileNameWithoutExtension(filename),
                                        A_password = reader.ReadString(),
                                    }
                                );
                            }
                        }
                    int id = helper.AdminMenu(admin, 0);
                    break;
                }
                case 1:
                {
                    path += @"\user\student";
                    List<StudentSruct> student = new List<StudentSruct>();
                    string[] Allfile = Directory.GetFiles(path);
                        foreach (string filename in Allfile)
                        {
                            using (BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open)))
                            {
                                student.Add(new StudentSruct()
                                    {
                                        S_login = Path.GetFileNameWithoutExtension(filename),
                                        S_password = reader.ReadString(),
                                    }
                                );
                            }
                        }
                    int id = helper.StudentMenu(student, 0);
                    break;
                }
                case 2:
                {
                    path += @"\user\teacher";
                    List<TeacherSruct> teacher = new List<TeacherSruct>();
                    string[] Allfile = Directory.GetFiles(path);
                        foreach (string filename in Allfile)
                        {
                            using (BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open)))
                            {
                                teacher.Add(new TeacherSruct()
                                    {
                                        T_login = Path.GetFileNameWithoutExtension(filename),
                                        T_password = reader.ReadString(),
                                    }
                                );
                            }
                        }
                    int id = helper.TeacherMenu(teacher, 0);
                    break;
                }
            }
        }
    }
}