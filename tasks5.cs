using System;
using System.Collections.Generic;

public class IntHeap
{
    private List<int> data = new List<int>(); // хранение элементов
    private bool isMax; // true — max-куча, false — min-куча

    // Конструктор пустой кучи
    public IntHeap(bool isMaxHeap = true)
    {
        isMax = isMaxHeap;
    }

    // Конструктор из массива
    public IntHeap(int[] items, bool isMaxHeap = true)
    {
        isMax = isMaxHeap;
        if (items != null)
            data.AddRange(items);
        else
            Console.WriteLine("Ошибка: передан пустой массив!");
        BuildHeap();
    }

    // Количество элементов
    public int Count => data.Count;

    // Просмотреть корень (максимум или минимум)
    public int Peek()
    {
        if (data.Count == 0)
        {
            Console.WriteLine("Ошибка: куча пуста!");
            return 0;
        }
        return data[0];
    }

    // Удалить и вернуть максимум (или минимум)
    public int Pop()
    {
        if (data.Count == 0)
        {
            Console.WriteLine("Ошибка: куча пуста!");
            return 0;
        }

        int root = data[0];
        int last = data[data.Count - 1];

        data[0] = last;
        data.RemoveAt(data.Count - 1);

        if (data.Count > 0)
            SiftDown(0);

        return root;
    }

    // Добавить новый элемент
    public void Push(int value)
    {
        data.Add(value);
        SiftUp(data.Count - 1);
    }

    // Изменить элемент по индексу
    public void UpdateKey(int index, int newValue)
    {
        if (index < 0 || index >= data.Count)
        {
            Console.WriteLine("Ошибка: индекс вне диапазона!");
            return;
        }

        int oldValue = data[index];
        data[index] = newValue;

        // Если новое значение "лучше" — поднимаем вверх, иначе опускаем вниз
        if (Compare(newValue, oldValue) > 0)
            SiftUp(index);
        else if (Compare(newValue, oldValue) < 0)
            SiftDown(index);
    }

    // Объединить две кучи (создаётся новая куча)
    public IntHeap Merge(IntHeap other)
    {
        if (other == null)
        {
            Console.WriteLine("Ошибка: вторая куча не существует!");
            return this;
        }

        if (this.isMax != other.isMax)
        {
            Console.WriteLine("Ошибка: нельзя объединять max- и min-кучи!");
            return this;
        }

        var combined = new List<int>(this.data);
        combined.AddRange(other.data);

        return new IntHeap(combined.ToArray(), this.isMax);
    }

    // ===================================================
    // Вспомогательные методы
    // ===================================================

    // Построить кучу (heapify)
    private void BuildHeap()
    {
        for (int i = Parent(data.Count - 1); i >= 0; i--)
            SiftDown(i);
    }

    // Поднятие элемента вверх
    private void SiftUp(int i)
    {
        while (i > 0)
        {
            int parent = Parent(i);
            if (Compare(data[i], data[parent]) > 0)
            {
                Swap(i, parent);
                i = parent;
            }
            else break;
        }
    }

    // Опускание элемента вниз
    private void SiftDown(int i)
    {
        int n = data.Count;
        while (true)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int best = i;

            if (left < n && Compare(data[left], data[best]) > 0)
                best = left;
            if (right < n && Compare(data[right], data[best]) > 0)
                best = right;

            if (best == i) break;
            Swap(i, best);
            i = best;
        }
    }

    // Сравнение с учётом типа кучи
    private int Compare(int a, int b)
    {
        // Для max-кучи: больше — выше
        // Для min-кучи: меньше — выше (инвертируем)
        return isMax ? a.CompareTo(b) : b.CompareTo(a);
    }

    private static int Parent(int i) => (i - 1) / 2;

    private void Swap(int i, int j)
    {
        int tmp = data[i];
        data[i] = data[j];
        data[j] = tmp;
    }

    // Вывод содержимого кучи
    public void Print()
    {
        Console.WriteLine(string.Join(", ", data));
    }
}

// ======================
// Пример использования
// ======================
class Program
{
    static void Main()
    {
        // Создание max-кучи из массива
        int[] arr = { 5, 3, 17, 10, 84, 19, 6, 22, 9 };
        IntHeap heap = new IntHeap(arr, isMaxHeap: true);

        Console.WriteLine("Корень (максимум): " + heap.Peek());

        heap.Push(100);
        Console.WriteLine("После добавления 100: " + heap.Peek());

        Console.WriteLine("Удаляем корень: " + heap.Pop());
        Console.WriteLine("Новый корень: " + heap.Peek());

        heap.UpdateKey(2, 200);
        Console.WriteLine("После UpdateKey(2, 200): " + heap.Peek());

        heap.Print();

        // Слияние куч
        IntHeap other = new IntHeap(new int[] { 1, 2, 3 }, isMaxHeap: true);
        IntHeap merged = heap.Merge(other);

        Console.WriteLine("\nСлияние куч:");
        merged.Print();

        // Проверка ошибок
        Console.WriteLine("\nПопробуем удалить из пустой кучи:");
        var empty = new IntHeap();
        empty.Pop();  // просто выведет сообщение, не упадёт
    }
}
