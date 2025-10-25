using System;
using System.Collections.Generic;

public class IntHeap<T> where T: IComparable<T>
{

    private List<T> data = new List<T>();
    private bool isMax;


    public IntHeap(bool isMaxHeap = true)
    {
        isMax = isMaxHeap;
    }


    public IntHeap(T[] items, bool isMaxHeap = true)
    {
        isMax = isMaxHeap;
        if (items != null)
            data.AddRange(items);
        else
            Console.WriteLine("Ошибка: передан пустой массив!");
        BuildHeap();
    }

    public int Count => data.Count;


    public T Peek()
    {
        if (data.Count == 0)
        {
            Console.WriteLine("Ошибка: куча пуста!");
            return default(T);
        }
        return data[0];
    }

    public T Pop()
    {
        if (data.Count == 0)
        {
            Console.WriteLine("Ошибка: куча пуста!");
            return default(T);
        }

        T root = data[0];
        T last = data[data.Count - 1];

        data[0] = last;
        data.RemoveAt(data.Count - 1);

        if (data.Count > 0)
            SiftDown(0);

        return root;
    }


    public void Push(T value)
    {
        data.Add(value);
        SiftUp(data.Count - 1);
    }


    public void UpdateKey(int index, T newValue)
    {
        if (index < 0 || index >= data.Count)
        {
            Console.WriteLine("Ошибка: индекс вне диапазона!");
            return;
        }

        T oldValue = data[index];
        data[index] = newValue;

        // Если новое значение "лучше" — поднимаем вверх, иначе опускаем вниз
        if (Compare(newValue, oldValue) > 0)
            SiftUp(index);
        else if (Compare(newValue, oldValue) < 0)
            SiftDown(index);
    }

    // Объединить две кучи (создаётся новая куча)
    public IntHeap<T> Merge(IntHeap<T> other)
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

        var combined = new List<T>(this.data);
        combined.AddRange(other.data);

        return new IntHeap<T>(combined.ToArray(), this.isMax);
    }




    private void BuildHeap()
    {
        for (int i = Parent(data.Count - 1); i >= 0; i--)
            SiftDown(i);
    }


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
    private int Compare(T a, T b)
    {

        return isMax ? a.CompareTo(b) : b.CompareTo(a);
    }

    private static int Parent(int i) => (i - 1) / 2;

    private void Swap(int i, int j)
    {
        T tmp = data[i];
        data[i] = data[j];
        data[j] = tmp;
    }

    public void Print()
    {
        Console.WriteLine(string.Join(", ", data));
    }
}

class Program
{
    static void Main()
    {

        int[] arr = { 5, 3, 17, 10, 84, 19, 6, 22, 9 };
        IntHeap<int> heap = new IntHeap<int>(arr, isMaxHeap: true);

        Console.WriteLine("Корень (максимум): " + heap.Peek());


        Console.WriteLine("Удаляем корень: " + heap.Pop());
        Console.WriteLine("Новый корень: " + heap.Peek());

        heap.UpdateKey(2, 200);
        Console.WriteLine("После UpdateKey(2, 200): " + heap.Peek());

        heap.Print();

        // Слияние куч и проверка ошибки
        IntHeap<int> other = new IntHeap<int>(new int[] { 111, 222, 333 }, isMaxHeap: true);
        IntHeap<int> merged = heap.Merge(other);

        Console.WriteLine("\nСлияние куч:");
        merged.Print();

        Console.WriteLine("\nПопробуем удалить из пустой кучи:");
        var empty = new IntHeap<string>();
        empty.Pop();

        Console.WriteLine("////////////////////////////////////////////////////////////////////");

        string[] arrstr = { ":", "слово", "слово0", "слово1", "слово2", "слово3"};
        IntHeap<string> heap1 = new IntHeap<string>(arrstr, isMaxHeap: true);

        Console.WriteLine("Корень (максимум): " + heap.Peek());

    }
} 