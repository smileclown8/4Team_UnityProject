using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBulletPool : MonoBehaviour
{
    public static NPCBulletPool bullePoolInstanse;

    public GameObject Bullet;
    bool notEnoughBulletsInPool = true;

    List<GameObject> bullets;


    private void Awake()
    {
        bullePoolInstanse = this;
    }

    void Start()
    {
        bullets = new List<GameObject>();
    }

    public GameObject GetBullet()
    {
        if (bullets.Count > 0)
        {
            for(int i=0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                    return bullets[i];
            }
        }

        if (notEnoughBulletsInPool)
        {
            GameObject bul = Instantiate(Bullet);
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }

        return null;
    }

}
