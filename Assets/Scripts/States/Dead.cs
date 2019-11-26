using UnityEngine;
using UnityEditor;

public class Dead : Task
{
    public Dead(string name) : base(name) {
        this.name = "Dead";
    }

    public override void exec(GameObject agent)
    {
        throw new System.NotImplementedException();
    }
}