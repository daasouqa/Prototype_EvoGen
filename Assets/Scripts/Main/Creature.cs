using System;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class Creature : MonoBehaviour
{
    private int hunger;
    public int Hunger => hunger;

    private int reproductiveNeed;
    public int ReproductiveNeed => reproductiveNeed;



    public List<GameObject> GetPercepts(GameObject[] gameObjects)
    {
        List<GameObject> percepts = new List<GameObject>();
        foreach (GameObject gameObject in gameObjects)
        {
            //if in cone add to percepts
        }
        return percepts;
    }

}