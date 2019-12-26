﻿using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
    public static int minHunger = 20;
    public static int minReproductionNeed = 20;
    public static float visionRadius = 15.0f;
    public static float HungerDecrementationPerUpdate = 0.01f;
    public static float ReproductiveNeedDecrementationPerUpdate = 0.01f;
    public static int RottingTime = 100;

    public GameObject HerbivorePrefabPublic;
    public GameObject CarnivorePrefabPublic;

    public static GameObject HerbivorePrefab;
    public static GameObject CarnivorePrefab;

    public static GameObject Me;

    public static Creature.CreatureType playerType;

    public static bool isPaused;
    

    private void Start()
    {
        CarnivorePrefab = CarnivorePrefabPublic;
        HerbivorePrefab = HerbivorePrefabPublic;
        Me = this.gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
    }

    public static void CreateChildPlayer(GameObject mama, GameObject papa)
    {
        Debug.Log("NEW CHILD");

        Creature newBorn;
        GameObject newBornGameObject;
        if (mama.GetComponent<CreatureBehaviorScript>().creature.mCreatureType == Creature.CreatureType.HERBIVORE)
        {
            newBorn = new HerbivoreBrain();
            newBornGameObject = HerbivorePrefab;

        }
        else
        {
            newBorn = new CarnivoreBrain();
            newBornGameObject = CarnivorePrefab;
        }

        // Sex
        int rand = Random.Range(1, 2);
        newBornGameObject.GetComponent<Creature>().mSex = rand == 1 ? Creature.Sex.FEMALE : Creature.Sex.MALE;

        // Body type
        rand = Random.Range(1, 2);
        newBornGameObject.GetComponent<Creature>().mBody.mBodyType = rand == 1 ? mama.GetComponent<CreatureBehaviorScript>().creature.mBody.mBodyType : papa.GetComponent<Creature>().mBody.mBodyType;

        // Head - Active
        rand = Random.Range(1, 2);
        newBornGameObject.GetComponent<Creature>().mHead.mActive = rand == 1 ? mama.GetComponent<CreatureBehaviorScript>().creature.mHead.mActive : papa.GetComponent<Creature>().mHead.mActive;

        // Head - Passive
        rand = Random.Range(1, 2);
        newBornGameObject.GetComponent<Creature>().mHead.mPassive = rand == 1 ? mama.GetComponent<CreatureBehaviorScript>().creature.mHead.mPassive : papa.GetComponent<Creature>().mHead.mPassive;

        // Front limb - active
        rand = Random.Range(1, 2);
        newBornGameObject.GetComponent<Creature>().FrontLimb.mActive = rand == 1 ? mama.GetComponent<CreatureBehaviorScript>().creature.FrontLimb.mActive : papa.GetComponent<Creature>().FrontLimb.mActive;

        // Front limb - passive
        rand = Random.Range(1, 2);
        newBornGameObject.GetComponent<Creature>().FrontLimb.mPassive = rand == 1 ? mama.GetComponent<CreatureBehaviorScript>().creature.FrontLimb.mPassive : papa.GetComponent<Creature>().FrontLimb.mPassive;

        // Back limb - active
        rand = Random.Range(1, 2);
        newBornGameObject.GetComponent<Creature>().BackLimb.mActive = rand == 1 ? mama.GetComponent<CreatureBehaviorScript>().creature.BackLimb.mActive : papa.GetComponent<Creature>().BackLimb.mActive;

        // Back limb - passive
        rand = Random.Range(1, 2);
        newBornGameObject.GetComponent<Creature>().BackLimb.mPassive = rand == 1 ? mama.GetComponent<CreatureBehaviorScript>().creature.BackLimb.mPassive : papa.GetComponent<Creature>().BackLimb.mPassive;

        Instantiate(newBornGameObject, mama.transform.position, Quaternion.identity);
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