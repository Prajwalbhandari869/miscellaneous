using System.Text.RegularExpressions;

namespace RE_T_TN_Assignment
{
    public class RegularExpression
    {
        public async Task ExtractPhoneNumbersAndEmail(string text, string filePath)
        {
            try
            {
                string mobileNumber = @"\b(\+?977[-\s])?(9[78][012456])[-\s]?\d{3}[-\s]?\d{4}\b";
                string emailPattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";

                Regex mobileRegex = new Regex(mobileNumber);
                Regex emailRegex = new Regex(emailPattern);

                MatchCollection mobileMatches = mobileRegex.Matches(text);
                MatchCollection emailMatches = emailRegex.Matches(text);

                string mobileFile = $"Mobile Numbers.txt";
                if (!File.Exists($"{filePath}{mobileFile}"))
                {
                    FileStream file = File.Create($"{filePath}{mobileFile}");
                    file.Close();
                }
                using (StreamWriter writer = new StreamWriter($"{filePath}{mobileFile}",false))
                {
                    writer.WriteLine("Nepali Mobile Numbers:");
                    foreach (Match match in mobileMatches)
                    {
                        writer.WriteLine(match.Value);
                    }
                }

                string emailFile = $"Email IDs.txt";
                if (!File.Exists($"{filePath}{emailFile}"))
                {
                    FileStream file = File.Create($"{filePath}{emailFile}");
                    file.Close();
                }
                using (StreamWriter writer = new StreamWriter($"{filePath}{emailFile}",false))
                {
                    writer.WriteLine("Email IDs:");
                    foreach (Match match in emailMatches)
                    {
                        writer.WriteLine(match.Value);
                    }
                }
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }                
        }        
    }
}
