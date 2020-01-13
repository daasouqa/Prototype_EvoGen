using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class Creature : MonoBehaviour
{
    public enum CreatureType
    {
        HERBIVORE,
        CARNIVORE
    }

    private CreatureType creatureType;
    public CreatureType mCreatureType
    {
        get => creatureType;
        set => creatureType = value;
    }

    private GameObject characteristicsCanvas;
    public GameObject CharacteristicsCanvas
    {
        get => characteristicsCanvas;
        set => characteristicsCanvas = value;
    }

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
        this.MaxHealth = 100f;

        // Initializing different parameters of the creature
        this.Hunger = Random.Range(Game.minHunger, 100);
        this.ReproductiveNeed = Random.Range(Game.minReproductionNeed, 100);
        this.Speed = Random.Range(1, 10);
        this.CurrentHealth = Random.Range(MaxHealth / 2, MaxHealth);

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

    public List<GameObject> GetDifferentTypePercepts(GameObject myself, GameObject[] gameObjects)
    {
        
        List<GameObject> percepts = new List<GameObject>();
        foreach (GameObject go in gameObjects)
        {
            
            if (go.GetComponent<CreatureBehaviorScript>() != null)
            {
                if (go.GetComponent<CreatureBehaviorScript>().creature.mCreatureType != myself.GetComponent<Creature>().mCreatureType)
                {
                    if (Vector3.Distance(myself.gameObject.transform.position, go.transform.position) <= Game.visionRadius)
                    {
                        percepts.Add(go);
                    }
                }
            } else
            {
                if (go.GetComponent<Creature>().creatureType != myself.GetComponent<Creature>().mCreatureType)
                {
                    if (Vector3.Distance(myself.gameObject.transform.position, go.transform.position) <= Game.visionRadius)
                    {
                        if (myself != go)
                        {
                            percepts.Add(go);
                        }
                    }
                }
            }
        }

        return percepts;
    }

    public List<GameObject> GetFoodNearby(GameObject myself, GameObject[] gameObjects)
    {
        List<GameObject> foodNearby = new List<GameObject>();
        GameObject[] foodInScene;
        if (myself.GetComponent<CreatureBehaviorScript>().creature.mCreatureType == CreatureType.CARNIVORE)
        {
            foodInScene = GameObject.FindGameObjectsWithTag("creature");
            foreach (GameObject go in foodInScene)
            {
                if (go != myself)
                {
                    if (Vector3.Distance(myself.gameObject.transform.position, go.transform.position) < Game.visionRadius 
                        && go.GetComponent<Creature>().mCreatureType == CreatureType.HERBIVORE)
                    {
                        foodNearby.Add(go);
                    }
                }
            }

            return foodNearby;
        } else
        {
            foodInScene = GameObject.FindGameObjectsWithTag("herbe");
            foreach (GameObject go in foodInScene)
            {
                if (Vector3.Distance(myself.gameObject.transform.position, go.transform.position) < Game.visionRadius)
                {
                    if (myself != go)
                    {
                        foodNearby.Add(go);
                    }
                }
            }
            return foodNearby;
        }
    }

    public List<GameObject> GetSameTypePercepts(GameObject myself, GameObject[] gameObjects)
    {
        List<GameObject> percepts = new List<GameObject>();
        foreach (GameObject go in gameObjects)
        {
            if (go.GetComponent<CreatureBehaviorScript>() != null)
            {
                if (go.GetComponent<CreatureBehaviorScript>().creature.mCreatureType == myself.GetComponent<Creature>().mCreatureType)
                {
                    percepts.Add(go);
                }
            }
            else
            {
                if (go.GetComponent<Creature>().creatureType == myself.GetComponent<Creature>().mCreatureType)
                {
                    if (Vector3.Distance(myself.gameObject.transform.position, go.transform.position) < Game.visionRadius)
                    {
                        if (myself != go)
                        {
                            percepts.Add(go);
                        }
                    }
                }
            }
        }

        return percepts;
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
                if (myself != go)
                {
                    percepts.Add(go);
                }
            }
;        }
        return percepts;
    }

    

    // Returns possible reproduction partners
    public List<GameObject> GetPossiblePartnersInSight(GameObject me)
    {
        List<GameObject> possiblePartners = new List<GameObject>();
        GameObject[] creatures = GameObject.FindGameObjectsWithTag("creature"); 

        foreach (GameObject go in creatures)
        {
            if (go != me)
            {
                if (go.GetComponent<Creature>().mCreatureType == me.GetComponent<CreatureBehaviorScript>().creature.mCreatureType)
                {
                    if (Vector3.Distance(go.transform.position, me.transform.position) <= Game.visionRadius)
                    {
                        possiblePartners.Add(go);
                    }
                }
            }
        }

        return possiblePartners;
    }


    private void OnMouseDown()
    {
        characteristicsCanvas.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "Sex: " + (mSex == Sex.MALE ? "M" : "F");
        characteristicsCanvas.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = "Body type: " + mBody.mBodyType;
        characteristicsCanvas.transform.GetChild(2).GetComponent<TMPro.TextMeshProUGUI>().text = "Head: " + mHead.mActive + " | " + mHead.mPassive;
        characteristicsCanvas.transform.GetChild(3).GetComponent<TMPro.TextMeshProUGUI>().text = "Front limbs: " + FrontLimb.mActive + " | " + FrontLimb.mPassive;
        characteristicsCanvas.transform.GetChild(4).GetComponent<TMPro.TextMeshProUGUI>().text = "Back limbs: " + BackLimb.mActive + " | " + BackLimb.mPassive;
        characteristicsCanvas.SetActive(!characteristicsCanvas.activeSelf);
    }

}