using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RE_T_TN_Assignment.NLPAssignmentTwo
{
    public class EditDistance
    {
        public int[,] CalculateEditDistance(string word1, string word2)
        {
            try
            {
                int word1Length = word1.Length;
                int word2Length = word2.Length;
                int[,] EditDistanceTable = InitializeEditDistanceTable(word1Length, word2Length);
                for (int i = 1; i <= word1Length; i++)
                {
                    for (int j = 1; j <= word2Length; j++)
                    {
                        List<int> distance = new List<int>();
                        distance.Add(EditDistanceTable[i - 1, j] + 1);
                        distance.Add(EditDistanceTable[i, j - 1] + 1);
                        distance.Add(EditDistanceTable[i - 1, j - 1] + (word1[i-1] != word2[j-1] ? 2 : 0));
                        EditDistanceTable[i, j] = distance.Min();
                    }
                }
                return EditDistanceTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private static int[,] InitializeEditDistanceTable(int word1Length, int word2Length)
        {
            int[,] EditDistanceTable = new int[word1Length + 1, word2Length + 1];
            for (int i = 0; i <= word1Length; i++)
            {
                EditDistanceTable[i, 0] = i;
            }
            for (int j = 0; j <= word2Length; j++)
            {
                EditDistanceTable[0, j] = j;
            }
            return EditDistanceTable;
        }
    }
}
