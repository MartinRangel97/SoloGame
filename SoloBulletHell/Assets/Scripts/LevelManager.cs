using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int Level;
    public EnemyManager EnemyManager;

    // Start is called before the first frame update
    void Start()
    {
        Level = 1;
        RoundStart();
    }

    private void Update()
    {
        if(EnemyManager.EnemyHolder.childCount == 0)
        {
            RoundEnd();
        }
    }

    public void RoundStart()
    {
        Time.timeScale = 1;
        int SpawnModifier = 4 + Mathf.RoundToInt(Level/2);
        //spawn enemies
        EnemyManager.Spawn(SpawnModifier);
    }

    public void RoundEnd()
    {
        //show UI for powerups
        Time.timeScale = 0;
        Level += 1;
    }
}
