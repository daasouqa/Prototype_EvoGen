using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limb : Characteristic
{
    public enum Passive {
        Pattes_base,
        ailes,
        Nageoir,
        Pattes_longues,
    };

    public enum Active {
        Pattes_saut,
        Griffes,
        pouce_opp,
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

    public Limb() : base()
    {
        active = Active.Griffes;
        passive = Passive.ailes;

        //active = GetRandomCharacteristic<Limb.Active>();
        //passive = GetRandomCharacteristic<Limb.Passive>();
    }

    public Limb(int level) : base(level)
    {
        active = GetRandomCharacteristic<Active>();
        passive = GetRandomCharacteristic<Passive>();
    }

    void setActive(Active a) { active = a; }
    void setPassive(Passive p) { passive = p; }
}
