using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_IF_CameraController : MonoBehaviour
{
    public GameObject playerCamera;


    public GameObject boss_IF_CamerPos1;
    public GameObject boss_IF_CamerPos2;

    Transform playerCameraPos;


    public float leftEnd;
    public float rightEnd;
    public float downEnd;
    public float upEnd;


    public bool isNeedZoomIN = false;
    private float minCameraSize;

    void Awake()
    {
        playerCamera = GameObject.Find("playerCameraPos");

        leftEnd = boss_IF_CamerPos1.transform.position.x;
        upEnd = boss_IF_CamerPos1.transform.position.y;

        rightEnd = boss_IF_CamerPos2.transform.position.x;
        downEnd = boss_IF_CamerPos2.transform.position.y;
    }
    void Start()
    {
        playerCameraPos = playerCamera.transform;
    }
    void Update()
    {
        if (GameObject.Find("CORE_STAGESTART") != null)
        {
            minCameraSize = GameObject.Find("CORE_STAGESTART").GetComponent<CoreRotater>().CameraSize;
            this.GetComponent<Camera>().orthographicSize = minCameraSize;

        }
        else
        {
            this.GetComponent<Camera>().orthographicSize = 10f;
        }

        if (GameObject.Find("CameraEventManager").GetComponent<CameraEventManager>().isEvent != true)
        {
            transform.position = Vector2.Lerp(transform.position, playerCameraPos.position, 2f * Time.deltaTime);
        }

        else
        {
            this.transform.position = new Vector2(GameObject.Find("CORE_STAGESTART_POS").transform.position.x, GameObject.Find("CORE_STAGESTART_POS").transform.position.y);
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
        //카메라를 원래 z축으로 이동
    }
}

