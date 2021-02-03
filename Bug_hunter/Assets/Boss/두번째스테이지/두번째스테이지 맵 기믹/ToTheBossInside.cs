using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToTheBossInside : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        portalPos = GameObject.Find("PortalPos").transform;
    }

    public Transform portalPos;
    public bool isPlayerInBossInside = false;

    public GameObject LimitTimeNoticeText;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.Find("GrogyNoticeText").SetActive(false);
            isPlayerInBossInside = true;
            LimitTimeNoticeText.SetActive(true);
            collision.gameObject.transform.position = portalPos.position;
        }
    }

}
