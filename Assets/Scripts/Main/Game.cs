using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
    //TODO: Make variables static after test
    public static int minHunger = 20;
    public static int minReproductionNeed = 20;
    public static float visionRadius = 15.0f;

    public GameObject HerbivorePrefabPublic;
    public GameObject CarnivorePrefabPublic;

    public static GameObject HerbivorePrefab;
    public static GameObject CarnivorePrefab;

    public static GameObject Me;

    private void Start()
    {
        CarnivorePrefab = CarnivorePrefabPublic;
        HerbivorePrefab = HerbivorePrefabPublic;
        Me = this.gameObject;
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
        //newBornGameObject.GetComponent<Creature>().mSex = rand == 1 ? Creature.Sex.FEMALE : Creature.Sex.MALE;

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