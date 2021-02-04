using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBulletManager : MonoBehaviour
{
    int damage;

    Vector2 moveDirection;
    [SerializeField] float speed = 4;

    private void OnEnable()
    {
        Invoke("Destroy", 2);
    }

    void Start()
    {
        damage = GameObject.Find("NPCmon").GetComponent<MonsterStatusManager>().attack;
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }




    // 플레이어에 닿으면 데미지를 주고 파괴
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject.Find("PlayerStatusManager").GetComponentInChildren<PlayerStatusManager>().player_HP -= damage;
            Debug.Log("동화 속 요정의 공격! 데미지 " + damage);
        }
    }

}
