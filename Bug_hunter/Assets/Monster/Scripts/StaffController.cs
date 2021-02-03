using UnityEngine;
using System.Collections;

public class StaffController : MonoBehaviour
{
	public GameObject Explosion;
	GameObject player;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.tag == "Player")
		{
			GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f, 0f);
			Instantiate(Explosion, transform.position, Quaternion.identity);
			player.GetComponent<PlayerStatusManager>().player_HP -= GetComponent<MonsterStatusManager>().attack;
			// ********** 플레이어 방어력 변수 추가되면 여기에 뭔가 해야함
			Destroy(gameObject);

			// Explosion 프리팹의 리지드 바디 2D 머테리얼에 Staff 바운스(설정 3)을 집어넣어준다
			// 박스 콜라이더2D도 집어넣는다.
		}
	}
}