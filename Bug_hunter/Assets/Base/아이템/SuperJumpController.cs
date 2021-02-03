using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJumpController : MonoBehaviour
{
    private GameObject playerStatus;

    public int JumpUP = 50;

    private void Awake()
    {
        playerStatus = GameObject.Find("PlayerStatusManager");

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 플레이어가 아이템을 획득
        if (collision.gameObject.tag == "Player")
        {
            Jump();

        }
    }

    void Jump()
    {
        playerStatus.GetComponent<PlayerStatusManager>().jumpPower += JumpUP;
        Debug.Log("Jump " + playerStatus.GetComponent<PlayerStatusManager>().jumpPower);

        // 5초 뒤
        Invoke("JumpOff", 5.0f);

        // 오브젝트 끔
        this.gameObject.SetActive(false);
    }

    void JumpOff()
    {
        playerStatus.GetComponent<PlayerStatusManager>().jumpPower -= JumpUP;
        Debug.Log("Jump " + playerStatus.GetComponent<PlayerStatusManager>().jumpPower);

        // 오브젝트 지움
        Destroy(this.gameObject);

    }
}
