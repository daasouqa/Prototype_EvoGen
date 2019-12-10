using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivoreBrain : Creature
{


    public SeBalader seBalader;
    public Chasser chasser;
    public SeReproduire seReproduire;
    public Dead dead;

    public Material deadMaterial;

    

    void Start()
    {
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
        this.gameObject.transform.Rotate(this.gameObject.transform.up * Random.Range(0, 180));
    }

    // Update is called once per frame
    void Update()
    {
        /////////////////////////////

        //// Choosing the state //////

        /////////////////////////////

        // Movements are implemented in the current task's exec function

        // Update must end with this line:
        CurrentState.exec(this.gameObject);

    }
}
