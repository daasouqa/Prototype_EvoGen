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


    void Start()
    {
        this.MaxHealth = 100f;
        this.CharacteristicsCanvas = characteristics;

        Debug.Log("Max Health  = " + MaxHealth);

        // Initializing the possible states for the creature
        this.seBalader = this.gameObject.AddComponent<SeBalader>();
        seBalader.name = "Se Balader";
        this.chasser = this.gameObject.AddComponent<Chasser>();
        chasser.name = "Chasser";
        this.seReproduire = this.gameObject.AddComponent<SeReproduire>();
        seReproduire.name = "Se Reproduire";
        this.dead = this.gameObject.AddComponent<Dead>();
        dead.name = "Dead";

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

        this.mHead.mActive = Head.Active.crocs;
        this.mHead.mPassive = Head.Passive.Dents_sec;
        this.mBody.mBodyType = Body.BodyType.fourrure;
        this.FrontLimb.mActive = Limb.Active.Griffes;
        this.FrontLimb.mPassive = Limb.Passive.Pattes_longues;
        this.BackLimb.mActive = Limb.Active.Griffes;
        this.BackLimb.mPassive = Limb.Passive.Pattes_longues;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Current Health = " + CurrentHealth);
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

        this.Hunger -= 0.01f;
        this.ReproductiveNeed -= 0.01f;

        // Movements are implemented in the current task's exec function
        Debug.Log("Current state (Carnivore):" + CurrentState.name);
        // Update must end with this line:
        CurrentState.exec(this.gameObject);

    }
}
