using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static bool RoundStarted;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void RoundStart()
    {
        LevelManager.RoundStarted = true;
    }

    public static void RoundEnd()
    {
        LevelManager.RoundStarted = false;
    }
}
