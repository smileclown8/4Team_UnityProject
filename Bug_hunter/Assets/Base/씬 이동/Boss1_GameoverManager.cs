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
        if (GameObject.Find("SavePoint_1_5") != null)
        {
            GameObject.Find("player").transform.position = GameObject.Find("SavePoint_1_5").transform.position;
            Destroy(this.gameObject);
        }
    }

    void GameOver()
    {

        isMoved = true;

        SceneManager.LoadScene("1Stage_Map");
    }
}
