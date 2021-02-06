using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss2_GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        if (GameObject.Find("PlayerStatusManager") != null)
        {
            if (GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().player_HP <= 0)
            {
                Debug.Log("보스방에서 사망");
                GameOver();
            }
        }


        Debug.Log(GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().PlayerRespawn_Pos);
    }


    void GameOver()
    {

        SceneManager.LoadScene("2Stage_Map");
        GameObject.Find("player").transform.position = GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().PlayerRespawn_Pos;

    }
}
