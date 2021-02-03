using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStatusManager : MonoBehaviour
{
    public float hp;            // 체력
    public int attack;          // 공격력
    public int def;             // 방어력
    public int dod;             // 회피율
    public int buffRate;        // 버프획득확률

    SpriteRenderer spriteRenderer;
    new Collider2D collider;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // 플레이어 총알에 닿으면 HP 깎임
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            int Ran = Random.Range(1, 101);                             // 회피 계산

            if (Ran > dod)                                              // 회피율보다 크면 회피 실패
            {
                // 회피 실패 : 플레이어 공격력 - 몬스터 방어력이 0 이상이면 데미지가 들어오고, 이하이면 몬스터hp가 0이 된다.
                if (collision.gameObject.GetComponent<BulletDamage>().damage - def > 0)
                {
                    hp -= collision.gameObject.GetComponent<BulletDamage>().damage;
                }
                else
                {
                    hp = 0;
                }
                spriteRenderer.color = new Color(1, 1, 1, 0.4f);        // 맞으면 반투명해짐
                Invoke("ColorBack", 0.1f);
            }
            else if (Ran <= dod)                                        // 회피율보다 작으면 회피 성공
            {
                Debug.Log("Miss!");
            }
        }
    }

    void ColorBack()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1);               // 색을 되돌리기 위한 것
    }



    void Update()
    {
        if (hp <= 0)
        {
            Debug.Log("으악 죽었다");
            collider.enabled = false;           // 충돌 끄기
            Destroy(gameObject, 1.5f);
        }
    }

}
