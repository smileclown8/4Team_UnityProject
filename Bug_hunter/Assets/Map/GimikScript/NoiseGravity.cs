using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseGravity : MonoBehaviour
{
    public GameObject targetObject;
    GameObject player;
    Rigidbody2D rb;
    public float gravity;

    // Start is called before the first frame update

    private void Awake()
    {
        player = GameObject.Find("player");
        rb = player.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        StartCoroutine(Nosing());
    }
    IEnumerator Nosing()
    {
        while (true)
        {
            OnEnableSettingEnvent();
            yield return new WaitForSeconds(3);//WaitForSeconds객체를 생성해서 반환


        }
    }
    public void OnEnableSettingEnvent()
    {
        if (targetObject.activeInHierarchy)
        {
            targetObject.SetActive(false);
            rb.gravityScale = gravity;
        }
        else
            targetObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            targetObject.SetActive(false);
            rb.gravityScale = gravity;
            this.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
