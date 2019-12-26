using UnityEngine;
using UnityEditor;

public class Dead : Task
{
    public Dead(string name) : base(name) {
        this.name = "Dead";
    }

    public int TimeSinceDeath = 0;
    public bool playedAnimation = false;

    public override void exec(GameObject agent)
    {
        if (!playedAnimation)
        {
            agent.GetComponent<Animation>().Play("dead");
            playedAnimation = true;
        }
        

        if (agent.GetComponent<HerbivoreBrain>() != null)
        {
            agent.GetComponent<MeshRenderer>().material = agent.GetComponent<HerbivoreBrain>().deadMaterial;
        } else
        {
            agent.GetComponent<MeshRenderer>().material = agent.GetComponent<CarnivoreBrain>().deadMaterial;
        }

        if (TimeSinceDeath >= Game.RottingTime)
        {
            Destroy(agent);
        } else
        {
            TimeSinceDeath++;
        }
    }
}