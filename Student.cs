using System;

namespace Second_Journal
{
    public class Student
    {
        public string[] Menu = new string[] {"dd", "Journals","LogOut" };
        Helper helper = new Helper();
        public void MainSudent()
        {
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
    }
}