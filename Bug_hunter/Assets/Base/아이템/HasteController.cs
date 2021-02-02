using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasteController : MonoBehaviour
{
    private GameObject playerStatus;

    private void Awake()
    {
        playerStatus = GameObject.Find("PlayerStatusManager");
    }

    public int speedup;

    void OnTriggerEnter2D(Collider2D collision)
    {

        // 플레이어가 아이템을 획득
        if (collision.gameObject.tag == "Player")
        {
            Haste();
        }

    }

    void Haste()
    {
        // 플레이어 스테이터스에 speed값을 불러와 증가시킴
        playerStatus.GetComponent<PlayerStatusManager>().moveSpeed += speedup;
        Debug.Log("현재 능력치" + playerStatus.GetComponent<PlayerStatusManager>().moveSpeed);

        // 5초 뒤 HasteOff()
        Invoke("HasteOff", 5.0f);

        // 오브젝트 숨김
        this.gameObject.SetActive(false);

    }

    void HasteOff()
    {
        // 증가한 값 만큼 다시 빼줌
        playerStatus.GetComponent<PlayerStatusManager>().moveSpeed -= speedup;
        Debug.Log("현재 능력치" + playerStatus.GetComponent<PlayerStatusManager>().moveSpeed);

        // 오브젝트 삭제
        Destroy(this.gameObject);

    }
}

// 중복획득 방지하기

// bool 값으로 if문에 적용해봤지만 실패
// int 값으로 해봐도 안됨
// 함수 안에 걸어봐도 안됨
// OnTriggerEnter2D에 걸어봐도 안됨
// 뭘 해도 안됨
// 쉬는시간 갈아도 안됨
// 그냥 안됨

// 안되는거 같으니까 기획서를 수정하자
