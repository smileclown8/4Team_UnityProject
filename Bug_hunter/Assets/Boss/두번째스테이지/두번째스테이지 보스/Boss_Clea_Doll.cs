using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Clea_Doll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //=======================================
        //플레이어 찾기
        Player = GameObject.Find("player");
        PlayerStatusManager = GameObject.Find("PlayerStatusManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // =======================================================================
    // 보스 체력, 공격력 관리

    public float Boss_Clea_Doll_HP;
    public float Boss_Clea_Doll_MaxHP;

    public float Boss_Clea_Doll_Grogy_HP;
    public float Boss_Clea_Doll_Grogy_MaxHP;

    GameObject Player;
    GameObject PlayerStatusManager;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Boss_Clea_Doll_Grogy_HP -= collision.gameObject.GetComponent<BulletDamage>().damage;
        }
    }


}
