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
                        //DeleteUser();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("4");
                        //ViewUsers();
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
                    New.S_group = Convert.ToInt32(helper.InfoUsers("Группа"));
                    New.S_burthdate = Convert.ToInt32(helper.InfoUsers("Дата рождения"));
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
                    New.T_groups = Convert.ToInt32(helper.InfoUsers("Группа"));
                    New.T_disciplines = Convert.ToInt32(helper.InfoUsers("Дисциплины"));
                    New.T_burthdate = Convert.ToInt32(helper.InfoUsers("Дата рождения"));
                    New.T_age = 2020 - New.T_burthdate;
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
                    int id = helper.PersonMenu(adminStat, 0);
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
                    break;
                }
                case 2:
                {
                    path += @"\user\teacher";
                    break;
                }
            }
            
        }
        
    }
}