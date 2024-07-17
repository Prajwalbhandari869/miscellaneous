using System.Text.RegularExpressions;

namespace RE_T_TN_Assignment
{
    public class Tokenizer
    {
        private static string mappedFile = $"Mapped.txt";
        private static string reducedFile = $"Reduced.txt";
        public async Task Mapper(string fileContent, string filePath)
        {
            try
            {
                char[] needToReplaceChars = ['\n', '.', ',', '\'', '"', ':', ';', '`', '[', ']', '(', ')', '-', '’', '“', '”', ' '];
                foreach (char replaceChar in needToReplaceChars)
                {
                    fileContent = fileContent.Replace(replaceChar, ' ');
                }
                fileContent = Regex.Replace(fileContent, @"\s+", " ").Trim();
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
                using (StreamWriter writer = new StreamWriter($"{filePath}{reducedFile}",false))
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
    }
}
