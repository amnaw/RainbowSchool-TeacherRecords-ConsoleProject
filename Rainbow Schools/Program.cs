using System;
using System.IO;
using System.Linq;

namespace Rainbow_Schools
{
    class Program
    {
        static readonly string StudentsDataFile = "C:\\Users\\amina\\Desktop\\.NET developer Course\\Rainbow Schools\\Rainbow Schools Teachers.txt";
        
        static void Main(string[] args)
        {
            if (File.Exists(StudentsDataFile))
            {
                // Read entire text file content in one string  .  
                string text = File.ReadAllText(StudentsDataFile);
                // Retrieve teacher data
                Console.WriteLine("Rainbow School - teachers' data" + "\n\n" + text);

                // Store teacher data
                Console.WriteLine("Do you want to add new teacher ? (Y/N)");
                var anwser = Console.ReadLine();
                anwser = anwser.ToString().ToUpper();
                if (anwser == "Y")
                {
                    Console.WriteLine("ID: ");
                    var teacherData = "ID: " + Console.ReadLine();
                    Console.WriteLine("Name: ");
                    teacherData = teacherData + "\n" + "Name: " + Console.ReadLine();
                    Console.WriteLine("Class: ");
                    teacherData = teacherData + "\n" + "Class: " + Console.ReadLine();
                    Console.WriteLine("Section: ");
                    teacherData = teacherData + "\n" + "Section: " + Console.ReadLine();

                    // Write file using StreamWriter  
                    using (StreamWriter writer = new StreamWriter(StudentsDataFile))
                    {
                        writer.WriteLine(text + "\n\n" + teacherData);

                    }
                }


                // Update teacher data
                Console.WriteLine("Do you want to update teacher's data ? (Y/N)");
                var anwser3 = Console.ReadLine();
                anwser3 = anwser3.ToString().ToUpper();
                if (anwser3 == "Y")
                {
                    Console.WriteLine("Enter the ID of the teacher you want to update ?");
                    var id = "ID: " + Console.ReadLine();
                    // grab all of its info until the next ID
                    var teacherInto = File.ReadLines(StudentsDataFile)
                   .SkipWhile(line => !line.Contains(id))
                   .Skip(1) // optional
                   .TakeWhile(line => !line.Contains("ID"));

                    Console.WriteLine("--Enter New Data-- \n");
                    var teacherData2 = id;

                    Console.WriteLine("New Name: ");
                    var newName = Console.ReadLine();

                    Console.WriteLine("New Class: ");
                    var newClass = Console.ReadLine();

                    Console.WriteLine("New Section: ");
                    var newSection = Console.ReadLine();

                    string text2 = File.ReadAllText(StudentsDataFile);
                    text2 = text2.Replace(teacherInto.ElementAt(0), "Name: " + newName);
                    text2 = text2.Replace(teacherInto.ElementAt(1), "Class: " + newClass);
                    text2 = text2.Replace(teacherInto.ElementAt(2), "Section: " + newSection);

                    // Write file using StreamWriter  
                    using (StreamWriter writer = new StreamWriter(StudentsDataFile))
                    {
                        writer.WriteLine(text2);

                    }

                    Console.WriteLine("\nUPDATE DONE  of teacher of " + id);

                }

                // Retrieve specific teacher data
                Console.WriteLine("Do you want to display specific teacher's data ? (Y/N)");
                var anwser2 = Console.ReadLine();
                anwser2 = anwser2.ToString().ToUpper();
                if (anwser2 == "Y")
                {
                    Console.WriteLine("Enter the ID of the teacher you want to show its data: ");
                    var anwser4 = Console.ReadLine();
                    // grab all of its info until the next ID
                    var id2 = "ID: " + anwser4;
                    var teacherInto2 = File.ReadLines(StudentsDataFile)
                   .SkipWhile(line => !line.Contains(id2))
                   .Skip(1) // optional
                   .TakeWhile(line => !line.Contains("ID"));

                    Console.WriteLine("\n" + id2 + "\n" + teacherInto2.ElementAt(0) + "\n" + teacherInto2.ElementAt(1) + "\n" + teacherInto2.ElementAt(2));
                }
                Console.ReadKey();
            }

        }
    }
}
