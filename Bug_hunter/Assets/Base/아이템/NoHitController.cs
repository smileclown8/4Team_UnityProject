using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoHitController : MonoBehaviour
{
    public GameObject player;


    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 플레이어가 아이템을 획득
        if (collision.gameObject.tag == "Player")
        {
            HitOff();

        }
    }

    void HitOff()
    {
        // 플레이어 레이어를 바꾼다
        player.gameObject.layer = 10;
        // 플레이어가 공격받지 않음
        Debug.Log("회피 100");

        Invoke("HitOn", 5.0f);

        // 아이템 오브젝트 숨김
        this.gameObject.SetActive(false);
    }

    void HitOn()
    {
        // 플레이어 레이어를 돌려준다
        player.gameObject.layer = 9;
        Debug.Log("회피 0");
        // 아이템 오브젝트 삭제
        Destroy(this.gameObject);
    }

}
