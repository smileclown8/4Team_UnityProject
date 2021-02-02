using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern2_BulletController : MonoBehaviour
{
    public GameObject Target;
    Vector3 trackingDir;
    float angle;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {

      Invoke("ShootStart", 12);
      Invoke("DestroyBullet", 17);
    }

    // Update is called once per frame
    void Update()
    {

          if(isShootReady == false)
        {
           Target = GameObject.Find("player");
           trackingDir = (Target.transform.position - this.transform.position).normalized;
            angle = Mathf.Atan2(trackingDir.y, trackingDir.x) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.AngleAxis(angle + 90f, Vector3.forward);
        }

         if (isShootReady == true)
        {
            this.transform.position += trackingDir * speed * Time.deltaTime;
        }

        if (GameObject.Find("Boss_Clea_Doll") == null && GameObject.Find("Boss_Clea_Doll(Clone)") == null)
        {
            DestroyBullet();
        }
    }


    public bool isShootReady = false;
    void ShootStart()
    {
        isShootReady = true;
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DestroyBullet();
        }
    }





    void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
}
