using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    private void Awake()
    {
        Powerups.SetupList();
    }
}
