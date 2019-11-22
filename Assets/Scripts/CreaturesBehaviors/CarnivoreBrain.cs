using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivoreBrain : Creature
{
    

    SeBalader seBalader = new SeBalader("Se Balader");
    Chasser chasser = new Chasser("Chasser");

    

    void Start()
    {
        currentTask = seBalader;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Si faim : Chasse
        
    }
}
