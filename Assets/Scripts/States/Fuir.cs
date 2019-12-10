﻿using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class Fuir : Task
{
    public Fuir(string name) : base(name) {
        this.name = "Fuir";
    }

    public override void exec(GameObject agent)
    {
        List<GameObject> enemiesNearby = new Creature().GetPercepts(agent ,GameObject.FindGameObjectsWithTag("carnivore"));
        if (enemiesNearby.Count != 0)
        {
            float minDistance = Vector3.Distance(agent.transform.position, enemiesNearby[0].transform.position);
            GameObject closestEnemy = enemiesNearby[0];

            // Find closest predator

            for (int i = 1; i < enemiesNearby.Count; i++)
            {
                if (Vector3.Distance(agent.transform.position, enemiesNearby[i].transform.position) < minDistance)
                {
                    minDistance = Vector3.Distance(agent.transform.position, enemiesNearby[i].transform.position);
                    closestEnemy = enemiesNearby[i];
                }
            }

            // Run in the opposite direction of the closest predator

            agent.transform.position = Vector3.MoveTowards(agent.transform.position, closestEnemy.transform.position, -1 *
                agent.GetComponent<HerbivoreBrain>().Speed * Time.deltaTime);
        }
    }
}