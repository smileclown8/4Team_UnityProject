using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_on : MonoBehaviour
{
    GameObject tilemap2_0_1;
    Renderer tileColor2_0_1;
    GameObject tilemap2_1_1;
    Renderer tileColor2_1_1;
    // Start is called before the first frame update
    void Start()
    {
        tilemap2_0_1 = GameObject.Find("Tilemap2_0_1");
        tilemap2_1_1 = GameObject.Find("Tilemap2_1_1");
        if (tilemap2_0_1 != null)
        {
            tileColor2_0_1 = tilemap2_0_1.GetComponent<Renderer>();
        }
        if (tilemap2_1_1 != null)
        {
            tileColor2_1_1 = tilemap2_1_1.GetComponent<Renderer>();
        }
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
            tileColor2_0_1.material.color = new Color(1f, 1f, 1f, 1f);
            tileColor2_1_1.material.color = new Color(1f, 1f, 1f, 1f);
        }

    }
}
