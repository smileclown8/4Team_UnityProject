using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern5_BulletController : MonoBehaviour
{


    private AudioManager theAudio;
    public string Pattern5Generate;

    private void Awake()
    {

        theAudio = FindObjectOfType<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        theAudio.Play(Pattern5Generate);

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

        if( GameObject.Find("Boss_Clea_Doll(Clone)") != null)
        {
            if (GameObject.Find("Boss_Clea_Doll(Clone)").GetComponent<Boss_Clea_Doll>().Pattern5BulletCanMove)
                transform.Translate(transform.right * 30 * Time.deltaTime);
        }


        if(GameObject.Find("Boss_Clea_Doll") == null && GameObject.Find("Boss_Clea_Doll(Clone)") == null)
        {
            DestroyBullet();
        }
    }

    void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
}
