using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivoreBrain : Creature
{


    SeBalader seBalader;
    Chasser chasser;
    SeReproduire seReproduire;
    Dead dead;

    

    void Start()
    {
        // Initializing the possible states for the creature
        this.seBalader = this.gameObject.AddComponent<SeBalader>();
        this.chasser = this.gameObject.AddComponent<Chasser>();
        this.seReproduire = this.gameObject.AddComponent<SeReproduire>();
        this.dead = this.gameObject.AddComponent<Dead>();

        // Defining the initial state of the creature
        this.CurrentState = seBalader;
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
