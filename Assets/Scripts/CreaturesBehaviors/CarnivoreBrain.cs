using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivoreBrain : Creature
{


    SeBalader seBalader;
    Chasser chasser = new Chasser("Chasser");

    

    void Start()
    {
        this.seBalader = this.gameObject.AddComponent<SeBalader>();
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
