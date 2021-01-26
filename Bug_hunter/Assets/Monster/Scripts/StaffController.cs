using UnityEngine;
using System.Collections;

public class StaffController : MonoBehaviour
{
	public GameObject Explosion;

    private void Awake()
    {
    }
    // Update is called once per frame
    void Update()
	{

	}


	private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.tag == "Player")
		{
			GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f, 0f);
			Instantiate(Explosion, transform.position, Quaternion.identity);
			//데미지 공식 추가 필요
			Destroy(gameObject);
			// Explosion 프리팹의 리지드 바디 2D 머테리얼에 Staff 바운스(설정 3)을 집어넣어준다
			// 박스 콜라이더2D도 집어넣는다.
		}
	}
}