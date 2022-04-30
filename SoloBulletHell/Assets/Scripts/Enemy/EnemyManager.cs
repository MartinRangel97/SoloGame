using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyManager : MonoBehaviour
{
    public List<Transform> SpawnPoints;

    public static int NumberOfEnemies = 4;

    public GameObject Enemy;
    public Player Player;
   

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform.Find("Spawn Points"))
        {
            SpawnPoints.Add(child);
        }
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        foreach(Transform SP in SpawnPoints)
        {
            for(var i = 0; i < NumberOfEnemies; i++)
            {
                
                GameObject EnemyNPC = Instantiate(Enemy, new Vector3(Random.Range(SP.localPosition.x + 2f, SP.localPosition.x - 2f), Random.Range(SP.localPosition.y + 2f, SP.localPosition.y - 2f)), SP.localRotation, transform.Find("Enemies"));
                EnemyNPC.GetComponent<AIDestinationSetter>().target = Player.transform;
            }
        }
    }
}
