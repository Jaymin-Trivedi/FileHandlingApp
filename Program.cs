using System;
using System.IO;

namespace FileHandlingApp
{
    class Program
    {
        class FileWrite
        {
            public void WriteInFile()
            {
                FileStream fs = new FileStream("C:\\Users\\JAYMIN\\source\\repos\\FileHandlingApp\\demo.txt", FileMode.Append,FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                Console.WriteLine("Enter text you want to write in file : \n");
                string data = Console.ReadLine();
                sw.WriteLine(data);
                sw.Flush();
                sw.Close();
                fs.Close();
            }
        }
        class FileRead
        {
            public void ReadInFile()
            {
                FileStream fs = new FileStream("C:\\Users\\JAYMIN\\source\\repos\\FileHandlingApp\\demo.txt",FileMode.Open,FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                string str = sr.ReadLine();
                while(str!=null)
                {
                    Console.WriteLine(str);
                    str = sr.ReadLine();
                }
                Console.ReadLine();
                sr.Close();
                fs.Close();
            }
        }
        static void Main(string[] args)
        {
            /* FileWrite fw = new FileWrite();
             fw.WriteInFile();*/
            Program p = new Program();
           /* FileRead fr = new FileRead();
            fr.ReadInFile();*/
            int choice;
            while(true)
            {
                Console.Write("\n(1) Copy a file\n(2) Rename a file\n(3) Concatenate two files\n(4) Create a file\n(5)  DIsplay Contents of file\n(6) Exit\nChoose any action from above list : ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        p.Copy();
                        break;
                    case 2:
                        p.Rename();
                        break;
                    case 3:
                        p.Concate();
                        break;
                    case 4:
                        p.CreateFile();
                        break;
                    case 5:
                        p.Display();
                        break;
                    case 6:
                        System.Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
            

        }

        private void Display()
        {
            Console.Write("\nEnter File name you want to display : ");
            string fileName = Console.ReadLine();
            FileStream fs = new FileStream("C:\\Users\\JAYMIN\\source\\repos\\FileHandlingApp\\demo.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string str = sr.ReadLine();
            while (str != null)
            {
                Console.WriteLine(str);
                str = sr.ReadLine();
            }
            //Console.ReadLine();
            sr.Close();
            fs.Close();
        }

        private void CreateFile()
        {
            Console.Write("\nEnter File name to create file : ");
            string fileName = Console.ReadLine();

            StreamWriter sw = new StreamWriter("C:\\Users\\JAYMIN\\source\\repos\\FileHandlingApp\\"+fileName+".txt");

            Console.WriteLine("File has been created..");

        }

        private void Concate()
        {
            Console.Write("\nEnter first File name  : ");
            string sourceFile1 = Console.ReadLine();

            Console.Write("\nEnter new coppied file name : ");
            string sourceFile2 = Console.ReadLine();

            Console.Write("\nEnter target File name  : ");
            string targetFile = Console.ReadLine();

            //data from file 1
            StreamReader sr1 = new StreamReader("C:\\Users\\JAYMIN\\source\\repos\\FileHandlingApp\\" + sourceFile1 + ".txt");
            sr1.BaseStream.Seek(0, SeekOrigin.Begin);
            string str1 = sr1.ReadLine();
            while (str1 != null)
            {
                Console.WriteLine(str1);
                str1 = sr1.ReadLine();
            }

            //data from file 2
            StreamReader sr2 = new StreamReader("C:\\Users\\JAYMIN\\source\\repos\\FileHandlingApp\\" + sourceFile2 + ".txt");
            sr2.BaseStream.Seek(0, SeekOrigin.Begin);
            string str2 = sr2.ReadLine();
            while (str2 != null)
            {
                Console.WriteLine(str2);
                str2 = sr2.ReadLine();
            }

            StreamWriter sw = new StreamWriter("C:\\Users\\JAYMIN\\source\\repos\\FileHandlingApp\\" + targetFile + ".txt");
            sw.WriteLine(str1 + " " + str2);

            Console.WriteLine("Concatinated..");




        }

        private void Rename()
        {
            Console.Write("\nEnter File name which you want to rename : ");
            string fileName = Console.ReadLine();
            Console.Write("\nEnter new file name : ");
            string newName = Console.ReadLine();

            FileInfo fi = new FileInfo("C:\\Users\\JAYMIN\\source\\repos\\FileHandlingApp\\" + fileName + ".txt");



            if(fi.Exists)
            {
                fi.MoveTo("C:\\Users\\JAYMIN\\source\\repos\\FileHandlingApp\\" + newName + ".txt");
                Console.WriteLine("File name has been changed..");
            }
        }

        private void Copy()
        {
            Console.Write("\nEnter File name which you want to copy : ");
            string sourceFile = Console.ReadLine();

            Console.Write("\nEnter new coppied file name : ");
            string destFile = Console.ReadLine();

            File.Delete("C:\\Users\\JAYMIN\\source\\repos\\FileHandlingApp\\" + destFile + ".txt");

            File.Copy("C:\\Users\\JAYMIN\\source\\repos\\FileHandlingApp\\" + sourceFile + ".txt", "C:\\Users\\JAYMIN\\source\\repos\\FileHandlingApp\\" + destFile + ".txt");

            Console.WriteLine("File has been coppied..");
        } 
    }
}
