using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatBulletManager : MonoBehaviour
{
    int damage;
    public float speed;
    Rigidbody2D rb;

    GameObject target;
    Vector2 moveDirection;

    // 오디오용
    public AudioClip attack;
    AudioSource audioSource;



    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.2f;
        audioSource.clip = attack;
        audioSource.Play();

        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");
        damage = GameObject.Find("Bat").GetComponent<MonsterStatusManager>().attack;

        moveDirection = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);

        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject.Find("PlayerStatusManager").GetComponentInChildren<PlayerStatusManager>().player_HP -= damage;
            Debug.Log("Hit!");
            Destroy(gameObject);
        }
    }

}
