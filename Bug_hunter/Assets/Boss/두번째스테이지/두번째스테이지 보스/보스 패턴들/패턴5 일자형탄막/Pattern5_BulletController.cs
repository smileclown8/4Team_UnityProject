using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern5_BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


        Invoke("DestroyBullet", 10f);
    }


    // Update is called once per frame
    void Update()
    {


        if (GameObject.Find("Boss_Clea_Doll") != null)
        {
            if (GameObject.Find("Boss_Clea_Doll").GetComponent<Boss_Clea_Doll>().Pattern5BulletCanMove)
                transform.Translate(transform.right * 30 * Time.deltaTime);
        }

        if(GameObject.Find("Boss_Clea_Doll") == null)
        {
            DestroyBullet();
        }
    }

    void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
}
