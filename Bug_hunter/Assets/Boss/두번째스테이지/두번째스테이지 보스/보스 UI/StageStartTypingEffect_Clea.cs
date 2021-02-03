using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageStartTypingEffect_Clea : MonoBehaviour
{

    public Text tx;
    private string BossStageStart = "Boss - 영원히 꿈꾸는 아이 클레아";

    void Awake()
    {
        tx = GameObject.Find("StageStartText").GetComponent<Text>();
    }

    void Start()
    {
        Invoke("StartCamereEvent", 3f);
        StartCoroutine(_typing());
        Invoke("StopCameraEvent", 7);
        Invoke("Destroy", 8);
    }

    void Update()
    {
    }

    void StartCamereEvent()
    {
        GameObject.Find("CameraEventManager").GetComponent<CameraEventManager>().isEvent = true;

    }

    void StopCameraEvent()
    {
        GameObject.Find("CameraEventManager").GetComponent<CameraEventManager>().isEvent = false;
    }


    IEnumerator _typing()
    {
        yield return new WaitForSeconds(3.0f);

        for (int i = 0; i <= BossStageStart.Length; i++)
        {
            tx.text = BossStageStart.Substring(0, i);
            yield return new WaitForSeconds(0.15f);
        }
    }

    void Destroy()
    {
        tx.text = "";
        Destroy(this.gameObject);
    }
}
