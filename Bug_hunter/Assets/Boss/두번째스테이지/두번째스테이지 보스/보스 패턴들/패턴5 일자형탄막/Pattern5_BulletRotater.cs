using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern5_BulletRotater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        rotSpeed = 120f;
    }
    public float rotSpeed;
    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.forward, rotSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
