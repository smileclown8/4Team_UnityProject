using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private GameObject playerStatus;
    int item_Skill_ID;


    private void Awake()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        playerStatus = GameObject.Find("PlayerStatusManager");
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    public float turnSpeed = 30f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        int random = Random.Range(0, 6);
        if (collision.gameObject.tag == "Player")
        {

            if (random == 1)
            {
                playerStatus.GetComponent<PlayerStatusManager>().skill_ID = item_Skill_ID = 1;

            }
            if (random == 2)
            {
                playerStatus.GetComponent<PlayerStatusManager>().skill_ID = item_Skill_ID = 2;

            }
            if (random == 3)
            {
                playerStatus.GetComponent<PlayerStatusManager>().skill_ID = item_Skill_ID = 3;

            }
            if (random == 4)
            {
                playerStatus.GetComponent<PlayerStatusManager>().skill_ID = item_Skill_ID = 4;

            }
            if (random == 5)
            {
                playerStatus.GetComponent<PlayerStatusManager>().skill_ID = item_Skill_ID = 5;

            }
            if (random == 6)
            {
                playerStatus.GetComponent<PlayerStatusManager>().skill_ID = item_Skill_ID = 6;

            }
            Debug.Log(item_Skill_ID + "번 스킬 아이템 획득");
            Destroy(this.gameObject);
        }
    }
}
