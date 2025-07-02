using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace RE_T_TN_Assignment
{
    public class Tokenizer
    {
        private static string mappedFile = $"Mapped.txt";
        private static string reducedFile = $"Reduced.txt";
        private static string tokenizedFile = $"tokens.txt";

        public async Task Mapper(string filePath)
        {
            try
            {
                List<string> tokens = new List<string>();
                char[] separator = { ' ', ',' };
                char[] needToReplaceChars = [/*'\n',*/ '.', ',', '\'', '"', '/', ':', ';', '`', '[', ']', '(', ')', '-', '–', '’', '“', '”', ' ', '|', '।'];
                using (StreamReader reader = new StreamReader(filePath))
                {
                    int fileNumber = 1;
                    string? line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        var words = line.Split(needToReplaceChars);
                        foreach (var word in words)
                        {
                            if (!tokens.Contains(word) && !Regex.IsMatch(word, @"^[a-zA-Z0-9'\-\:_]+$"))
                            {
                                tokens.Add(word);
                            }
                        }
                        if (tokens.Count > 200000)
                        {
                            if (!File.Exists($"{filePath}{fileNumber}"))
                            {
                                FileStream file = File.Create($"{filePath}{fileNumber}.txt");
                                file.Close();
                            }
                            using (StreamWriter writer = new StreamWriter($"{filePath}{fileNumber}"))
                            {
                                foreach (var token in tokens)
                                {
                                    writer.Write(token);
                                    writer.WriteLine();
                                }

                            }
                            fileNumber += 1;
                            tokens.Clear();
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task Mapper(string fileContent, string filePath)
        {
            try
            {
                char[] needToReplaceChars = ['\n', '.', ',', '\'', '"', ':', ';', '`', '[', ']', '(', ')', '-', '–', '’', '“', '”', ' ', '|', '।'];
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
                        //foreach (var letter in token)
                        //{
                        //    writer.Write(letter);
                        //    writer.Write(' ');
                        //}
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
                            //var parts = line.Split('|');
                            var parts = line.Split(' ');
                            //writer.Write($"{parts[0]} | ");
                            //writer.Write($"{parts[1]} | ");
                            //foreach (var part in parts[1])
                            foreach (var part in parts)
                            {
                                writer.Write(part);
                                //writer.Write(' ');
                                writer.WriteLine();
                            }
                            //writer.WriteLine();
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
        public void TokenizeEachWordWithWindow(string filePath, int Size)
        {
            try
            {
                int windowSize = Size;
                List<string> tokens = new List<string>();
                if (!File.Exists($"C:/Users/USER/Desktop/IOEPulchowk/Practice C#/NepaliTokens.txt"))
                {
                    FileStream file = File.Create($"C:/Users/USER/Desktop/IOEPulchowk/Practice C#/NepaliTokens.txt");
                    file.Close();
                }
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        int current_win_pos = 0;
                        line = line.Replace('\t', ' ').Trim();
                        char[] chars = line.ToCharArray();
                        while (current_win_pos < line.Length)
                        {
                            char[] current_char_window = new char[windowSize];
                            current_char_window = chars[current_win_pos..((current_win_pos + windowSize) < line.Length ? current_win_pos + windowSize : line.Length)];
                            for (int i = current_char_window.Length; i > 0; i--)
                            {
                                string? potential_syllable = string.Join("", current_char_window[0..i]);
                                if ((potential_syllable != null) && (!tokens.Contains(potential_syllable)))
                                {
                                    tokens.Add(potential_syllable);
                                }
                            }
                            current_win_pos += 1;
                        }
                        if (tokens.Count > 200000)
                        {
                            break;
                        }
                    }
                }
                tokens.Sort();
                using (StreamWriter writer = new StreamWriter($"C:/Users/USER/Desktop/IOEPulchowk/Practice C#/NepaliTokens.txt"))
                {
                    foreach (var token in tokens)
                    {
                        writer.Write(token);
                        writer.WriteLine();
                    }
                }
                if (!File.Exists($"C:/Users/USER/Desktop/IOEPulchowk/Practice C#/NepaliTokensPerLength.txt"))
                {
                    FileStream file = File.Create($"C:/Users/USER/Desktop/IOEPulchowk/Practice C#/NepaliTokensPerLength.txt");
                    file.Close();
                }
                List<string> sortedByLength = tokens.OrderBy(str => str.Length).ToList();
                using (StreamWriter writer = new StreamWriter($"C:/Users/USER/Desktop/IOEPulchowk/Practice C#/NepaliTokensPerLength.txt"))
                {
                    foreach (var token in sortedByLength)
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
    }
}
