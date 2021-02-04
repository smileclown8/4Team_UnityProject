using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    // 0203 몬스터 HP
    public float MonsterHP;
    // 해당 아이템 프리팹 적용
    public GameObject buff;
    // 오브젝트의 투사체 프리팹 적용
    public GameObject bullet;

    // 일정 시간에 도달시 GhostShoot() 발동
    float time = 0;
    void Update()
    {
        time += Time.deltaTime;
        if (time > 2)
        {
            time = 0;
            GhostShoot();
        }
    }

    // 몬스터의 투사체 발사
    public void GhostShoot()
    {
        Instantiate(bullet, transform.position + Vector3.right * 2, transform.rotation);
    }

    // 0203 몬스터 피격
    // BulletDamage를 불러와서 데미지를 가한다
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            MonsterHP -= collision.gameObject.GetComponent<BulletDamage>().damage;

            if (MonsterHP <= 0)
            {
                Drop();
            }
        }
    }

    // 0203 아이템 드랍
    public void Drop()
    {
        // 아이템 생성
        Instantiate(buff, transform.position + Vector3.up * 3, transform.rotation);

        // 몬스터 삭제
        Destroy(gameObject);
    }
}
