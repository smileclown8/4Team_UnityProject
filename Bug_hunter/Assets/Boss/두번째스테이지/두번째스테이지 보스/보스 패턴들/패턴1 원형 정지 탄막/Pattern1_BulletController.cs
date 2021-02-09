using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern1_BulletController : MonoBehaviour
{
    public GameObject Center;
    Vector3 Dir;
    float angle;



    private AudioManager theAudio;
    public string Pattern1Generate;

    private void Awake()
    {
        
        theAudio = FindObjectOfType<AudioManager>();
    }


    // Start is called before the first frame update
    void Start()
    {
        theAudio.Play(Pattern1Generate);
        Center = GameObject.Find("Pattern1_Center");
        Dir = (this.transform.position - Center.transform.position).normalized;
        angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle + 90f, Vector3.forward);
        Invoke("DestroyBullet", 15f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Boss_Clea_Doll") != null)
        {
            if (GameObject.Find("Boss_Clea_Doll").GetComponent<Boss_Clea_Doll>().Pattern1BulletCanMove)
            {
                this.transform.position += Dir * 5f * Time.deltaTime;
            }
        }

        else if (GameObject.Find("Boss_Clea_Doll(Clone)") != null){
            if (GameObject.Find("Boss_Clea_Doll(Clone)").GetComponent<Boss_Clea_Doll>().Pattern1BulletCanMove)
            {
                this.transform.position += Dir * 5f * Time.deltaTime;
            }
        }


        if (GameObject.Find("Boss_Clea_Doll") == null && GameObject.Find("Boss_Clea_Doll(Clone)") == null)
        {
            DestroyBullet();
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
