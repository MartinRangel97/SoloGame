using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PowerupMenu : MonoBehaviour
{
    public GameObject PowerupPrefab;
    public Transform ButtonHolder;


    public void ShowPowerUP(int amount)
    {

        foreach(Transform child in ButtonHolder)
        {
            Destroy(child.gameObject);
        }
   
        List<PowerupData> SelectedPowerups = new List<PowerupData>();

        for(var i = 0; i < amount; i++)
        {
            bool IsUnique;

            do
            {
                PowerupData powerupData = Powerups.RandomPowerup();

                if (SelectedPowerups.Contains(powerupData))
                {
                    IsUnique = false;
                }
                else
                {
                    IsUnique = true;
                    SelectedPowerups.Add(powerupData);
                }

            }
            while (IsUnique.Equals(false));
        }

        foreach(PowerupData data in SelectedPowerups)
        {
            GameObject Powerup = Instantiate(PowerupPrefab, ButtonHolder);
            Powerup.transform.Find("Text").GetComponent<Text>().text = data.name;

        }

        
    }
}
