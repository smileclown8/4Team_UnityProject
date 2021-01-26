using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject playerCamera;
    Transform playerCameraPos;


    void Awake()
    {

        playerCamera = GameObject.Find("playerCameraPos");
    }
    void Start()
    {
        playerCameraPos = playerCamera.transform;
    }
    void Update()
    {
        if (GameObject.Find("CameraEventManager").GetComponent<CameraEventManager>().isEvent != true)
        {
            this.GetComponent<Camera>().orthographicSize = 10f;
            transform.position = Vector2.Lerp(transform.position, playerCameraPos.position, 2f * Time.deltaTime);
            transform.Translate(0, 0, -10); //카메라를 원래 z축으로 이동
        }
        else if (GameObject.Find("CameraEventManager").GetComponent<CameraEventManager>().isEvent == true)
        {
            this.GetComponent<Camera>().orthographicSize = 3f;
            this.transform.position = new Vector2(GameObject.Find("player").transform.position.x, GameObject.Find("player").transform.position.y);
            transform.Translate(0, 0, -10); //카메라를 원래 z축으로 이동

        }

    }
}
