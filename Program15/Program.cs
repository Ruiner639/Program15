using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Program15
{
    class Program
    {
        static void Main(string[] args)
        {
            string answer = "";
            int id = 1;
            string path = @"C:\Users\1392659\Desktop\prog15\Person\";
            Console.WriteLine("Do you want to add person or find information about some person ?(add,find)");
            answer = Console.ReadLine();
            while (((answer == "add") || (answer == "find")) != true)
            {
                try
                {
                    Console.WriteLine("Enter corrcet answer");
                    answer = Console.ReadLine();
                }
                catch (Exception q)
                {
                    Console.WriteLine(q);
                }
            }
            if (answer == "find")
            {
                Console.WriteLine("Enter Person ID: ");
                while (true)
                {
                    try
                    {
                        id = Convert.ToInt32(Console.ReadLine());
                        if (File.Exists(path + id + ".txt"))
                        {
                            using(StreamReader sr = new StreamReader(path + id + ".txt"))
                            {
                                while (true)
                                {
                                    string j = sr.ReadLine();
                                    if (j == null)
                                    {
                                        break;
                                    }
                                    Console.WriteLine(j);
                                }
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("file does not exist");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("You entered letters or the string is empty, try again");
                    }
                }
            }
            if(answer == "add")
            {
                while (File.Exists(path + id + ".txt"))
                {
                    id++;
                }
                using (StreamWriter sw = new StreamWriter(path + id + ".txt"))
                {
                    Console.WriteLine("Enter your name:");
                    string name = Console.ReadLine();
                    while ((name == "") != false)
                    {
                        Console.WriteLine("Please enter your name");
                        name = Console.ReadLine();
                    }
                    int age = 0;
                    while (((age >= 1) && (age <= 100)) != true)
                    {
                        try
                        {
                            Console.WriteLine("Enter your age:");
                            age = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Error,try again");
                        }
                    }
                    Console.WriteLine("Enter your email(not necessary):");
                    string email = Console.ReadLine();
                    while (((email == "") || (email.Contains("@"))) != true)
                    {
                        Console.WriteLine("Please enter correct email");
                        email = Console.ReadLine();
                    }
                    sw.WriteLine("Person ID: " + id);
                    sw.WriteLine("Name: " + name);
                    sw.WriteLine("Age: " + age);
                    if (email == "")
                    {
                        sw.WriteLine("Email: none");
                    }
                    else
                    {
                        sw.WriteLine("Email: " + email);
                    }

                }
            }
        }
               
    }
}
