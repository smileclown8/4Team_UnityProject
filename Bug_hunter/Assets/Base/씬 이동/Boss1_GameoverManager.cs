using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss1_GameoverManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("PlayerStatusManager") != null)
        {
            if (GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().player_HP <= 0
                && !isdead)
            {
                isdead = true;
                Invoke("GameOver", 1.5f);
            }
        }

        if (isMoved)
        {
            Invoke("MoveToSavePoint", 0.1f);
            isMoved = false;
        }

        if(SceneManager.GetActiveScene().name == "2Stage_Map")
        {
            Destroy(this.gameObject);
        }
    }
    private bool isdead = false;
    private bool isMoved = false;

    void MoveToSavePoint()
    {
        if (GameObject.Find("SavePoint_1_5") != null)
        {
            GameObject.Find("player").transform.position = GameObject.Find("SavePoint_1_5").transform.position;
            GameObject.Find("player").GetComponent<PlayerController>().isDead = false;
            Destroy(this.gameObject);
        }
    }

    void GameOver()
    {

        isMoved = true;

        SceneManager.LoadScene("1Stage_Map");
        GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().player_HP = GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().player_MaxHP;
    }
}
