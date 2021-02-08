using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    private GameObject playerStatus;

    // 밸런스 능력치 입력 해주세요
    public int speedup;
    public int HPup;
    public int jumpUP;

    private void Awake()
    {
        playerStatus = GameObject.Find("PlayerStatusManager");

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 플레이어가 아이템을 획득
        if (collision.gameObject.tag == "Player")
        {

                int random = Random.Range(1, 4);

                if (random == 1)
                {
                    SpeedUP();
                }
                if (random == 2)
                {
                    HPUP();
                }
                if (random == 3)
                {
                    JumpUP();
                }
                Destroy(this.gameObject);
        }
    }

    void SpeedUP()
    {
        playerStatus.GetComponent<PlayerStatusManager>().moveSpeed += speedup;
        Debug.Log("이동 속도 " + playerStatus.GetComponent<PlayerStatusManager>().moveSpeed);
    }

    void HPUP()
    {
        if (playerStatus.GetComponent<PlayerStatusManager>().player_HP <= 100)
        {
            playerStatus.GetComponent<PlayerStatusManager>().player_HP += HPup;
        }
        else if (playerStatus.GetComponent<PlayerStatusManager>().player_HP >= 100)
        {
            playerStatus.GetComponent<PlayerStatusManager>().player_HP = 100;
        }
        Debug.Log("HP " + playerStatus.GetComponent<PlayerStatusManager>().player_HP);
    }

    void JumpUP()
    {
        playerStatus.GetComponent<PlayerStatusManager>().jumpPower += jumpUP;
        Debug.Log("점프 " + playerStatus.GetComponent<PlayerStatusManager>().jumpPower);
    }
}
// ㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋ