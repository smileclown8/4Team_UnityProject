using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern4_BigBombDoll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DesPos = GameObject.Find("Pattern4_DesPos");
        BigBombDoll_HP = 30;
        BossReturn = false;

        Invoke("Explose", 8f);

    }

    public GameObject DesPos;

    // Update is called once per frame
    void Update()
    {
        MoveToDesPos();
        DestroyByAttack();
    }

    public float BigBombDoll_HP;

    public GameObject Explosion;

    public bool BossReturn;


     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            BigBombDoll_HP -= collision.gameObject.GetComponent<BulletDamage>().damage;
            Destroy(collision.gameObject);
        }
    }


    void MoveToDesPos()
    {
        transform.position = Vector2.MoveTowards(transform.position,DesPos.transform.position, Time.deltaTime * 50f);
    }

    void Explose()
    {
        GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f, 0f);
        Instantiate(Explosion, transform.position, Quaternion.identity);
        BossReturn = true;
        Invoke("Destroy", 0.1f);
    }

    void DestroyByAttack()
    {
        if(BigBombDoll_HP <= 0)
        {
            CancelInvoke("Explose");
            BossReturn = true;
            Invoke("Destroy", 0.1f);
        }
    }


    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
