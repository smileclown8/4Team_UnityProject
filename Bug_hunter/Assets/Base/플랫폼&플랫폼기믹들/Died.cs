using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Died : MonoBehaviour
{
    GameObject Player_Hp;
    GameObject Player;

    void Awake()
    {
        Player_Hp = GameObject.Find("PlayerStatusManager");
        Player = GameObject.Find("player");
    }

    void Update()
    {
         if (!isRespawn && Player_Hp.GetComponent<PlayerStatusManager>().player_HP <= 0)
         {
            /*
            // 사망 사운드
            GameObject.Find("PlayerDeadVoice").GetComponent<AudioSource>().clip = GameObject.FindWithTag("Player").GetComponent<PlayerController>().death;
            GameObject.Find("PlayerDeadVoice").GetComponent<AudioSource>().Play();
            */

            isRespawn = true;
            Debug.Log("플레이어 사망");
            Invoke("RespawnWait", 2f);
         }
    }

    private bool isRespawn = false;


    void RespawnWait()
    {
        Player.transform.position =
             GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().PlayerRespawn_Pos;
        Player_Hp.GetComponent<PlayerStatusManager>().player_HP =
            Player_Hp.GetComponent<PlayerStatusManager>().player_MaxHP;
        isRespawn = false;
    }
}

