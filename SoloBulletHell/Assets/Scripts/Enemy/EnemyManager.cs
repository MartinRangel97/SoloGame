using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyManager : MonoBehaviour
{
    public List<Transform> SpawnPoints;
    public GameObject Enemy;
    public Player Player;
    public Transform EnemyHolder;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Transform child in transform.Find("Spawn Points"))
        {
            SpawnPoints.Add(child);
        }
        
    }

    public void Spawn(int NumberOfEnemies)
    {
        foreach(Transform SP in SpawnPoints)
        {
            for(var i = 0; i < NumberOfEnemies; i++)
            {
                
                GameObject EnemyNPC = Instantiate(Enemy, new Vector3(Random.Range(SP.localPosition.x + 2f, SP.localPosition.x - 2f), Random.Range(SP.localPosition.y + 2f, SP.localPosition.y - 2f)), SP.localRotation, EnemyHolder);
                EnemyNPC.GetComponent<AIDestinationSetter>().target = Player.transform;
                EnemyNPC.GetComponent<Enemy>().SetMaxHealth();
            }
        }
    }
}
