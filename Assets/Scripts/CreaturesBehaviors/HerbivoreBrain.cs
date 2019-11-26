using UnityEngine;
using UnityEditor;

public class HerbivoreBrain : Creature
{
    public SeBalader seBalader;
    public SeNourir seNourir;
    public Fuir fuir;

    private void Start()
    {
        this.seBalader = this.gameObject.AddComponent<SeBalader>();
        this.seBalader.moveSpeed = 3.0f;
        this.seBalader.rotSpeed = 10.0f;
        this.seNourir = this.gameObject.AddComponent<SeNourir>();
        this.fuir = this.gameObject.AddComponent<Fuir>();
        this.CurrentState = seBalader;
    }


    private void Update()
    {
        /////////////////////////////

        //// Choosing the state //////

        /////////////////////////////

        // Movements are implemented in the current task's exec function

        // Update must end with this line:
        CurrentState.exec(this.gameObject);
    }
}