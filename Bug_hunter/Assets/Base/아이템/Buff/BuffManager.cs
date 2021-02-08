using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    private GameObject playerStatus;
    private GameObject AttackDamage;


    // 밸런스 능력치 입력 해주세요
    public int speedup;
    public int HPup;
    public int jumpUP;
    public int AttDamage;


    private void Awake()
    {
        playerStatus = GameObject.Find("PlayerStatusManager");
        AttackDamage = GameObject.Find("DamageManager");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 플레이어가 아이템을 획득
        if (collision.gameObject.tag == "Player")
        {
            // int random = Random.Range(1, 4);
            int random = 0;

            if (random == 0)
            {
                AttUP();
                Debug.Log("공격력 " + AttackDamage.GetComponent<BulletDamage>().damage);
            }
            if (random == 1)
            {
                if (playerStatus.GetComponent<PlayerStatusManager>().moveSpeed >= 90)
                {
                    random = Random.Range(2,4);
                }
                SpeedUP();
                Debug.Log("이동 속도 " + playerStatus.GetComponent<PlayerStatusManager>().moveSpeed);

            }

            if (random == 2)
            {
                HPUP();
                if (playerStatus.GetComponent<PlayerStatusManager>().player_HP >= 100)
                {
                    playerStatus.GetComponent<PlayerStatusManager>().player_HP = 100;
                    Debug.Log("HP " + playerStatus.GetComponent<PlayerStatusManager>().player_HP);
                }
            }

            if (random == 3)
            {
                if (playerStatus.GetComponent<PlayerStatusManager>().jumpPower >= 60)
                {
                    random = Random.Range(1, 3);
                }
                JumpUP();
                Debug.Log("점프 " + playerStatus.GetComponent<PlayerStatusManager>().jumpPower);
            }
            Destroy(this.gameObject);
        }
    }

    void SpeedUP()
    {
        if (playerStatus.GetComponent<PlayerStatusManager>().moveSpeed < 90)
        {
            playerStatus.GetComponent<PlayerStatusManager>().moveSpeed += speedup;
        }

    }

    void HPUP()
    {
        if (playerStatus.GetComponent<PlayerStatusManager>().player_HP <= 100)
        {
            playerStatus.GetComponent<PlayerStatusManager>().player_HP += HPup;
        }
    }

    void JumpUP()
    {
        if (playerStatus.GetComponent<PlayerStatusManager>().jumpPower < 60)
        {
            playerStatus.GetComponent<PlayerStatusManager>().jumpPower += jumpUP;
        }
    }

    void AttUP()
    {
        AttackDamage.GetComponent<BulletDamage>().damage += AttDamage;


    }
}