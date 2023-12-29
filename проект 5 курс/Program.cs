using System.Diagnostics;
namespace проект_5_курс
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"D:\Учеба\проект 5 курс\питон\питон.pyproj";
            start.Arguments = @"D:\Учеба\проект 5 курс\питон\питон.py";
            string pythonReturn;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            Console.WriteLine("Working start...");
            using (Process process = Process.Start(start))
            {
                using (StreamWriter se = process.StandardInput)
                {
                    if (se.BaseStream.CanWrite)
                    {
                        Console.WriteLine("enter string");
                        se.WriteLine(Console.ReadLine());
                    }
                }
                using (StreamReader sr = process.StandardOutput)
                {
                    pythonReturn = sr.ReadToEnd();
                    Console.Write(pythonReturn);
                }
            }
            Console.WriteLine("Enter path");
            TextCreator(pythonReturn, Console.ReadLine());
        }
        static void TextCreator(string input, string filePath)
        {
            List<string> strings = new List<string>();
            strings = input.Split().ToList();
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (string s in strings)
                    sw.WriteLine(s);
            }
        }
    }
    
}
