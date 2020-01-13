using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
    public static int minHunger = 20;
    public static int minReproductionNeed = 20;
    public static float visionRadius = 30.0f;
    public static float HungerDecrementationPerUpdate = 0.01f;
    public static float ReproductiveNeedDecrementationPerUpdate = 0.01f;
    public static int RottingTime = 100;
    public static float proximityDistance = 5.0f;

    public static int initialHerbivores = 10;
    public static int initialCarnivores = 10;

    public GameObject Wall1;
    public GameObject Wall2;
    public GameObject Wall3;
    public GameObject Wall4;


    public static GameObject Wall1Static;
    public static GameObject Wall2Static;
    public static GameObject Wall3Static;
    public static GameObject Wall4Static;

    public GameObject HerbivorePrefabPublic;
    public GameObject CarnivorePrefabPublic;

    public static GameObject HerbivorePrefab;
    public static GameObject CarnivorePrefab;

    public static GameObject Me;

    public static Creature.CreatureType playerType;
    public static Creature.Sex playerSex;

    public static bool isPaused;
    

    private void Start()
    {
        Wall1Static = Wall1;
        Wall2Static = Wall2;
        Wall3Static = Wall3;
        Wall4Static = Wall4; 

        CarnivorePrefab = CarnivorePrefabPublic;
        HerbivorePrefab = HerbivorePrefabPublic;
        Me = this.gameObject;


        //GenerateCreatures();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        GameObject[] creatures = GameObject.FindGameObjectsWithTag("creature");
        foreach (GameObject go in creatures)
        {
            if (go.transform.position.y < 75)
            {
                go.transform.position = new Vector3(transform.position.x, 85, transform.position.z);
            }
        }
    }

    public void GenerateCreatures()
    {
        float x;
        float z;

        for (int i = 0; i < initialHerbivores; i++)
        {
            GameObject newHerbivore = HerbivorePrefab;

            // Sex
            int rand = Random.Range(1, 2);
            Debug.Log("sex = " + rand);
            newHerbivore.GetComponent<HerbivoreBrain>().mSex = rand == 1 ? Creature.Sex.FEMALE : Creature.Sex.MALE;

            // Body type

            rand = Random.Range(1, System.Enum.GetNames(typeof(Body.BodyType)).Length);
            Debug.Log("body type = " + rand);
            newHerbivore.GetComponent<HerbivoreBrain>().mBody.mBodyType = (Body.BodyType)rand;

            // Head active
            rand = Random.Range(1, System.Enum.GetNames(typeof(Head.Active)).Length);
            Debug.Log("head active = " + rand);
            newHerbivore.GetComponent<HerbivoreBrain>().mHead.mActive = (Head.Active)rand;

            // Head passive
            rand = Random.Range(1, System.Enum.GetNames(typeof(Head.Passive)).Length);
            Debug.Log("head passive = " + rand);
            newHerbivore.GetComponent<HerbivoreBrain>().mHead.mPassive = (Head.Passive)rand;

            // Front limb active
            rand = Random.Range(1, System.Enum.GetNames(typeof(Limb.Active)).Length);
            newHerbivore.GetComponent<HerbivoreBrain>().FrontLimb.mActive = (Limb.Active)rand;

            // Front limb passive
            rand = Random.Range(1, System.Enum.GetNames(typeof(Limb.Passive)).Length);
            newHerbivore.GetComponent<HerbivoreBrain>().FrontLimb.mPassive= (Limb.Passive)rand;

            // Back limb active
            rand = Random.Range(1, System.Enum.GetNames(typeof(Limb.Active)).Length);
            newHerbivore.GetComponent<HerbivoreBrain>().BackLimb.mActive = (Limb.Active)rand;

            // Back limb passive
            rand = Random.Range(1, System.Enum.GetNames(typeof(Limb.Passive)).Length);
            newHerbivore.GetComponent<HerbivoreBrain>().BackLimb.mPassive = (Limb.Passive)rand;

            Random.seed = System.DateTime.Now.Millisecond;
            x = Random.Range(Wall4.transform.position.x, Wall2.transform.position.x);
            Random.seed = System.DateTime.Now.Millisecond;
            z = Random.Range(Wall1.transform.position.z, Wall3.transform.position.z);

            newHerbivore.transform.position = new Vector3(x, 2, z);
            Vector3 pos = new Vector3(x,2,z);
            Debug.Log("prefab position = " + newHerbivore.transform.position + "\t pos = " + pos);
            
            Instantiate(newHerbivore, pos, Quaternion.identity);
            //GameObject clone = Instantiate(newHerbivore, newHerbivore.transform, true);
            //clone.gameObject.transform.position = pos;
            
        }

        for (int i = 0; i < initialCarnivores; i++)
        {
            GameObject newCarnivore = CarnivorePrefab;
            Random.seed = System.DateTime.Now.Millisecond;
            // Sex
            int rand = Random.Range(1, 2);
            newCarnivore.GetComponent<CarnivoreBrain>().mSex = rand == 1 ? Creature.Sex.FEMALE : Creature.Sex.MALE;

            // Body type
            Random.seed = System.DateTime.Now.Millisecond;
            rand = Random.Range(1, System.Enum.GetNames(typeof(Body.BodyType)).Length);
            newCarnivore.GetComponent<CarnivoreBrain>().mBody.mBodyType = (Body.BodyType)rand;
            Random.seed = System.DateTime.Now.Millisecond;
            // Head active
            rand = Random.Range(1, System.Enum.GetNames(typeof(Head.Active)).Length);
            newCarnivore.GetComponent<CarnivoreBrain>().mHead.mActive = (Head.Active)rand;
            Random.seed = System.DateTime.Now.Millisecond;
            // Head passive
            rand = Random.Range(1, System.Enum.GetNames(typeof(Head.Passive)).Length);
            newCarnivore.GetComponent<CarnivoreBrain>().mHead.mPassive = (Head.Passive)rand;
            Random.seed = System.DateTime.Now.Millisecond;
            // Front limb active
            rand = Random.Range(1, System.Enum.GetNames(typeof(Limb.Active)).Length);
            newCarnivore.GetComponent<CarnivoreBrain>().FrontLimb.mActive = (Limb.Active)rand;
            Random.seed = System.DateTime.Now.Millisecond;
            // Front limb passive
            rand = Random.Range(1, System.Enum.GetNames(typeof(Limb.Passive)).Length);
            newCarnivore.GetComponent<CarnivoreBrain>().FrontLimb.mPassive = (Limb.Passive)rand;
            Random.seed = System.DateTime.Now.Millisecond;
            // Back limb active
            rand = Random.Range(1, System.Enum.GetNames(typeof(Limb.Active)).Length);
            newCarnivore.GetComponent<CarnivoreBrain>().BackLimb.mActive = (Limb.Active)rand;
            Random.seed = System.DateTime.Now.Millisecond;
            // Back limb passive
            rand = Random.Range(1, System.Enum.GetNames(typeof(Limb.Passive)).Length);
            newCarnivore.GetComponent<CarnivoreBrain>().BackLimb.mPassive = (Limb.Passive)rand;
            Random.seed = System.DateTime.Now.Millisecond;
            x = Random.Range(Wall4.transform.position.x, Wall2.transform.position.x);
            Random.seed = System.DateTime.Now.Millisecond;
            z = Random.Range(Wall1.transform.position.z, Wall3.transform.position.z);
            Vector3 newPos = new Vector3();
            newPos.x = x;
            newPos.y = 2;
            newPos.z = z;

            
            newCarnivore.gameObject.transform.position = newPos;
            Debug.Log("x = " + newCarnivore.transform.position.x + ", z = " + newCarnivore.transform.position.z);
            GameObject clone = Instantiate(newCarnivore, newPos, Quaternion.identity);
            Debug.Log("Clone position: " + clone.transform.position);
            clone.gameObject.transform.position = newPos;
        }
    }

    public static void CreateChildPlayer(GameObject mama, GameObject papa)
    {
        Creature newBorn;
        GameObject newBornGameObject;
        GameObject oldMe;

        if (mama.GetComponent<CreatureBehaviorScript>().creature.mCreatureType == Creature.CreatureType.HERBIVORE)
        {
            newBorn = new HerbivoreBrain();
            oldMe = HerbivorePrefab;
            oldMe.GetComponent<Creature>().mCreatureType = Creature.CreatureType.HERBIVORE;
        }
        else
        {
            newBorn = new CarnivoreBrain();
            oldMe = CarnivorePrefab;
            oldMe.GetComponent<Creature>().mCreatureType = Creature.CreatureType.HERBIVORE;
        }

        Vector3 pos = new Vector3(mama.transform.position.x, mama.transform.position.y, mama.transform.position.z + 2);
        GameObject oldMeJdid = Instantiate(oldMe, pos, Quaternion.identity);
        oldMeJdid.GetComponent<Creature>().mSex = mama.GetComponent<CreatureBehaviorScript>().creature.mSex;
        oldMeJdid.GetComponent<Creature>().mBody = mama.GetComponent<CreatureBehaviorScript>().creature.mBody;
        oldMeJdid.GetComponent<Creature>().FrontLimb = mama.GetComponent<CreatureBehaviorScript>().creature.FrontLimb;
        oldMeJdid.GetComponent<Creature>().BackLimb = mama.GetComponent<CreatureBehaviorScript>().creature.BackLimb;
        oldMeJdid.GetComponent<Creature>().mHead = mama.GetComponent<CreatureBehaviorScript>().creature.mHead;

        // Sex
        int rand = Random.Range(1, 3);
        Debug.Log("Random = " + rand);
        mama.GetComponent<CreatureBehaviorScript>().creature.mSex = rand == 1 ? Creature.Sex.FEMALE : Creature.Sex.MALE;

        // Body type
        rand = Random.Range(1, 3);
        Debug.Log("Random = " + rand);
        mama.GetComponent<CreatureBehaviorScript>().creature.mBody.mBodyType = rand == 1 ? mama.GetComponent<CreatureBehaviorScript>().creature.mBody.mBodyType : papa.GetComponent<Creature>().mBody.mBodyType;

        // Head - Active
        rand = Random.Range(1, 3);
        Debug.Log("Random = " + rand);
        mama.GetComponent<CreatureBehaviorScript>().creature.mHead.mActive = rand == 1 ? mama.GetComponent<CreatureBehaviorScript>().creature.mHead.mActive : papa.GetComponent<Creature>().mHead.mActive;

        // Head - Passive
        rand = Random.Range(1, 3);
        Debug.Log("Random = " + rand);
        mama.GetComponent<CreatureBehaviorScript>().creature.mHead.mPassive = rand == 1 ? mama.GetComponent<CreatureBehaviorScript>().creature.mHead.mPassive : papa.GetComponent<Creature>().mHead.mPassive;

        // Front limb - active
        rand = Random.Range(1, 3);
        Debug.Log("Random = " + rand);
        mama.GetComponent<CreatureBehaviorScript>().creature.FrontLimb.mActive = rand == 1 ? mama.GetComponent<CreatureBehaviorScript>().creature.FrontLimb.mActive : papa.GetComponent<Creature>().FrontLimb.mActive;

        // Front limb - passive
        rand = Random.Range(1, 3);
        Debug.Log("Random = " + rand);
        mama.GetComponent<CreatureBehaviorScript>().creature.FrontLimb.mPassive = rand == 1 ? mama.GetComponent<CreatureBehaviorScript>().creature.FrontLimb.mPassive : papa.GetComponent<Creature>().FrontLimb.mPassive;

        // Back limb - active
        rand = Random.Range(1, 3);
        Debug.Log("Random = " + rand);
        mama.GetComponent<CreatureBehaviorScript>().creature.BackLimb.mActive = rand == 1 ? mama.GetComponent<CreatureBehaviorScript>().creature.BackLimb.mActive : papa.GetComponent<Creature>().BackLimb.mActive;

        // Back limb - passive
        rand = Random.Range(1, 3);
        Debug.Log("Random = " + rand);
        mama.GetComponent<CreatureBehaviorScript>().creature.BackLimb.mPassive = rand == 1 ? mama.GetComponent<CreatureBehaviorScript>().creature.BackLimb.mPassive : papa.GetComponent<Creature>().BackLimb.mPassive;

        

        
    }

    public static void CreateChild(GameObject mama, GameObject papa)
    {
        Debug.Log("NEW CHILD");

        Creature newBorn;
        GameObject newBornGameObject;
        if (mama.GetComponent<HerbivoreBrain>() != null)
        {
            newBorn = new HerbivoreBrain();
            newBornGameObject = HerbivorePrefab;
                        
        } else
        {
            newBorn = new CarnivoreBrain();
            newBornGameObject = CarnivorePrefab;
        }

        // Sex
        int rand = Random.Range(1, 2);
        newBornGameObject.GetComponent<Creature>().mSex = rand == 1 ? Creature.Sex.FEMALE : Creature.Sex.MALE;

        // Body type
        rand = Random.Range(1, 2);
        newBornGameObject.GetComponent<Creature>().mBody.mBodyType = rand == 1 ? mama.GetComponent<Creature>().mBody.mBodyType : papa.GetComponent<Creature>().mBody.mBodyType;

        // Head - Active
        rand = Random.Range(1, 2);
        newBornGameObject.GetComponent<Creature>().mHead.mActive = rand == 1 ? mama.GetComponent<Creature>().mHead.mActive : papa.GetComponent<Creature>().mHead.mActive;

        // Head - Passive
        rand = Random.Range(1, 2);
        newBornGameObject.GetComponent<Creature>().mHead.mPassive = rand == 1 ? mama.GetComponent<Creature>().mHead.mPassive : papa.GetComponent<Creature>().mHead.mPassive;

        // Front limb - active
        rand = Random.Range(1, 2);
        newBornGameObject.GetComponent<Creature>().FrontLimb.mActive= rand == 1 ? mama.GetComponent<Creature>().FrontLimb.mActive : papa.GetComponent<Creature>().FrontLimb.mActive;

        // Front limb - passive
        rand = Random.Range(1, 2);
        newBornGameObject.GetComponent<Creature>().FrontLimb.mPassive = rand == 1 ? mama.GetComponent<Creature>().FrontLimb.mPassive : papa.GetComponent<Creature>().FrontLimb.mPassive;

        // Back limb - active
        rand = Random.Range(1, 2);
        newBornGameObject.GetComponent<Creature>().BackLimb.mActive = rand == 1 ? mama.GetComponent<Creature>().BackLimb.mActive : papa.GetComponent<Creature>().BackLimb.mActive;

        // Back limb - passive
        rand = Random.Range(1, 2);
        newBornGameObject.GetComponent<Creature>().BackLimb.mPassive = rand == 1 ? mama.GetComponent<Creature>().BackLimb.mPassive : papa.GetComponent<Creature>().BackLimb.mPassive;

        Instantiate(newBornGameObject, mama.transform.position, Quaternion.identity);
    }
 
    
    /*public static void CreateCreature()
    {
        //if (mama.GetComponent<HerbivoreBrain>() != null)
        {
            Creature newBorn = new Creature();

            // Sex

            int rand = Random.Range(1, 2);
            newBorn.mSex = rand == 1 ? Creature.Sex.FEMALE : Creature.Sex.MALE;

            // Body - Active
            rand = Random.Range(1, 6);
            switch (rand)
            {
                case 1:
                    newBorn.mBody.mActive = Body.Active.Beige;
                    break;
                case 2:
                    newBorn.mBody.mActive = Body.Active.Blue;
                    break;
                case 3:
                    newBorn.mBody.mActive = Body.Active.Camaleon;
                    break;
                case 4:
                    newBorn.mBody.mActive = Body.Active.Dark_Green;
                    break;
                case 5:
                    newBorn.mBody.mActive = Body.Active.Light_Green;
                    break;
                case 6:
                    newBorn.mBody.mActive = Body.Active.White;
                    break;
            }

            // Body - Passive
            rand = Random.RandomRange(1, 5);
            switch (rand)
            {
                case 1:
                    newBorn.mBody.mPassive = Body.Passive.Crest;
                    break;
                case 2:
                    newBorn.mBody.mPassive = Body.Passive.Feathers;
                    break;
                case 3:
                    newBorn.mBody.mPassive = Body.Passive.Fur;
                    break;
                case 4:
                    newBorn.mBody.mPassive = Body.Passive.Naked;
                    break;
                case 5:
                    newBorn.mBody.mPassive = Body.Passive.Scales;
                    break;
            }

            // Head - Active
            


            // Head - Passive

            // Front limb - Active

            // Front limb - Passive

            // Back limb - Active

            // Back limb - Passive


            


            //Instantiate()
        }
    }*/
}