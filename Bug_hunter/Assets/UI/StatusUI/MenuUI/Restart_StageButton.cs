using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart_StageButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CanRestartAgain()
    {

    }

    public bool canRestart = false;
    public GameObject Menu_Set;
    public void Restart()
    {

    //    if (!canRestart)
      //  {
            GameObject.Find("player").transform.position = GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().PlayerRespawn_Pos;
            Time.timeScale = 1;
            Menu_Set.SetActive(false);

       //     canRestart = true;
      //  }
    }
}
