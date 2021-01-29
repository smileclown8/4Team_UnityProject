using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageBattleResultManager : MonoBehaviour
{
    public GameObject PlayerStatusManager;
    public GameObject Boss_CORE;

    // Start is called before the first frame update
    void Start()
    {
        PlayerStatusManager = GameObject.Find("PlayerStatusManager");
        Boss_CORE = GameObject.Find("Boss_CORE");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
