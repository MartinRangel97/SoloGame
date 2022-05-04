using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI HealthText;
    public Player Player;
    private Slider HealthSlider;

    // Start is called before the first frame update
    void Start()
    {
        HealthText.text = Player.MaxHealth.ToString() + " / " + Player.MaxHealth.ToString();
        HealthSlider = gameObject.GetComponent<Slider>();
        HealthSlider.maxValue = Player.MaxHealth;
        HealthSlider.minValue = Player.MaxHealth;
    }

    private void Update()
    {
        HealthText.text = Player.CurrentHealth.ToString() + " / " + Player.MaxHealth.ToString();
    }

    public void SetCurrentHealth()
    {
        HealthText.text = Player.CurrentHealth.ToString() + " / " + Player.MaxHealth.ToString();
        HealthSlider.minValue = Player.CurrentHealth;

    }

    public void SetMaxHealth()
    {

        HealthText.text = Player.CurrentHealth.ToString() + " / " + Player.MaxHealth.ToString();
        HealthSlider.maxValue = Player.MaxHealth;
    }
}
