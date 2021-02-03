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

        StartCoroutine(_typing());

        Invoke("Destroy", 5);
    }

    void Update()
    {
    }

    IEnumerator _typing()
    {
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
