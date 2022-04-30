using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Transform> SpawnPoints;

    public static int NumberOfEnemies = 4;

    public GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform.Find("Spawn Points"))
        {
            SpawnPoints.Add(child);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
