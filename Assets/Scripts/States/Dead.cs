using UnityEngine;
using UnityEditor;

public class Dead : Task
{
    public Dead(string name) : base(name) {
        this.name = "Dead";
    }

    private void Start()
    {
        this.name = "Dead";
    }

    public float TimeSinceDeath = 0;
    public bool playedAnimation = false;

    public override void exec(GameObject agent)
    {
        if (!playedAnimation)
        {
            agent.GetComponent<Animation>().Play("dead");
            playedAnimation = true;
            if (agent.GetComponent<Creature>().mCreatureType == Creature.CreatureType.CARNIVORE)
            {
                agent.GetComponent<CarnivoreBrain>().dustEffects.SetActive(false);
            } else
            {
                agent.GetComponent<HerbivoreBrain>().dustEffects.SetActive(false);
            }
        }
        

        //if (agent.GetComponent<HerbivoreBrain>() != null)
        //{
        //    agent.GetComponent<MeshRenderer>().material = agent.GetComponent<HerbivoreBrain>().deadMaterial;
        //} else
        //{
        //    agent.GetComponent<MeshRenderer>().material = agent.GetComponent<CarnivoreBrain>().deadMaterial;
        //}

        if (TimeSinceDeath >= Game.RottingTime)
        {
            Destroy(agent);
        } else
        {
            TimeSinceDeath+=0.1f;
        }
    }
}