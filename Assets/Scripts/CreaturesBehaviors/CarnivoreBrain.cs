using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarnivoreBrain : Creature
{


    public SeBalader seBalader;
    public Chasser chasser;
    public SeReproduire seReproduire;
    public Dead dead;

    public Material deadMaterial;
    public Task currentTask;

    public Image bar;
    public GameObject characteristics;
    public GameObject dustEffects;

    public GameObject Wall1;
    public GameObject Wall2;
    public GameObject Wall3;
    public GameObject Wall4;


    void Start()
    {
        this.MaxHealth = 100f;
        this.CharacteristicsCanvas = characteristics;


        // Initializing the possible states for the creature
        this.seBalader = this.gameObject.AddComponent<SeBalader>();
        this.chasser = this.gameObject.AddComponent<Chasser>();
        this.seReproduire = this.gameObject.AddComponent<SeReproduire>();
        this.dead = this.gameObject.AddComponent<Dead>();

        // Defining the initial state of the creature
        this.CurrentState = seBalader;

        // Initializing different parameters of the creature
        this.Hunger = Random.Range(Game.minHunger, 100);
        this.ReproductiveNeed = Random.Range(Game.minReproductionNeed, 100);
        this.Speed = Random.Range(1, 10);
        this.CurrentHealth = Random.Range(MaxHealth / 2, MaxHealth);
        this.mCreatureType = CreatureType.CARNIVORE;

        // Initializing the initial rotation of the creature
        this.gameObject.transform.Rotate(this.gameObject.transform.up * Random.Range(0, 360));

        // Sex
        int rand = Random.Range(1, 2);
        this.GetComponent<CarnivoreBrain>().mSex = rand == 1 ? Creature.Sex.FEMALE : Creature.Sex.MALE;

        // Body type
        Random.seed = System.DateTime.Now.Millisecond;
        rand = Random.Range(1, System.Enum.GetNames(typeof(Body.BodyType)).Length);
        this.GetComponent<CarnivoreBrain>().mBody.mBodyType = (Body.BodyType)rand;

        Random.seed = System.DateTime.Now.Millisecond;
        // Head active
        rand = Random.Range(1, System.Enum.GetNames(typeof(Head.Active)).Length);
        this.GetComponent<CarnivoreBrain>().mHead.mActive = (Head.Active)rand;

        Random.seed = System.DateTime.Now.Millisecond;
        // Head passive
        rand = Random.Range(1, System.Enum.GetNames(typeof(Head.Passive)).Length);
        this.GetComponent<CarnivoreBrain>().mHead.mPassive = (Head.Passive)rand;

        Random.seed = System.DateTime.Now.Millisecond;
        // Front limb active
        rand = Random.Range(1, System.Enum.GetNames(typeof(Limb.Active)).Length);
        this.GetComponent<CarnivoreBrain>().FrontLimb.mActive = (Limb.Active)rand;

        Random.seed = System.DateTime.Now.Millisecond;
        // Front limb passive
        rand = Random.Range(1, System.Enum.GetNames(typeof(Limb.Passive)).Length);
        this.GetComponent<CarnivoreBrain>().FrontLimb.mPassive = (Limb.Passive)rand;

        Random.seed = System.DateTime.Now.Millisecond;
        // Back limb active
        rand = Random.Range(1, System.Enum.GetNames(typeof(Limb.Active)).Length);
        this.GetComponent<CarnivoreBrain>().BackLimb.mActive = (Limb.Active)rand;

        Random.seed = System.DateTime.Now.Millisecond;
        // Back limb passive
        rand = Random.Range(1, System.Enum.GetNames(typeof(Limb.Passive)).Length);
        this.BackLimb.mPassive = (Limb.Passive)rand;


    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Current Health = " + CurrentHealth);
        bar.fillAmount = CurrentHealth / MaxHealth;
        currentTask = CurrentState;
        if (CurrentState != dead)
        {
            if (this.CurrentHealth <= 0)
            {
                CurrentState = dead;
            } else
            {
                if (this.Hunger <= 0 || this.ReproductiveNeed <= 0)
                {
                    CurrentHealth -= 0.1f;
                }
                else
                {
                    if (this.CurrentState == chasser)
                    {
                        if (this.Hunger >= 99)
                        {
                            this.Hunger = 100;
                            CurrentState = seBalader;
                        }
                    }
                    else if (this.Hunger < Game.minHunger)
                    {
                        CurrentState = chasser;

                    }
                    else
                    {
                        if (this.ReproductiveNeed < Game.minReproductionNeed)
                        {
                            CurrentState = seReproduire;
                        }
                        else
                        {
                            CurrentState = seBalader;
                        }
                    }
                }
            }
        }

        this.Hunger -= Game.HungerDecrementationPerUpdate;
        this.ReproductiveNeed -= Game.ReproductiveNeedDecrementationPerUpdate;

        // Movements are implemented in the current task's exec function
        Debug.Log("Current state (Carnivore):" + CurrentState.name);
        // Update must end with this line:
        CurrentState.exec(this.gameObject);

    }
}
