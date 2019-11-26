using UnityEngine;
using UnityEditor;

public class SeReproduire : Task
{
    public SeReproduire(string name) : base(name) {
        this.name = "Se Reproduire";
    }

    override public void exec(GameObject agent)
    {
        // Se reproduire
    }
}