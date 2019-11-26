using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class HerbivoreBrain : Creature
{
    public SeReproduire seReproduire;
    public SeBalader seBalader;
    public SeNourir seNourir;
    public Fuir fuir;
    public Dead dead;

    private void Start()
    {
        
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
        this.Speed = Random.Range(1, 5);

        // Defining the initial state of the creature
        this.CurrentState = seBalader;
    }


    private void Update()
    {
        //// Choosing the state //////
        ///  Movements are implemented in the current task's exec function

        if (CurrentState != dead)
        {
            List<GameObject> predators = GetPercepts(this.gameObject ,GameObject.FindGameObjectsWithTag("carnivore"));
            if (predators.Count != 0)
            {
                CurrentState = fuir;
            }
            else
            {
                if (this.Hunger < Game.minHunger)
                {
                    CurrentState = seNourir;
                }
                else
                {
                    if (this.ReproductiveNeed < Game.minReproductionNeed)
                    {
                        CurrentState = seReproduire;
                    }
                }
            }
        }

        // Update must end with this line:
        Debug.Log("Current State = " + CurrentState.name);
        CurrentState.exec(this.gameObject);
    }
}