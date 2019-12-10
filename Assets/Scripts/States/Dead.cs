using UnityEngine;
using UnityEditor;

public class Dead : Task
{
    public Dead(string name) : base(name) {
        this.name = "Dead";
    }

    public override void exec(GameObject agent)
    {
        if (agent.GetComponent<HerbivoreBrain>() != null)
        {
            agent.GetComponent<MeshRenderer>().material = agent.GetComponent<HerbivoreBrain>().deadMaterial;
        } else
        {
            agent.GetComponent<MeshRenderer>().material = agent.GetComponent<CarnivoreBrain>().deadMaterial;
        }

        
    }
}