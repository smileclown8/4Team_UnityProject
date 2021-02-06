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
            // 사망 애니메이션
            GameObject.FindWithTag("Player").GetComponent<Animator>().SetTrigger("Dead");
            // 사망 사운드 : 으윽! + 브금
            GameObject.FindWithTag("Player").GetComponent<AudioSource>().clip = GameObject.FindWithTag("Player").GetComponent<PlayerController>().death;
            GameObject.FindWithTag("Player").GetComponent<AudioSource>().Play();
            Invoke("DeathBGM", 0.25f);



            isRespawn = true;
            Debug.Log("플레이어 사망");
            Invoke("RespawnWait", 2f);
         }
    }
    void DeathBGM()     // 사망브금
    {
        GameObject.Find("PlayerDeadSound").GetComponent<AudioSource>().volume = 0.7f;
        GameObject.Find("PlayerDeadSound").GetComponent<AudioSource>().clip = GameObject.Find("PlayerDeadSound").GetComponent<EslafDeadSound>().dead;
        GameObject.Find("PlayerDeadSound").GetComponent<AudioSource>().Play();
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

