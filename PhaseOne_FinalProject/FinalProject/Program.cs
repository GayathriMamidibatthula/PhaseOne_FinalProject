using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace FinalProject
{
    struct Teacher
    {
        public int ID;
        public string Name;
        public string Class_Section;

    }

    public class Data
    {

        public void WriteData()
        {
            Teacher teacher;

            //Writing data to Teacher's record file
            try
            {
                Console.Write("Enter the Teacher's ID: ");
                teacher.ID = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the Teacher's Name: ");
                teacher.Name = Console.ReadLine();
                Console.Write("Enter the Teacher's Class and Section: ");
                teacher.Class_Section = Console.ReadLine();


                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("C:\\Users\\gayathri_sri_mamidib\\Desktop\\Test.txt");

                sw.WriteLine("Teacher ID\t Teacher Name\t Teacher Class and Section");
                sw.Write(teacher.ID + "\t\t" + teacher.Name + "\t\t" + teacher.Class_Section);

                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Teacher data has been successfully stored!");
                Console.WriteLine("--------------------------------------------");
            }

        }
        public void ReadData()
        {
            try
            {
                //Reading data from a file
                // Read file using StreamReader. Reads file line by line 
                StreamReader file = new StreamReader("C:\\Users\\gayathri_sri_mamidib\\Desktop\\Test.txt");
                using (file)
                {
                    int counter = 0;
                    string ln;

                    while ((ln = file.ReadLine()) != null)
                    {
                        Console.WriteLine(ln);
                        counter++;
                    }
                    file.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("------------------------------------");
            }



        }
        public void Append()
        {
            try
            {
                // StreamWriter sa = new StreamWriter("C:\\Users\\gayathri_sri_mamidib\\Desktop\\Test.txt");
                using (StreamWriter sa = File.AppendText("C:\\Users\\gayathri_sri_mamidib\\Desktop\\Test.txt"))
                {
                    Teacher teacher;
                    Console.Write("Enter the Teacher's ID: ");
                    teacher.ID = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the Teacher's Name: ");
                    teacher.Name = Console.ReadLine();
                    Console.Write("Enter the Teacher's Class and Section: ");
                    teacher.Class_Section = Console.ReadLine();


                    //Pass the filepath and filename to the StreamWriter Constructor
                    sa.WriteLine();

                    sa.Write(teacher.ID + "\t\t" + teacher.Name + "\t\t" + teacher.Class_Section);
                    sa.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Data appended successfully!");
                Console.WriteLine("--------------------------------------");
            }

        }

        public void Update()
        {
            try
            {
                Teacher teacher;
                Console.WriteLine("Enter the Teacher ID to be updated");
                var text = Console.ReadLine();
                Console.WriteLine("Enter the updated Teacher Name: ");
                teacher.Name = Console.ReadLine();
                Console.WriteLine("Enter the updated Class and Section: ");
                teacher.Class_Section = Console.ReadLine();

                string path = @"C:\Users\gayathri_sri_mamidib\Desktop\Test.txt";
                int counter = 0;
                string line;
                StreamReader updatedfile = new StreamReader(path);
                while ((line = updatedfile.ReadLine()) != null)
                {
                    if (line.Contains(text))
                    {
                        break;
                    }
                    counter++;
                }

                //Console.WriteLine("Teacher id is present at line number: {0}", counter);
                Console.WriteLine("File record has been successfully updated!");

                updatedfile.Close();
                string lines = File.ReadLines(path).ElementAt(counter);
                string modified = text + "\t\t" + teacher.Name + "\t\t" + teacher.Class_Section;
                string[] arrLine = File.ReadAllLines(path);
                arrLine[counter] = modified;
                File.WriteAllLines(path, arrLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("----------------------------------------");
            }


        }
    }


    class Program
    {
        public static void Main(string[] args)
        {
            Data data = new Data();
            Console.WriteLine("Welcome to Rainbow School!");
            while (true)
            {

                Console.WriteLine("Enter the operation you would like to perform");
                Console.WriteLine("1. Store Teacher Records");
                Console.WriteLine("2. View  teacher records ");
                Console.WriteLine("3. Update teacher records");
                Console.WriteLine("4. Add new teacher records");
                Console.WriteLine("5. Exit the process");

                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        data.WriteData();
                        break;

                    case 2:
                        data.ReadData();
                        break;
                    case 3:
                        data.Update();
                        break;
                    case 4:
                        data.Append();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Sorry, the option you chose is incorrect. Please re enter the option and try again");
                        break;
                }

            }

        }


    }

}
