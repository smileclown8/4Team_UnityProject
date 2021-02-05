using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetection : MonoBehaviour
{

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            if (GameObject.Find("PlayerStatusManager") != null)
            {

                collision.gameObject.transform.position
                = GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().PlayerRespawn_Pos;
                Debug.Log("플레이어 추락, hp 20감소");
                GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().player_HP
                    -= 20f;
                Debug.Log(GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().player_HP);
            }
        }
    }
}
