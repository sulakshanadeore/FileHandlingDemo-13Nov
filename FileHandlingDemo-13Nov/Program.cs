using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;
using System.Net.Http;
namespace FileHandlingDemo_13Nov
{
    internal class Program
    {
      public  static List<Products> productList = new List<Products>() {
        
        new Products{Prodid=100,ProdName="Tea",Price=10 },
        new Products{ Prodid=101,ProdName="Green Tea",Price=10 },
        new Products{ Prodid=102,ProdName="Ginger Tea",Price=10 }

        };
        static void Main(string[] args)
        {
            FileStream fs=null;
            StreamWriter sw=null;
            try
            {
                fs = new FileStream("errorfile.txt", FileMode.Create, FileAccess.Write );
                sw = new StreamWriter(fs);
                ProductUtility utility = new ProductUtility();
                Console.WriteLine("Enter productid :");
                int prodid = Convert.ToInt32(Console.ReadLine());
                Products productFound = utility.FindProduct(prodid);
                Console.WriteLine(productFound.Prodid);
                Console.WriteLine(productFound.ProdName);
                Console.WriteLine(productFound.Price);
            }
            catch (ProductNotFoundException ex)
            {
                
                
                sw.Write(ex.Message);
            }
            finally
                        {
                fs.Flush();
                sw.Close();
                sw.Dispose();
            
                fs.Close();
                fs.Dispose();    
                
                

            
            
            }





         //   File.WriteAllText("errorFile.txt", ex.Message);//bin/debug
            //File.AppendAllText("file1.txt", "This is appended content");
            //File.WriteAllText(@"D:\AllDemos\CAPG_Nov\file2.txt", "This is the way to give the path, use @or use \\ or use /");
            //string text= File.ReadAllText(@"D:\AllDemos\CAPG_Nov\file2.txt");
            //            Console.WriteLine(text);

            //Directory.CreateDirectory("FirstDir");
            //Directory.CreateDirectory("D:\\AllDemos\\CAPG_Nov\\FileHandlingDemo-13Nov\\FileHandlingDemo-13Nov\\bin\\Debug\\FirstDir\\SecondDir");
            //File.Copy("file1.txt", "secondfile.txt");
            //File.Move("file1.txt", "D:\\AllDemos\\CAPG_Nov\\FileHandlingDemo-13Nov\\FileHandlingDemo-13Nov\\bin\\Debug\\FirstDir\\SecondDir\\firstfilecopy.txt");
            //  File.Delete("D:\\AllDemos\\CAPG_Nov\\FileHandlingDemo-13Nov\\FileHandlingDemo-13Nov\\bin\\Debug\\FirstDir\\SecondDir\\firstfilecopy.txt");

            //string s=Path.GetDirectoryName("D:\\AllDemos\\CAPG_Nov\\FileHandlingDemo-13Nov\\FileHandlingDemo-13Nov\\bin\\Debug\\FirstDir\\SecondDir");
            //Console.WriteLine(s);

            ////File/Directory/Path--- static classes
            ////FileInfo/DirectoryInfo/DriveInfo======instance methods/ object of class required

            //FileInfo fi = new FileInfo("secondfile.txt");
            //Console.Write("Time= " + fi.CreationTime);
            //Console.WriteLine("Fullname=" + fi.FullName);
            //Console.WriteLine("Directory Name=" + fi.DirectoryName);
            //Console.WriteLine("Does it exists=" + fi.Exists);
            //Console.WriteLine("Extension=" + fi.Extension);

            //FileModes--> Create,CreateOrOpen,Open,Append,Truncate
            //FileAccess---->Read,Write,ReadWrite


            //StreamWriter---writing, create and write
            //StreamReader---reading, open and read
            //            CreateAndWriteATextFile();
            //OpenAndReadTextFile();

            //CreateAndWriteABinaryFile();
            //OpenAndReadBinaryFile();

           // Console.WriteLine("Done");
            Console.ReadLine();
        }

        private static void OpenAndReadBinaryFile()
        {
            FileStream fs = new FileStream("file4.dat", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] data = br.ReadBytes(10);
            Console.WriteLine(data);
            br.Close();
            br.Dispose();
            fs.Close();
            fs.Dispose();
        }

        private static void CreateAndWriteABinaryFile()
        {
            FileStream fs = new FileStream("file4.dat", FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(011);
            bw.Write(100);
            bw.Close();
            bw.Dispose();
            fs.Close();
            fs.Dispose();
        }

        private static void OpenAndReadTextFile()
        {
            FileStream fs = null;
            StreamReader sr = null;
            try
            {

                fs = new FileStream("file3.txt", FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);//text files
                string s = sr.ReadToEnd();
                Console.WriteLine(s);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                sr.Close();
                sr.Dispose();
                fs.Close();
                fs.Dispose();


            }
        }

        private static void CreateAndWriteATextFile()
        {
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {

                fs = new FileStream("file3.txt", FileMode.Create, FileAccess.Write);
                string msg = "Product Not found exception occured...../";
                sw = new StreamWriter(fs);//text files
                sw.Write(msg);
                sw.Flush();//write buffer to the file

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                sw.Close();
                sw.Dispose();
                fs.Close();
                fs.Dispose();


            }
        }
    }
}
