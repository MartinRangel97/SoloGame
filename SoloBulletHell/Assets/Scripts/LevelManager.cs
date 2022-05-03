using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static int Level;
    public EnemyManager EnemyManager;
    public PowerupMenu PowerupMenu;

    private bool RoundStarted = true;

    // Start is called before the first frame update
    void Start()
    {
        Level = 1;
        RoundStart();
    }

    private void Update()
    {
        if (EnemyManager.EnemyHolder.childCount == 0 && RoundStarted)
        {
            RoundEnd();
        }
    }

    public void RoundStart()
    {
        RoundStarted = true;
        Time.timeScale = 1;
        int SpawnModifier = 4 + Mathf.RoundToInt(Level/2);
        //spawn enemies
        EnemyManager.Spawn(SpawnModifier);
    }

    public  void RoundEnd()
    {
        RoundStarted = false;
        //show UI for powerups
        PowerupMenu.gameObject.SetActive(true);
        PowerupMenu.ShowPowerUP(3);
        Time.timeScale = 0;
        Level += 1;
    }
}
