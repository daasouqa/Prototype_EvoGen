using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : Characteristic
{
    public enum Passive {
        Dents_base,
        Dents_sec,
        Dents_loph,
        Dents_bun,
    };
    public enum Active {
        Deffenses,
        Cornes,
        crocs,
    };

    private Active active;
    public Active mActive
    {
        get => active;
        set => active = value;
    }

    private Passive passive;
    public Passive mPassive
    {
        get => passive;
        set => passive = value;
    }

    public Head() : base()
    {
        active = Active.Cornes;
        passive = Passive.Dents_base;

       //active = GetRandomCharacteristic<Head.Active>();
       //passive = GetRandomCharacteristic<Head.Passive>();
    }

    public Head(int level) : base(level)
    {
        active = GetRandomCharacteristic<Active>();
        passive = GetRandomCharacteristic<Passive>();
    }

    void setActive(Active a) { active = a; }
    void setPassive(Passive p) { passive = p; }
}
