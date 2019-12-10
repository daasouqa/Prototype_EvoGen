using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characteristic
{
    int level;

    public Characteristic()
    {
        level = 0;
    }

    public Characteristic(int level)
    {
        level = this.level;
    }

    protected T GetRandomCharacteristic<T>()
    {
        System.Array A = System.Enum.GetValues(typeof(T));
        T V = (T)A.GetValue(Random.Range(0, A.Length));
        return V;
    }
}
