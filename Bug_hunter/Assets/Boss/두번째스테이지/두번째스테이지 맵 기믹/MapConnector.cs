using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapConnector : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject Up;
    public GameObject Down;
    public GameObject Right;
    public GameObject Left;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (this.gameObject.name)
            {
                case "Up":
                    collision.gameObject.transform.position = new Vector2(collision.gameObject.transform.position.x,
                        Down.transform.position.y + 4);

                    break;


                case "Down":
                    collision.gameObject.transform.position = new Vector2(collision.gameObject.transform.position.x,
    Up.transform.position.y - 4);

                    break;


                case "Right":
                    collision.gameObject.transform.position = new Vector2(Left.transform.position.x + 4, collision.gameObject.transform.position.y);


                    break;

                case "Left":
                    collision.gameObject.transform.position = new Vector2(Right.transform.position.x - 4, collision.gameObject.transform.position.y);

                    break;
            }
        }
    }
}
