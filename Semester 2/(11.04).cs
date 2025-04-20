/* Необходимо реализовать обобщенный класс, который позволяет хранить в массиве объекты любого типа
в классе определить для добавления данных в массив, удаления из массива по индексу и 
получения из массива по индексу */
using System;
class Array<T>
{
    private T[] array = new T[0];
    public void Add(T element)
    {
        T[] new_array = new T[array.Length + 1];
        for (int i = 0; i < array.Length; i++)
        {
            new_array[i] = array[i];
        }
        new_array[array.Length] = element;
        array = new_array;
    }
    public void Delete(int index)
    {
        T[] new_array = new T[array.Length - 1];
        int j = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (i != index)
            {
                new_array[j++] = array[i];
            }
        }
        array = new_array;
    }
    public T Get(int index)
    {
        return array[index];
    }
}
class Program
{
    static void Main()
    {
        var array = new Array<int>();
        array.Add(1);
        array.Add(2);
        Console.WriteLine(array.Get(0));
        array.Delete(1);
        Console.WriteLine(array.Get(0));
    }
}
