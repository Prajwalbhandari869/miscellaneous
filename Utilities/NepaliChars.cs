using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class NepaliChars
    {
        public void Sort(string filePath)
        {
            try
            {
                List<string> tokens = new List<string>();
                if (!File.Exists($"C:/Users/USER/Desktop/IOEPulchowk/Practice C#/NepaliTokensSorted.txt"))
                {
                    FileStream file = File.Create($"C:/Users/USER/Desktop/IOEPulchowk/Practice C#/NepaliTokensSorted.txt");
                    file.Close();
                }
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        line = line.Replace('\t', ' ').Trim();
                        tokens.Add(line);
                    }
                }
                tokens.Sort();
                using (StreamWriter writer = new StreamWriter($"C:/Users/USER/Desktop/IOEPulchowk/Practice C#/NepaliTokensSorted.txt"))
                {
                    foreach (var token in tokens)
                    {
                        writer.Write(token);
                        writer.WriteLine();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void CreateSyllabus(string sourcePath, string destinationPath)
        {
            try
            {
                if (!File.Exists($"{destinationPath}"))
                {
                    FileStream file = File.Create($"{destinationPath}");
                    file.Close();
                }
                StringBuilder syllabus = new StringBuilder();
                using (StreamReader reader = new StreamReader(sourcePath))
                {                    
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        syllabus.Append($"\"{line.Trim()}\", ");
                    }
                }
                using (StreamWriter writer = new StreamWriter(destinationPath))
                {
                    writer.Write(syllabus.ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }            
        }
    }
}
