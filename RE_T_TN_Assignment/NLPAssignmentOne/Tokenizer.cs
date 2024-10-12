using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace RE_T_TN_Assignment
{
    public class Tokenizer
    {
        private static string mappedFile = $"Mapped.txt";
        private static string reducedFile = $"Reduced.txt";
        private static string tokenizedFile = $"tokens.txt";

        public async Task Mapper(string fileContent, string filePath)
        {
            try
            {
                char[] needToReplaceChars = ['\n', '.', /*',',*/ '\'', '"', ':', ';', '`', '[', ']', /*'(', ')',*/ /*'-',*/ '–', '’', '“', '”', ' ', '|'/*, '।'*/];
                foreach (char replaceChar in needToReplaceChars)
                {
                    fileContent = fileContent.Replace(replaceChar, ' ');
                }
                fileContent = Regex.Replace(fileContent, @"\s+", " ").Trim();
                fileContent = Regex.Replace(fileContent, @"\b(nep_)(\d{4}_)(\d{10})\b", " ").Trim();
                fileContent = Regex.Replace(fileContent, @"\b(Voice)(\d{1}|\d{2}|\d{3}|\d{4})\b", " ").Trim();
                var tokens = fileContent.Trim().Split(' ');


                if (!File.Exists($"{filePath}{mappedFile}"))
                {
                    FileStream file = File.Create($"{filePath}{mappedFile}");
                    file.Close();
                }
                using (StreamWriter writer = new StreamWriter($"{filePath}{mappedFile}"))
                {
                    foreach (var token in tokens)
                    {
                        writer.WriteLine("{0}  {1}", token, 1);
                    }
                }
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task Cleaner(string filePath)
        {
            try
            {
                if (!File.Exists($"{filePath}{tokenizedFile}"))
                {
                    FileStream file = File.Create($"{filePath}{tokenizedFile}");
                    file.Close();
                }
                List<string> tokens = new List<string>();
                using (StreamReader reader = new StreamReader($"{filePath}{reducedFile}"))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split("--->");
                        tokens.Add(parts[0]);
                    }
                }
                using (StreamWriter writer = new StreamWriter($"{filePath}{tokenizedFile}", false))
                {
                    foreach (var token in tokens)
                    {
                        writer.Write(token);
                        writer.Write('\t');
                        foreach (var letter in token)
                        { 
                            writer.Write(letter);
                            writer.Write(' ');
                        }
                        writer.WriteLine();
                        writer.Flush();
                    }
                }

                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task Reducer(string filePath)
        {
            try
            {
                Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
                using (StreamReader reader = new StreamReader($"{filePath}{mappedFile}"))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split("  ");
                        string currentWord = parts[0];
                        int count = Convert.ToInt32(parts[1]);
                        if (keyValuePairs.ContainsKey(currentWord))
                        {
                            keyValuePairs[currentWord] = keyValuePairs[currentWord] + count;
                        }
                        else
                        {
                            keyValuePairs.Add(currentWord, count);
                        }
                    }
                }
                if (!File.Exists($"{filePath}{reducedFile}"))
                {
                    FileStream file = File.Create($"{filePath}{reducedFile}");
                    file.Close();
                }
                using (StreamWriter writer = new StreamWriter($"{filePath}{reducedFile}", false))
                {
                    foreach (var pair in keyValuePairs)
                    {
                        writer.WriteLine("{0}--->{1}", pair.Key, pair.Value);
                    }
                }
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        public void TokenizeNepaliWords(string filePath)
        {
            try
            {
                if (!File.Exists($"C:/Users/USER/Desktop/IOEPulchowk/Practice C#/test.txt"))
                {
                    FileStream file = File.Create($"C:/Users/USER/Desktop/IOEPulchowk/Practice C#/test.txt");
                    file.Close();
                }
                using (StreamReader reader = new StreamReader(filePath))
                {
                    using (StreamWriter writer = new StreamWriter($"C:/Users/USER/Desktop/IOEPulchowk/Practice C#/test.txt"))
                    {
                        string? line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            var parts = line.Split('|');
                            writer.Write($"{parts[0]} | ");
                            writer.Write($"{parts[1]} | ");
                            foreach (var part in parts[1])
                            {
                                writer.Write(part);
                                writer.Write(' ');
                            }
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
