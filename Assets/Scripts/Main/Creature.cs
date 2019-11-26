using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class Creature : MonoBehaviour
{
    // Motion speed of the creature
    private float speed;
    public float Speed
    {
        get => speed;
        set => speed = value;
    }

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

    // Radius of vision of the creature
    private float visionRadius;
    public float VisionRadius
    {
        get => visionRadius;
        set => visionRadius = value;
    }

    public Creature() { }

    // Returns the creatures in the field of view of the creature
    public List<GameObject> GetPercepts(GameObject myself, GameObject[] gameObjects)
    {
        List<GameObject> percepts = new List<GameObject>();
        foreach (GameObject go in gameObjects)
        {

            //if distance is short enough for the percept to be seen then add to percepts
            if (Vector3.Distance(myself.gameObject.transform.position, go.transform.position) < Game.visionRadius)
            {
                percepts.Add(go);
            }
;        }
        return percepts;
    }
}