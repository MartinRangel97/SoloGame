using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public EnemyManager EnemyManager;
    void Start()
    {
        player.SetBasicStats();
    }

    
}
