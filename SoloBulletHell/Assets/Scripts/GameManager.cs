using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    void Start()
    {
        player.SetBasicStats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
