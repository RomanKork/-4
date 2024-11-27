using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба_4
{
    public class TaskSolver
    {
        // Задание 1
        public static List<int> GetUniqueElements(List<int> L1, List<int> L2)
        {
            var result = new List<int>();
            foreach (var item in L1) 
            {
                if (!L2.Contains(item) && !result.Contains(item)) 
                {
                    result.Add(item); 
                }
            }
            return result; 
        }

        // Задание 2
        public static bool IsSymmetricSection(LinkedList<int> list, int i, int j)
        {
            var tempList = list.Skip(i).Take(j - i + 1).ToList(); 
            int count = tempList.Count;
            for (int k = 0; k < count / 2; k++) 
            {
                if (tempList[k] != tempList[count - k - 1]) 
                    return false;
            }
            return true;
        }

        // Задание 3
        public static (HashSet<string> allLike, HashSet<string> someLike, HashSet<string> noneLike) AnalyzeChocolates(
    HashSet<string> chocolateNames, List<HashSet<string>> sweetToothPreferences)
        {
            var allLike = new HashSet<string>(chocolateNames);

            var someLike = new HashSet<string>();

            var noneLike = new HashSet<string>(chocolateNames);

            foreach (var preferences in sweetToothPreferences)
            {
                var validPreferences = new HashSet<string>(preferences.Where(chocolateNames.Contains));

                allLike.IntersectWith(validPreferences);
                someLike.UnionWith(validPreferences);
            }

            someLike.ExceptWith(allLike);
            noneLike.ExceptWith(someLike);
            noneLike.ExceptWith(allLike);

            return (allLike, someLike, noneLike);
        }



        // Задание 4
        public static HashSet<char> GetMissingLettersFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Файл не найден: {filePath}");
            }

            string text = File.ReadAllText(filePath);

            string russianAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            var alphabetSet = new HashSet<char>(russianAlphabet);

            var textSet = new HashSet<char>(text.ToLower().Where(char.IsLetter));

            alphabetSet.ExceptWith(textSet);

            return alphabetSet;
        }
    }
}
