using System;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class Creature : MonoBehaviour
{
    // Hunger level of a creature
    private int hunger;
    public int Hunger
    {
        get => hunger;
        set => hunger = value;
    }

    // Reproductive need level of a creature
    private int reproductiveNeed;
    public int ReproductiveNeed
    {
        get => reproductiveNeed;
        set => reproductiveNeed = value;
    }

    // Current state of the creature
    private Task currentState;
    public Task CurrentState
    {
        get => currentState;
        set => currentState = value;
    }

    // Returns the creatures in the field of view of the creature
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