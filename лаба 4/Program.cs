using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace лаба_4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Задание 1
            Console.WriteLine("Введите размер первого списка:");
            int size1 = GetPositiveInt(); 
            Console.WriteLine("Введите элементы первого списка:");
            var L1 = GetIntList(size1);

            Console.WriteLine("Введите размер второго списка:");
            int size2 = GetPositiveInt();
            Console.WriteLine("Введите элементы второго списка:");
            var L2 = GetIntList(size2);

            var result1 = TaskSolver.GetUniqueElements(L1, L2);
            Console.WriteLine("Задание 1: Уникальные элементы: " + string.Join(", ", result1));

            // Задание 2
            Console.WriteLine("Введите размер связного списка:");
            int linkedListSize = GetPositiveInt();
            Console.WriteLine("Введите элементы связного списка:");
            var linkedList = new LinkedList<int>(GetIntList(linkedListSize));

            Console.WriteLine("Введите начальный индекс i:");
            int i = NotNegativeInt();
            Console.WriteLine("Введите конечный индекс j:");
            int j = NotNegativeInt();

            if (i >= 0 && j >= i && j < linkedListSize)
            {
                bool result2 = TaskSolver.IsSymmetricSection(linkedList, i, j);
                Console.WriteLine("Задание 2: " + (result2 ? "Симметрично" : "Не симметрично"));
            }
            else
            {
                Console.WriteLine("Некорректные индексы!");
            }

            // Задание 3
            Console.WriteLine("Введите количество названий шоколада:");
            int chocolateCount = GetPositiveInt();
            var chocolates = new HashSet<string>();

            Console.WriteLine("Введите названия шоколада:");
            for (int k = 0; k < chocolateCount; k++)
            {
                string chocolate = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(chocolate))
                    chocolates.Add(chocolate);
                else
                    k--;
            }

            Console.WriteLine("Введите количество сладкоежек:");
            int sweetToothCount = GetPositiveInt();
            var preferences = new List<HashSet<string>>();

            for (int k = 0; k < sweetToothCount; k++) 
            {
                Console.WriteLine($"Введите предпочтения сладкоежки {k + 1} через запятую:");
                var input = Console.ReadLine();
                var sweetPreferences = input.Split(',').Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x));
                preferences.Add(new HashSet<string>(sweetPreferences));
            }

            var (allLike, someLike, noneLike) = TaskSolver.AnalyzeChocolates(chocolates, preferences);
            Console.WriteLine("Задание 3: Всем нравятся - " + string.Join(", ", allLike));
            Console.WriteLine("Задание 3: Некоторым нравятся - " + string.Join(", ", someLike));
            Console.WriteLine("Задание 3: Никому не нравятся - " + string.Join(", ", noneLike));

            // Задание 4
            var missingLetters = TaskSolver.GetMissingLettersFromFile("C:\\Users\\User\\Desktop\\textfile.txt");
            try
            {
                string fileContent = File.ReadAllText("C:\\Users\\User\\Desktop\\textfile.txt");
                Console.WriteLine("Текст из файла:");
                Console.WriteLine(fileContent);
            }
            catch {
                Console.WriteLine("Файл не получилось открыть.");
            }

            Console.WriteLine("Отсутствующие буквы:");
            Console.WriteLine(string.Join(", ", missingLetters));
        }

        public static int NotNegativeInt()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int result) && result >= 0)
                    return result;
                Console.WriteLine("Некорректный ввод. Введите неотрицательное число.");
            }
        }
        public static int GetPositiveInt()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int result) && result > 0)
                    return result;
                Console.WriteLine("Некорректный ввод. Введите положительное число.");
            }
        }

        public static List<int> GetIntList(int size)
        {
            var list = new List<int>();
            while (list.Count < size)
            {
                var input = Console.ReadLine();
                if (int.TryParse(input, out int number))
                    list.Add(number);
                else
                    Console.WriteLine("Некорректный ввод. Введите целое число.");
            }
            return list;
        }
    }
}