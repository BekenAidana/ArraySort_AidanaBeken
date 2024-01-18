using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Algorithms
{
    // Метод сортировки пузырьком
    public void BubbleSort(List<ObjData> objects)
    {
        int n = objects.Count;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (objects[j].Value > objects[j + 1].Value ||
                    (objects[j].Value == objects[j + 1].Value && string.Compare(objects[j].Name, objects[j + 1].Name) > 0))
                {
                    var temp = objects[j];
                    objects[j] = objects[j + 1];
                    objects[j + 1] = temp;
                }
            }
        }
    }

    // Метод сортировки вставками
    public void InsertionSort(List<ObjData> objects)
    {
        for (int i = 1; i < objects.Count; i++)
        {
            var key = objects[i];
            int j = i - 1;

            while (j >= 0 && (objects[j].Value > key.Value ||
                   (objects[j].Value == key.Value && string.Compare(objects[j].Name, key.Name) > 0)))
            {
                objects[j + 1] = objects[j];
                j = j - 1;
            }
            objects[j + 1] = key;
        }
    }

    // Метод сортировки выбором
    public void SelectionSort(List<ObjData> objects)
    {
        for (int i = 0; i < objects.Count - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < objects.Count; j++)
            {
                if (objects[j].Value < objects[minIndex].Value ||
                    (objects[j].Value == objects[minIndex].Value && string.Compare(objects[j].Name, objects[minIndex].Name) < 0))
                {
                    minIndex = j;
                }
            }

            var temp = objects[minIndex];
            objects[minIndex] = objects[i];
            objects[i] = temp;
        }
    }

    // Метод быстрой сортировки
    public void QuickSort(List<ObjData> objects)
    {
        QuickSortInternal(objects, 0, objects.Count - 1);
    }

    private void QuickSortInternal(List<ObjData> objects, int start, int end)
    {
        if (start < end)
        {
            int pivotIndex = Partition(objects, start, end);
            QuickSortInternal(objects, start, pivotIndex - 1);
            QuickSortInternal(objects, pivotIndex + 1, end);
        }
    }

    private int Partition(List<ObjData> objects, int start, int end)
    {
        var pivot = objects[end];
        int i = start - 1;

        for (int j = start; j < end; j++)
        {
            if (objects[j].Value < pivot.Value ||
                (objects[j].Value == pivot.Value && string.Compare(objects[j].Name, pivot.Name) < 0))
            {
                i++;
                var temp = objects[i];
                objects[i] = objects[j];
                objects[j] = temp;
            }
        }

        var temp1 = objects[i + 1];
        objects[i + 1] = objects[end];
        objects[end] = temp1;

        return i + 1;
    }
}