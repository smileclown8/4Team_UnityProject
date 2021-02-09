using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.name == "Bullet(Clone)")
        {
            damage = GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().damage * 1.0f;
            Debug.Log(GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().damage);
        }
        if (this.gameObject.name == "SecondSkillBullet(Clone)")
        {
            damage = GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().damage * 1.5f;
        }
        if (this.gameObject.name == "arrow(Clone)")
        {
            damage = GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().damage * 1.2f;
        }
        if (this.gameObject.name == "Bomb(Clone)")
        {
            damage = GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().damage * 1.5f;
        }
        if (this.gameObject.name == "Electro(Clone)")
        {
            damage = GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().damage * 1.7f;
        }
        if (this.gameObject.name == "Fire(Clone)")
        {
            damage = GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().damage * 1.8f;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
