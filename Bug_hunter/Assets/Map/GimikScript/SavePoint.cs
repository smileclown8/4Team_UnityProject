using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{

    public GameObject PlayerStatusManager;
    // Start is called before the first frame update
    void Start()
    {
        ChildFlag = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerStatusManager = GameObject.Find("PlayerStatusManager");
    }

    GameObject ChildFlag;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
         
            if(GameObject.Find("PlayerStatusManager") != null)
            {
                GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().PlayerRespawn_Pos
                    = this.transform.position;
            }

            this.GetComponent<SpriteRenderer>().color
                = new Color(0, 0, 0, 0);

            ChildFlag.GetComponent<SpriteRenderer>().color =
               new Color(1, 1, 1, 1);
        }

    }
}
