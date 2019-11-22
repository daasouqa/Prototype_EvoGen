using System;
using UnityEngine;
using UnityEditor;

public abstract class Task
{
    public string name;

    public Task(string name)
    {
        this.name = name;
    }

    public abstract void exec();
}

