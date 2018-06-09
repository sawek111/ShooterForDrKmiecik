using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{

    [Range(0, 100)] private static int _idTreeCounter = 0;
    private static int _idNodeCounter = 100;

    public static int GetTreeId()
    {
        if(_idTreeCounter >= 99)
        {
            _idTreeCounter = 0;
        }
        _idTreeCounter++;

        return _idTreeCounter;
    }

    public static int GetNodeId()
    {
        _idNodeCounter++;
        return _idNodeCounter;
    }

    public static void CreateArrayCopy<T>(T[] existingArray, out T[] arrayCopy)
    {
        arrayCopy = new T[existingArray.Length];
        for (int i = 0; i < arrayCopy.Length; i++)
        {
            arrayCopy[i] = existingArray[i];
        }

        return;
    }
}
