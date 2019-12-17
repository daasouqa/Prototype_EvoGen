using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Creature
{
    public Player(float initialHealth)
    {
        MaxHealth = initialHealth;
        CurrentHealth = initialHealth;
    }

    public Player(Head h, Body b, Limb lf, Limb lb, float initialHealth)
    {
        this.mHead = h;
        this.mBody = b;
        this.FrontLimb = lf;
        this.BackLimb = lb;
        this.MaxHealth = initialHealth;
        this.CurrentHealth = initialHealth;
    }

    //public Player Reproduce(Creature c)
    //{
    //    Player descendant = new Player(MaxHealth);
    //    return descendant;
    //}

    public void Heal(float health)
    {
        this.CurrentHealth += health;
        if (this.CurrentHealth > this.MaxHealth) this.CurrentHealth = this.MaxHealth;
    }

    public void LoseHealth(float health)
    {
        this.CurrentHealth -= health;
        if (this.CurrentHealth < 0) Die();
    }

    public void Die()
    {
        Debug.Log("I'm dead :(");
    }

    public void GrowOlder()
    {
        this.CurrentHealth--;
        if (this.CurrentHealth < 0) Die();
    }

    private void Update()
    {
        
    }
}
