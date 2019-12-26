using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HerbivoreBrain : Creature
{
    public SeReproduire seReproduire;
    public SeBalader seBalader;
    public SeNourir seNourir;
    public Fuir fuir;
    public Dead dead;
    public Material deadMaterial;
    public Task currentTask;
    public Image bar;
    public GameObject characteristics;

    private void Start()
    {
        this.MaxHealth = 100f;
        this.CharacteristicsCanvas = characteristics;

        // Initializing the possible states for the creature
        this.seReproduire = this.gameObject.AddComponent<SeReproduire>();
        seReproduire.name = "Se Reproduire";
        this.seBalader = this.gameObject.AddComponent<SeBalader>();
        seBalader.name = "Se Balader";
        this.seNourir = this.gameObject.AddComponent<SeNourir>();
        seNourir.name = "Se Nourir";
        this.fuir = this.gameObject.AddComponent<Fuir>();
        fuir.name = "Fuir";
        this.dead = this.gameObject.AddComponent<Dead>();
        dead.name = "Dead";

        // Initializing different parameters of the creature

        this.Hunger = Random.Range(Game.minHunger, 100);
        this.ReproductiveNeed = Random.Range(Game.minReproductionNeed, 100);
        this.Speed = Random.Range(1, 10);
        this.CurrentHealth = Random.Range(MaxHealth / 2, MaxHealth);
        this.mCreatureType = CreatureType.HERBIVORE;

        // Initializing the initial rotation of the creature
        //this.gameObject.transform.Rotate(this.gameObject.transform.up * Random.Range(0, 360));

        // Defining the initial state of the creature
        this.CurrentState = seBalader;

        //Debug.Log("Hunger au debut:" + this.Hunger);
    }


    private void Update()
    {
        bar.fillAmount = CurrentHealth / MaxHealth;
        currentTask = CurrentState;
        //// Choosing the state //////
        ///  Movements are implemented in the current task's exec function

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
                    List<GameObject> predators = GetDifferentTypePercepts(this.gameObject, GameObject.FindGameObjectsWithTag("creature"));
                    if (predators.Count != 0)
                    {
                        CurrentState = fuir;
                    }
                    else
                    {
                        if (this.CurrentState == seNourir)
                        {
                            if (this.Hunger >= 99)
                            {
                                this.Hunger = 100;
                                CurrentState = seBalader;
                            }
                        }
                        else if (this.Hunger < Game.minHunger)
                        {
                            CurrentState = seNourir;
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
            
            
        }

        // Decrementing the creature's parameters every turn

        this.Hunger -= Game.HungerDecrementationPerUpdate;
        this.ReproductiveNeed -= Game.ReproductiveNeedDecrementationPerUpdate;

        // Update must end with this line:
        Debug.Log("Current State = " + CurrentState.name);
        CurrentState.exec(this.gameObject);
    }
}