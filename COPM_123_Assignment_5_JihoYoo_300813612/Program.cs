/* 
 *  Author's name:Jiho Yoo 
 *  Date : 3/20/2015
 *  Program description : Using File I/O and Exception Handling 
 *  Revision History : Date         Description 
 *                    3/12/2015     Create a grade File that contains student data.
 *                    3/13/2015     Create MainMenu and set up the swith to connect each menus
 *                    3/17/2015     Set Exception and show exist file.
 *                    3/20/2015     Find out some error.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // need this for any system Input and Output

namespace COPM_123_Assignment_5_JihoYoo_300813612
{
    class Program
    {
        static void Main(string[] args)
        {

            MainMenu();
            WaitForKey();
        }

        // Main menu Utility Method
        public static void MainMenu()
        {
            string pathName = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
           //string pathName = "C:\\Users\\Jiho\\Desktop\\COPM_123_Assignment_5_JihoYoo_300813612\\COPM_123_Assignment_5_JihoYoo_300813612\\";
           string fileName = "classGrade.txt"; // file name



           int selection = 0; // default selection

            while (selection != 2)
            {
                Console.WriteLine("* File Location : ");
                Console.WriteLine("{0}",pathName);
                Console.WriteLine("+++++++++++++++++++++++++++");
                Console.WriteLine("+        - Menu -         +");
                Console.WriteLine("+                         +");
                Console.WriteLine("+    1. Display Grades    +");
                Console.WriteLine("+    2. Exit              +");
                Console.WriteLine("+                         +");
                Console.WriteLine("+++++++++++++++++++++++++++");
                Console.Write("Please make your selection: ");

                try
                {
                    selection = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                    selection = 0;
                }
                switch (selection)
                {
                    case 1:
                        WriteFileMethod(pathName, fileName);
                        ReadFileMethod(pathName, fileName);
                        break;
                    case 2:
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Incorrect entry. Please try again....\n");
                        break;
                }
               
            }
            Console.Clear(); // Clears the screen
        }

        // Write File Method
        private static void WriteFileMethod(string pathName, string fileName)
        {
           
            try
            {
                FileStream outFile = new FileStream(pathName + fileName, FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(outFile);

                // Write Student information and grades
                string[] firstName = { "Janes", "Johnson", "Smith", "David", "Jacob" };
                string[] lastName = { "Bob", "Sarah", "Sam", "Lee", "Sung" };
                int[] id = { 1, 2, 3, 4, 5 };
                string[] classes = { "Introduction to Computer Science", "Data Structures", "Data Structures", "English", "Math" };
                string[] grade = { "A-", "B+", "C", "A+", "B-" };

                //wite data to the outFIle
                for (int i = 0; i < 5; i++)
                {
                    writer.WriteLine("{0}, {1}: {2} {3}, {4}", firstName[i], lastName[i], id[i], classes[i], grade[i]);
                }


                writer.Close(); // closes the file
                outFile.Close(); // closes the  file stream
            }
                //Exception
            catch (Exception error)
            {
                Console.WriteLine("No such file");
                Console.WriteLine("Error: {0} ", error.Message);

            }
        }

        // Read File Method
        private static void ReadFileMethod(string pathName, string fileName)
        {
            string fileData = "";
            string[] fileArray = new string[5];
            Console.Write("Name of the file: "); //Wehn the Display grades option is selected ask it
            fileName = Console.ReadLine();
            try
            {
                FileStream inFile = new FileStream(pathName + fileName, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);

                for (int row = 0; row < 5; row++)
                {
                    fileData = reader.ReadLine();
                    fileArray[row] = fileData;

                    Console.WriteLine("{0}", fileData);
                } // Read one record (line of data)
                reader.Close(); // closes the file
                inFile.Close(); // closes the  file stream
            }
            catch (Exception error)
            {
                Console.WriteLine("No such file");
                Console.WriteLine("Error: {0} ", error.Message);

            }
        }
  
        // UTILITY METHOD ++++++++++++++++++++++++++++++++++++++
        public static void WaitForKey()
        {
            Console.WriteLine();
            Console.WriteLine("+++++++++++++++++++++++++++");
            Console.WriteLine("Press any key to exit....");
            Console.WriteLine("+++++++++++++++++++++++++++");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
