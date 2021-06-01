using System;
using System.IO;


namespace Rainbow_Schools
{
    class Program
    {
        static readonly string StudentsDataFile = "C:\\Users\\amina\\Desktop\\.NET developer Course\\Rainbow Schools\\Rainbow Schools Students.txt";
        static void Main(string[] args)
        {
            if (File.Exists(StudentsDataFile))
            {
                // Read entire text file content in one string  .  
                string text = File.ReadAllText(StudentsDataFile);
                Console.WriteLine(text);
            }
            Console.ReadKey();
        }
        
    }
}
