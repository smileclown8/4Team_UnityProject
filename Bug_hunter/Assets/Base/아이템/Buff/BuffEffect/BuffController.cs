using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffController : MonoBehaviour
{
    // 버프 이펙트 넣는곳
	public GameObject Buff;

    private void Awake()
    {
        // 플레이어의 포지션값을 불러온다
        playerPos = GameObject.Find("player");

    }

    // 플레이어 포지션값
    public GameObject playerPos;

    private void OnTriggerEnter2D(Collider2D collision)
	{
        // 스크립트 부르기
        this.GetComponent<ItemManager>();
        this.GetComponent<PlayerStatusManager>();

        // Item 오브젝트 Tag를 Item으로 바꿔준다
        if (collision.gameObject.tag == "Item")
        {
            // 생성한다 버프 오브젝트를 플레이어에게
            // 빙글빙글빙글빙글
            Instantiate(Buff, transform.position, Quaternion.identity);
            Debug.Log("버프 획득");
        }
    }


}
