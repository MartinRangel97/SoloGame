using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Powerup : MonoBehaviour
{
    private Button button;
    private Player player;
    private LevelManager levelManager;
    public Transform ButtonHolder;


    private void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(ApplyPowerup);
        player = GameObject.Find("Player").GetComponent<Player>();
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        ButtonHolder = transform.parent;
    }

    private void ApplyPowerup()
    {
        Debug.Log(transform.GetChild(0).GetComponent<Text>().text);
        player.AddPowerup(transform.GetChild(0).GetComponent<Text>().text);
        levelManager.RoundStart();
        foreach(Transform child in ButtonHolder)
        {
            Destroy(child.gameObject);
        }
        this.transform.parent.parent.gameObject.SetActive(false);

    }


}
