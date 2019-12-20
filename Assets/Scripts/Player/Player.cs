using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Creature
{
    public Player(CreatureType type)
    {
        this.mHead = new Head();
        this.mBody = new Body();
        this.FrontLimb = new Limb();
        this.BackLimb = new Limb();

        if (type == CreatureType.HERBIVORE)
        {
            this.mHead.mActive = Head.Active.Cornes;
            this.mHead.mPassive = Head.Passive.Dents_base;
            
            this.mBody.mBodyType = Body.BodyType.peau_base;
            
            this.FrontLimb.mActive = Limb.Active.Pattes_saut;
            this.FrontLimb.mPassive = Limb.Passive.Pattes_base;
            
            this.BackLimb.mActive = Limb.Active.Pattes_saut;
            this.BackLimb.mPassive = Limb.Passive.Pattes_base;
        } else
        {
            this.mHead.mActive = Head.Active.crocs;
            this.mHead.mPassive = Head.Passive.Dents_base;

            this.mBody.mBodyType = Body.BodyType.peau_base;

            this.FrontLimb.mActive = Limb.Active.Pattes_saut;
            this.FrontLimb.mPassive = Limb.Passive.Pattes_base;

            this.BackLimb.mActive = Limb.Active.Pattes_saut;
            this.BackLimb.mPassive = Limb.Passive.Pattes_base;
        }

        this.MaxHealth = 100;
        this.CurrentHealth = 100;
    }

    public Player(float initialHealth)
    {
        MaxHealth = initialHealth;
        CurrentHealth = initialHealth;
        Hunger = 100;
        ReproductiveNeed = 100;
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
