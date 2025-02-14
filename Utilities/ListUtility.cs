using System.Collections.Generic;
using UnityEngine;

public static class ListUtility
{
    public static void Shuffle<T>(this List<T> list)
    {
        var array = new T[list.Count];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = list.PopRandomElement();
        }
        list.AddRange(array);
    }

    public static int GetRandomIndex<T>(this List<T> list)
    {
        return Random.Range(0, list.Count);
    }
    
    public static T GetRandomElement<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }

    public static T PopRandomElement<T>(this List<T> list)
    {
        var index = Random.Range(0, list.Count);
        var result = list[index];
        list.RemoveAt(index);
        return result;
    }

    public static int GetRandomIndex<T>(this T[] list)
    {
        return Random.Range(0, list.Length);
    }

    public static T GetRandomElement<T>(this T[] list)
    {
        return list[Random.Range(0, list.Length)];
    }
}