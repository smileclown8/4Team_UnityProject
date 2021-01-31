using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyController : MonoBehaviour
{
    public float destroySeconds;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroySeconds);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
