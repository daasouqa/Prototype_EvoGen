using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : Characteristic
{
    public enum BodyType {
        peau_base,
        fourrure ,
        plumes   ,
        ecailles ,
        voile    ,
        cameleon ,
        carapace ,
        Piquants ,
        long_coup,
    };

    private BodyType bodyType;
    public BodyType mBodyType {
        get => bodyType;
        set => bodyType = value;
    }

    public Body() : base()
    {
        bodyType = BodyType.peau_base;
    }

    public Body(int level) : base(level)
    {
        bodyType = BodyType.peau_base;
    }
}
