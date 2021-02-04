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
         if (Player_Hp.GetComponent<PlayerStatusManager>().player_HP <= 0)
         {

            Debug.Log("플레이어 사망");
            Invoke("RespawnWait", 2f);
         }
    }


    void RespawnWait()
    {
        Player.transform.position =
             GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().PlayerRespawn_Pos;
        Player_Hp.GetComponent<PlayerStatusManager>().player_HP =
            Player_Hp.GetComponent<PlayerStatusManager>().player_MaxHP;
    }
}

