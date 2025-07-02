using System.Text.RegularExpressions;

namespace Utilities
{
    public class Renamer
    {
        private string FilePath = $"";
        public Renamer(string filePath)
        {
            FilePath = filePath;
        }
        /// <summary>
        /// Renames file name based on params provided.
        /// </summary>
        /// <param name="oldName">Can be whole file name or substring of filename that you want to replace.</param>
        /// <param name="newName">File name or substring you want to replace with.</param>
        public void Rename(string oldName, string newName)
        {
            int count = 0;
            string[] files = Directory.GetFiles(FilePath);
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                if (fileName.Contains(oldName))
                {
                    string newFileName = Path.Combine(FilePath, fileName.Replace(oldName, newName));
                    File.Move(file, newFileName);
                    count++;
                }
            }
            Console.WriteLine($"{count} Files renamed successfully!");

        }
        public void Rename()
        {
            string[] files = Directory.GetFiles(FilePath);
            Regex regex = new Regex(@"clean_date_categories(\d+)");
            foreach (string filePath in files)
            {
                string fileName = Path.GetFileName(filePath);
                string extension = Path.GetExtension(filePath);
                Match match = regex.Match(fileName);
                if (match.Success)
                {
                    string numericPart = match.Groups[1].Value;
                    string newFileName = $"arctic_12{numericPart}{extension}";
                    string newFilePath = Path.Combine(FilePath, newFileName);
                    try
                    {
                        File.Move(filePath, newFilePath);
                        Console.WriteLine($"Renamed: {fileName} to {newFileName}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error renaming {fileName}: {ex.Message}");
                    }
                }
            }
        }

    }
}
