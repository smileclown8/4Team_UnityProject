using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondStageCamera : MonoBehaviour
{

    public GameObject playerCamera;
    Transform playerCameraPos;


    private void Awake()
    {
        playerCamera = GameObject.Find("playerCameraPos");
        leftEnd = boss_Clea_CameraPos1.transform.position.x;
        upEnd = boss_Clea_CameraPos1.transform.position.y;

        rightEnd = boss_Clea_CameraPos2.transform.position.x;
        downEnd = boss_Clea_CameraPos2.transform.position.y;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerCameraPos = playerCamera.transform;
    }

    public float CamerMaxLimit;
    public float cameraEnlargementSpeed = 10f;


    public GameObject boss_Clea_CameraPos1;
    public GameObject boss_Clea_CameraPos2;

    float leftEnd;
    float rightEnd;
    float downEnd;
    float upEnd;
    // Update is called once per frame
    void Update()
    {
        /*
        if (this.GetComponent<Camera>().orthographicSize <= 15f)
            this.GetComponent<Camera>().orthographicSize += cameraEnlargementSpeed * Time.deltaTime;
        */

        transform.position = Vector2.Lerp(transform.position, playerCameraPos.position, 50f * Time.deltaTime);

        if (GameObject.Find("Boss_Clea_GrogyManager").GetComponent<Boss_Clea_GrogyManager>().isBossGrogy == false)
        {
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
        }

        transform.Translate(0, 0, -10); //카메라를 원래 z축으로 이동



    }
}
