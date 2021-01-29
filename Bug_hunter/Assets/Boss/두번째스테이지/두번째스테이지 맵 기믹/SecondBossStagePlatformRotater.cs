using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBossStagePlatformRotater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float rotSpeed;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.forward, rotSpeed * Time.deltaTime);
    }
}