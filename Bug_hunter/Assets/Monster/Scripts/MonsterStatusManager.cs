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
    float playerBulletDamage;

    [SerializeField] public GameObject buff;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // 플레이어 총알에 닿으면 HP 깎임
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            playerBulletDamage = GameObject.FindWithTag("PlayerBullet").GetComponent<BulletDamage>().damage;
            Debug.Log("내 피 " + hp);
            Debug.Log("내 방어 " + def);
            Debug.Log("데미지 " + playerBulletDamage);

            int ran = Random.Range(1, 101);                             // 회피 계산
            Debug.Log("회피율 " + dod);
            Debug.Log("회피수치" + ran);

            if (ran > dod)                                              // 회피율보다 크면 회피 실패
            {
                // 회피 : 플레이어 공격력 - 몬스터 방어력이 0 이상이면 데미지가 들어오고, 이하이면 몬스터hp가 0이 된다.
                if (def - playerBulletDamage < hp)
                {
                    hp -= playerBulletDamage;
                    Debug.Log("회피실패");
                    Debug.Log("남은 피 " + hp);
                }
                else if (def - playerBulletDamage >= hp)
                {
                    Debug.Log("회피성공");
                    hp = 0;
                }
                spriteRenderer.color = new Color(1, 1, 1, 0.4f);        // 맞으면 반투명해짐
                Invoke("ColorBack", 0.1f);
            }
            else if (ran <= dod)                                        // 회피율보다 작으면 회피 성공
            {
                Debug.Log("Miss!");
            }
        }
    }

    void ColorBack()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1);               // 색을 되돌리기 위한 것
    }



    void FixedUpdate()
    {
        if (hp <= 0)
        {
            Debug.Log("몬스터 사망");
            
            int random = Random.Range(0, 101);
            
            if (random <= buffRate)                                                             // 버프 확률보다 적으면 버프 얻는다.
            {
                Instantiate(buff, transform.position + Vector3.up * 3, transform.rotation);     // 버프템 드랍 (템은 아웃렛 연결)
            }
            // 74줄에서 문제가 생기면 : 해당 몬스터의 인스펙터에서 buff에 버프템을 아웃렛 연결해줄 것!
            Destroy(gameObject, 0.5f);      // 0.5초 뒤에 삭제. 부모 오브젝트 삭제 시간 계산을 위해 필요함.
        }
    }

}
