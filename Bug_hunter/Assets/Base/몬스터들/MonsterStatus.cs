using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStatus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public float Monster_HP;
    public float Boss_IF_MaxHP;

    GameObject Player;
    GameObject PlayerStatusManager;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
          //  Boss_IF_HP -= collision.gameObject.GetComponent<BulletDamage>().damage;
        }
    }

}
