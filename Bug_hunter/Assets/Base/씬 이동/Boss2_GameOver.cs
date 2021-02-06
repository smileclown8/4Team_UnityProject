using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss2_GameOver : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

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
                GameOver();
            }
        }


        if (isMoved)
        {
            Invoke("MoveToSavePoint", 0.1f);
            isMoved = false;
        }
    }
    private bool isMoved = false;

    void MoveToSavePoint()
    {
        if (GameObject.Find("2_5SavePoint_Off") != null)
        {
            GameObject.Find("player").transform.position = GameObject.Find("2_5SavePoint_Off").transform.position;
            Destroy(this.gameObject);
        }
    }

    void GameOver()
    {
        isMoved = true;
        GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().player_HP
           = GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().player_MaxHP;
        SceneManager.LoadScene("2Stage_Map");

    }
}
