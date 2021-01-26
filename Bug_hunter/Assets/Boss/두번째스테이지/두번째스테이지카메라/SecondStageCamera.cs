using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondStageCamera : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }


    public float CamerMaxLimit;
    public float cameraEnlargementSpeed = 10f;
    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<Camera>().orthographicSize <= 15f)
            this.GetComponent<Camera>().orthographicSize += cameraEnlargementSpeed * Time.deltaTime;
    }

}
