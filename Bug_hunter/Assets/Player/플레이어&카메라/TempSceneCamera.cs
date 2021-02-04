using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempSceneCamera : MonoBehaviour
{
    public GameObject playerCamera;
    Transform playerCameraPos;

    private void Awake()
    {
        playerCamera = GameObject.Find("playerCameraPos");
    }


    // Start is called before the first frame update
    void Start()
    {
        playerCameraPos = playerCamera.transform;
    }

    // Update is called once per frame
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
        transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -10);
    }
}
