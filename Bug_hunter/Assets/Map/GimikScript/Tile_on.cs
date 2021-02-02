using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_on : MonoBehaviour
{
    public Renderer tileColor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    // Trigger 타입의 콜라이더와 충돌이 발생하면 충돌이 발생한 오브젝트의
    // Collider 정보가 넘어온다.
    // Trigger 를 사용할 때는 Collider 타입으로 매개변수를 받음
    {

        if (collision.gameObject.tag == "Player")
        {
            tileColor.material.color = new Color(1f, 1f, 1f, 1f);
        }

    }
}
