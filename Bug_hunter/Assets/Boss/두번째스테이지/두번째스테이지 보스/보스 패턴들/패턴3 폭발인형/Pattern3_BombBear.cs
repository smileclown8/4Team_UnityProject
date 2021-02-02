using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern3_BombBear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Invoke("Explose", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject Explosion;

    void Explose()
    {
        GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f, 0f);
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Invoke("Destroy", 0.1f);
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
