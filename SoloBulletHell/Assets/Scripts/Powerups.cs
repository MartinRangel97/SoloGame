using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups
{ 

    public static List<PowerupData> PowerupList = new List<PowerupData>();

    private static System.Random random = new System.Random();

    public static void SetupList()
    {
        PowerupList.Add(new PowerupData("Pierce","Common", 1f));
        PowerupList.Add(new PowerupData("Bounce","Common", 1f));
        PowerupList.Add(new PowerupData("Damage","Common", 1f));
        PowerupList.Add(new PowerupData("Fire Rate","Common", 0.1f));
        PowerupList.Add(new PowerupData("Health","Common", 2f));
        PowerupList.Add(new PowerupData("Speed","Common", 1f));
    }

    public static PowerupData RandomPowerup()
    {
        int index = random.Next(PowerupList.Count);
        return PowerupList[index];
    }

    public static PowerupData FindPowerup(string name)
    {
        PowerupData SelectedPowerup = PowerupList.Find((x) => x.name == name);
        return SelectedPowerup;
    }
 }
