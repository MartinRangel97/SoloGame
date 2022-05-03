using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupData
{
    public string name;
    public string rarity;
    public float value;

    public PowerupData(string _name, string _rarity, float _value)
    {
        name = _name;
        rarity = _rarity;
        value = _value;
    }
}
