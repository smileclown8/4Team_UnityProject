using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Died : MonoBehaviour
{
    GameObject Player_Hp;
    GameObject Player;

    Transform SavePoint_2Respawn;
    Transform SavePoint_3Respawn;
    Transform SavePoint_4Respawn;
    public GameObject SavePoint_2;
    public GameObject SavePoint_3;
    public GameObject SavePoint_4;


    void Awake()
    {
        Player_Hp = GameObject.Find("PlayerStatusManager");
        Player = GameObject.Find("player");
        SavePoint_2Respawn = GameObject.Find("1_2SavePoint_Off").transform;
        SavePoint_3Respawn = GameObject.Find("1_3SavePoint_Off").transform;
        SavePoint_4Respawn = GameObject.Find("1_4SavePoint_Off").transform;
    }


    void Update()
    {
         if (Player_Hp.GetComponent<PlayerStatusManager>().player_HP <= 0)
         {
            // 죽었을 경우 1_2의 깃발만 활성화 되어 있으면, 1_2 깃발로 되돌아가며, 이슬라프의 맥스 체력으로 피를 회복시킨다.
            if (SavePoint_2.GetComponent<SavePoint>().here == 1)
            {
                Player.transform.position
               = new Vector2(SavePoint_2Respawn.position.x, SavePoint_2Respawn.position.y);
                Player_Hp.GetComponent<PlayerStatusManager>().player_HP = Player_Hp.GetComponent<PlayerStatusManager>().player_MaxHP;
            }

            // 죽었을 경우 1_3의 깃발까지 활성화 되어 있으면, 1_3 깃발로 되돌아가며, 이슬라프의 맥스 체력으로 피를 회복시킨다.
            if (SavePoint_2.GetComponent<SavePoint>().here == 1 && SavePoint_3.GetComponent<SavePoint>().here == 1)
            {
                Player.transform.position
               = new Vector2(SavePoint_3Respawn.position.x, SavePoint_3Respawn.position.y);
                Player_Hp.GetComponent<PlayerStatusManager>().player_HP = Player_Hp.GetComponent<PlayerStatusManager>().player_MaxHP;
            }


            // 죽었을 경우 1_4의 깃발까지 활성화 되어 있으면, 1_4 깃발로 되돌아가며, 이슬라프의 맥스 체력으로 피를 회복시킨다.
            if (SavePoint_2.GetComponent<SavePoint>().here == 1 && SavePoint_3.GetComponent<SavePoint>().here == 1 && SavePoint_4.GetComponent<SavePoint>().here == 1)
            {
                Player.transform.position
               = new Vector2(SavePoint_4Respawn.position.x, SavePoint_4Respawn.position.y);
                Player_Hp.GetComponent<PlayerStatusManager>().player_HP = Player_Hp.GetComponent<PlayerStatusManager>().player_MaxHP;
            }
        }

    }
}

