using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetection : MonoBehaviour
{
    public Transform PlayerRespawn_1_1;



    void Awake()
    {
        PlayerRespawn_1_1 = GameObject.Find("PlayerRespawn_1_1").transform;
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
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position
                = new Vector2(PlayerRespawn_1_1.position.x, PlayerRespawn_1_1.position.y);
        }
    }
}
