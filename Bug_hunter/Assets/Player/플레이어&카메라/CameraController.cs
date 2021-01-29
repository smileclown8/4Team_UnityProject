using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject playerCamera;
    Transform playerCameraPos;


    public GameObject Stage_1_CameraPos1;
    public GameObject Stage_1_CameraPos2;


    public float leftEnd;
    public float rightEnd;
    public float downEnd;
    public float upEnd;


    void Awake()
    {
        playerCamera = GameObject.Find("playerCameraPos");
        Stage_1_CameraPos1 = GameObject.Find("Left_DOWN");
        Stage_1_CameraPos2 = GameObject.Find("Right_UP");

    }
    void Start()
    {
        if (Stage_1_CameraPos1 != null)
        {
            leftEnd = Stage_1_CameraPos1.transform.position.x;
            downEnd = Stage_1_CameraPos1.transform.position.y;
        }

        if (Stage_1_CameraPos2 != null)
        {
            upEnd = Stage_1_CameraPos2.transform.position.y;
            rightEnd = Stage_1_CameraPos2.transform.position.x;
        }
        playerCameraPos = playerCamera.transform;
    }
    void Update()
    {
        if (GameObject.Find("CameraEventManager").GetComponent<CameraEventManager>().isEvent != true)
        {
            this.GetComponent<Camera>().orthographicSize = 10f;
            transform.position = Vector2.Lerp(transform.position, playerCameraPos.position, 10f * Time.deltaTime);
            transform.Translate(0, 0, -10); //카메라를 원래 z축으로 이동
        }
        else if (GameObject.Find("CameraEventManager").GetComponent<CameraEventManager>().isEvent == true)
        {
            this.GetComponent<Camera>().orthographicSize = 3f;
            this.transform.position = new Vector2(GameObject.Find("player").transform.position.x, GameObject.Find("player").transform.position.y);
            transform.Translate(0, 0, -10); //카메라를 원래 z축으로 이동

        }




        if (transform.position.x <= leftEnd)
        {
            transform.position = new Vector2(leftEnd, transform.position.y);
        }

        if (transform.position.x >= rightEnd)
        {
            transform.position = new Vector2(rightEnd, transform.position.y);
        }

        if (transform.position.y >= upEnd)
        {
            transform.position = new Vector2(transform.position.x, upEnd);
        }

        if (transform.position.y <= downEnd)
        {
            transform.position = new Vector2(transform.position.x, downEnd);
        }
        transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -10);

    }
}
