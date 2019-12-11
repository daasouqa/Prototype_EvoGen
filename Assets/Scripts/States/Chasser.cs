using System;
using UnityEngine;
using UnityEditor;

public class Chasser : Task
{
    public Chasser(string name) : base(name) {}

    override public void exec(GameObject agent)
    {
        GameObject[] food = GameObject.FindGameObjectsWithTag("herbivore");

        if (food.Length != 0)
        {
            float minDist = Vector3.Distance(agent.transform.position, food[0].transform.position);
            GameObject closestFood = food[0];

            for (int i = 1; i < food.Length; i++)
            {
                if (Vector3.Distance(agent.transform.position, food[i].transform.position) < minDist)
                {
                    minDist = Vector3.Distance(agent.transform.position, food[i].transform.position);
                    closestFood = food[i];
                }
            }

            if (minDist <= 1.0f)
            {
                agent.GetComponent<CarnivoreBrain>().Hunger += 1.0f;

                if (closestFood.GetComponent<HerbivoreBrain>().CurrentState != closestFood.GetComponent<HerbivoreBrain>().dead)
                {
                    closestFood.GetComponent<HerbivoreBrain>().CurrentState = closestFood.GetComponent<HerbivoreBrain>().dead;
                }
            }
            else
            {
                agent.transform.position = Vector3.MoveTowards(agent.transform.position, closestFood.transform.position,
                    agent.GetComponent<CarnivoreBrain>().Speed * Time.deltaTime);
            }
        } else
        {

        }
    }
}