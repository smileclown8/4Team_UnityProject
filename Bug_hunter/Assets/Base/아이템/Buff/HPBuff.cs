using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBuff : MonoBehaviour
{
    private GameObject playerStatus;
    public int HPup;

    private void Awake()
    {
        playerStatus = GameObject.Find("PlayerStatusManager");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 플레이어가 아이템을 획득
        if (collision.gameObject.tag == "Player")
        {
            HPUP();
            if (playerStatus.GetComponent<PlayerStatusManager>().player_HP >= 100)
            {
                playerStatus.GetComponent<PlayerStatusManager>().player_HP = 100;
                Debug.Log("HP " + playerStatus.GetComponent<PlayerStatusManager>().player_HP);
            }
            Destroy(this.gameObject);
        }
    }
    void HPUP()
    {
        if (playerStatus.GetComponent<PlayerStatusManager>().player_HP <= 100)
        {
            playerStatus.GetComponent<PlayerStatusManager>().player_HP += HPup;
        }
    }
}
