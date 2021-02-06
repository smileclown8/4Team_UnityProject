using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReStartPosManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("PlayerStatusManager") != null)
        {
            GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().PlayerRespawn_Pos
                   = this.transform.position;
        }
    }
}
