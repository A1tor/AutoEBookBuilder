using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoEBookBuilder
{
    internal static class Sorter
    {
        public static List<string> BubbleSort(List<string> list)
        {
            List<string> sortedList = new List<string>(list);
            int n = sortedList.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (string.Compare(sortedList[j], sortedList[j + 1]) > 0)
                    {
                        string temp = sortedList[j];
                        sortedList[j] = sortedList[j + 1];
                        sortedList[j + 1] = temp;
                    }
                }
            }
            return sortedList;
        }

        public static List<string> InsertionSort(List<string> list)
        {
            List<string> sortedList = new List<string>(list);
            int n = sortedList.Count;
            for (int i = 1; i < n; i++)
            {
                string key = sortedList[i];
                int j = i - 1;
                while (j >= 0 && string.Compare(sortedList[j], key) > 0)
                {
                    sortedList[j + 1] = sortedList[j];
                    j--;
                }
                sortedList[j + 1] = key;
            }
            return sortedList;
        }

        public static List<string> QuickSort(List<string> list)
        {
            List<string> sortedList = new List<string>(list); // Создаем копию списка
            QuickSortRecursive(sortedList, 0, sortedList.Count - 1);
            return sortedList;
        }

        private static void QuickSortRecursive(List<string> list, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(list, low, high);
                QuickSortRecursive(list, low, pivotIndex - 1);
                QuickSortRecursive(list, pivotIndex + 1, high);
            }
        }

        private static int Partition(List<string> list, int low, int high)
        {
            string pivot = list[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (string.Compare(list[j], pivot) <= 0)
                {
                    i++;
                    string temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                }
            }
            string temp1 = list[i + 1];
            list[i + 1] = list[high];
            list[high] = temp1;

            return i + 1;
        }
    }
}
