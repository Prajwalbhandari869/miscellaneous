using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class SplitAndRemove
    {
        public void ReWrite(string filePath)
        {
            try
            {
                if (!File.Exists($"C:/Users/USER/Desktop/IOEPulchowk/Practice C#/val.txt"))
                {
                    FileStream file = File.Create($"C:/Users/USER/Desktop/IOEPulchowk/Practice C#/val.txt");
                    file.Close();
                }
                using (StreamReader reader = new StreamReader($"{filePath}file-text.txt"))
                {
                    using (StreamWriter writer = new StreamWriter($"C:/Users/USER/Desktop/IOEPulchowk/Practice C#/val.txt"))
                    {
                        string? line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            var parts = line.Split("\t");
                            writer.Write($"{parts[0]}|");
                            writer.Write($"{parts[1]}");
                            writer.WriteLine();
                            writer.Flush();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                throw;
            }
        }
    }
}
