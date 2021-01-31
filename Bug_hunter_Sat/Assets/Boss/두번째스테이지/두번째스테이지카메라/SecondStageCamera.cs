using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondStageCamera : MonoBehaviour{

    public GameObject playerCamera;
    Transform playerCameraPos;


    private void Awake()
    {
        playerCamera = GameObject.Find("playerCameraPos");
        playerCameraPos = playerCamera.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    public float CamerMaxLimit;
    public float cameraEnlargementSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        /*
        if (this.GetComponent<Camera>().orthographicSize <= 15f)
            this.GetComponent<Camera>().orthographicSize += cameraEnlargementSpeed * Time.deltaTime;
        */

        transform.position = Vector2.Lerp(transform.position, playerCameraPos.position, 50f * Time.deltaTime);
        transform.Translate(0, 0, -10); //카메라를 원래 z축으로 이동
    }

}
