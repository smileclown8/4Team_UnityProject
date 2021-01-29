using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Core_StageStart_TypingEffect : MonoBehaviour
{
    public Text tx;
    private string BossStageStart = "BOSS -  절망한 데이터 IF";
  
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
