using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreRotater : MonoBehaviour
{
    [SerializeField]
    public GameObject Boss_CORE;

    public float cameraShakeAmount;
    public float ShakeTime;
    Vector3 initialPosition;
    public bool isCameraShaking;
    
    public float CameraSize;
    public float shirinkCamerSpeed;

    void Awake()
    {

    }

    void Start()
    {
        initialPosition = new Vector3(GameObject.Find("CORE_STAGESTART_POS").transform.position.x, GameObject.Find("CORE_STAGESTART_POS").transform.position.y, GameObject.Find("CORE_STAGESTART_POS").transform.position.z);

    }

    public float turnSpeed = 15f;
    // Update is called once per frame
    void Update()
    {
      //  Debug.Log(GameObject.Find("CameraEventManager").GetComponent<CameraEventManager>().isEvent);
        transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);

        if (GameObject.Find("CameraEventManager").GetComponent<CameraEventManager>().isEvent == true)
        {
            if (CameraSize < 15)
                CameraSize += Time.deltaTime * shirinkCamerSpeed;

            turnSpeed += Time.deltaTime * 40f;

            if (ShakeTime > 0)
            {
                GameObject.Find("CORE_STAGESTART_POS").transform.position = Random.insideUnitSphere* cameraShakeAmount + initialPosition;
                ShakeTime -= Time.deltaTime;
            }
            else
            {
                ShakeTime = 0.0f;
                GameObject.Find("CORE_STAGESTART_POS").transform.position = initialPosition;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet" &&
           GameObject.Find("CameraEventManager").GetComponent<CameraEventManager>().isEvent == false)
        {
            GameObject.Find("CameraEventManager").GetComponent<CameraEventManager>().isEvent = true;

            Debug.Log("충돌");

            Invoke("CreateBossStartNotice", 1.4f);
            Invoke("CreateBossStartNotice", 1.5f);
            Invoke("CreateBossStartNotice", 1.7f);
            Invoke("CreateBossStartNotice", 2);
            Invoke("StopEvent", 6);
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

    [SerializeField]
    public GameObject StageStartTypingManager;

    public void CreateBossStartNotice()
    {
        Instantiate(StageStartTypingManager, this.transform.position, this.transform.rotation);
    }
}
