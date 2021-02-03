using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetection : MonoBehaviour
{
    public Transform PlayerRespawn_1_1;
    public Transform SavePoint_2;
    public Transform SavePoint_3;
    public Transform SavePoint_4;


    void Awake()
    {
        PlayerRespawn_1_1 = GameObject.Find("PlayerRespawn_1_1").transform;
        SavePoint_2 = GameObject.Find("1_2SavePoint_Off").transform;
        SavePoint_3 = GameObject.Find("1_3SavePoint_Off").transform;
        SavePoint_4 = GameObject.Find("1_4SavePoint_Off").transform;
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
            if (SavePoint_2.GetComponent<SavePoint>().here == 1 && SavePoint_3.GetComponent<SavePoint>().here == 1 && SavePoint_4.GetComponent<SavePoint>().here == 1)
            {
                collision.gameObject.transform.position
               = new Vector2(SavePoint_4.position.x, SavePoint_4.position.y);
            }
            else if (SavePoint_2.GetComponent<SavePoint>().here == 1 && SavePoint_3.GetComponent<SavePoint>().here == 1)
            {
                collision.gameObject.transform.position
                = new Vector2(SavePoint_3.position.x, SavePoint_3.position.y);
            }
            else if(SavePoint_2.GetComponent<SavePoint>().here == 1)
            {
                collision.gameObject.transform.position
                = new Vector2(SavePoint_2.position.x, SavePoint_2.position.y);
            }
            else
                collision.gameObject.transform.position
                = new Vector2(PlayerRespawn_1_1.position.x, PlayerRespawn_1_1.position.y);
        }
    }
}
