using System;
using UnityEngine;
using UnityEditor;

public abstract class Task : MonoBehaviour
{
    public string name;

    public Task() {
        this.name = "Unknown Task";
    }

    public Task(string name)
    {
        this.name = name;
    }

    public abstract void exec(GameObject agent);
}

