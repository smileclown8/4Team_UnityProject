using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern1_BulletController : MonoBehaviour
{
    public GameObject Center;
    Vector3 Dir;
    float angle;

    // Start is called before the first frame update
    void Start()
    {
        Center = GameObject.Find("Pattern1_Center");
        Dir = (this.transform.position - Center.transform.position).normalized;
        angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle + 90f, Vector3.forward);
        Invoke("DestroyBullet", 30f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Boss_Clea_Doll").GetComponent<Boss_Clea_Doll>().Pattern1BulletCanMove)
        {
            this.transform.position += Dir * 5f * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            DestroyBullet();
        }
    }

    void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
}
