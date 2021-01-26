using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreRotater : MonoBehaviour
{
    [SerializeField]
    public GameObject Boss_CORE;


    public float cameraShakeAmount;
    float ShakeTime;
    Vector3 initialPosition;
    public bool isCameraShaking;

    
    [SerializeField]
    public float CameraSize;
    public float shirinkCamerSpeed;


    void Awake()
    {
    }


    void Start()
    {
    }

    public float turnSpeed = 15f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);



        if (GameObject.Find("CameraEventManager").GetComponent<CameraEventManager>().isEvent == true)
        {
            if (CameraSize > 5)
                CameraSize -= Time.deltaTime * shirinkCamerSpeed;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            GameObject.Find("CameraEventManager").GetComponent<CameraEventManager>().isEvent = true;


            Debug.Log("충돌");




            Invoke("StopEvent", 5);
        }
    }

    public void VibrateForTime(float time)
    {
        ShakeTime += time;
    }


    public void StopEvent()
    {
        GameObject.Find("CameraEventManager").GetComponent<CameraEventManager>().isEvent = false;
        CameraSize = 10f;

        Boss_CORE.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
