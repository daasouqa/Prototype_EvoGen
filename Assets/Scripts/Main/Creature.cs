using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class Creature : MonoBehaviour
{

    private float maxHealth;
    public float MaxHealth
    {
        get => maxHealth;
        set => maxHealth = value;
    }

    private float currentHealth;
    public float CurrentHealth
    {
        get => currentHealth;
        set => currentHealth = value;
    }

    // Characteristics
    public enum Sex
    {
        MALE,
        FEMALE
    }

    private Sex sex;
    public Sex mSex
    {
        get => sex;
        set => sex = value;
    }

    private Body body;
    public Body mBody
    {
        get => body;
        set => body = value;
    }

    private Head head;
    public Head mHead
    {
        get => head;
        set => head = value;
    }

    private Limb frontLimb, backLimb;
    public Limb FrontLimb
    {
        get => frontLimb;
        set => frontLimb = value;
    }

    public Limb BackLimb
    {
        get => backLimb;
        set => backLimb = value;
    }

    // Motion speed of the creature
    private float speed;
    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    // Hunger level of a creature
    private float hunger;
    public float Hunger
    {
        get => hunger;
        set => hunger = value;
    }

    // Reproductive need level of a creature
    private float reproductiveNeed;
    public float ReproductiveNeed
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

    private void Start()
    {
        this.body = new Body();
        this.head = new Head();
        this.frontLimb = new Limb();
        this.backLimb = new Limb();
        this.mSex = Random.Range(1, 2) == 1 ? Sex.FEMALE : Sex.MALE;

        
    }

    public Creature() {
        this.body = new Body();
        this.head = new Head();
        this.frontLimb = new Limb();
        this.backLimb = new Limb();
        this.mSex = new Sex();
    }

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

    // Returns possible reproduction partners
    public List<GameObject> GetPossiblePartners(GameObject me)
    {
        List<GameObject> possiblePartners = new List<GameObject>();
        List<GameObject> percepts = GetPercepts(me, GameObject.FindGameObjectsWithTag(me.tag));
        foreach (GameObject percept in percepts)
        {
            if (percept == this)
            {
                percepts.Remove(percept);
            }
        }


        return possiblePartners;
    }

}