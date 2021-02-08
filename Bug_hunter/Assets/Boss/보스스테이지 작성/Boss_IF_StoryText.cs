using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_IF_StoryText : MonoBehaviour
{
    public Text tx;
    public Text tx2;
    public Text tx3;


    private string BossHp70 = "IF의 눈과 마주친거 같다.";
    private string BossHp70_2 = "..나를 원망하는 것 같은 느낌은 기분탓이겠지.";

    private string BossHp40 = "IF의 몸에 생채기가 늘어나는 것이 보인다.";
    private string BossHp20 = "끼잉..끼잉…";
    private string BossHp20_2 = "IF는 필사적으로 무언가를 말하려고 한다.";
    private string BossHp20_3 = "…저 거대한 괴물의 죽음이 다가온 것이 느껴진다.";


    public GameObject Boss_IF;
    public int StoryDecided;


    void Awake()
    {
        Boss_IF = GameObject.Find("Boss_CORE");
        tx = GameObject.Find("StoryText").GetComponent<Text>();
        tx2 = GameObject.Find("StoryText_2").GetComponent<Text>();
        tx3 = GameObject.Find("StoryText_3").GetComponent<Text>();

    }

    void Start()
    {
        StoryDecided = Boss_IF.GetComponent<Boss_IF_CORE_Controller>().StoryDecided;
        StartCoroutine(_typing());
    }

    void Update()
    {
    }

    IEnumerator _typing()
    {
        switch (StoryDecided)
        {
            case 1:
                for (int i = 0; i <= BossHp70.Length; i++)
                {
                    tx.text = BossHp70.Substring(0, i);
                    yield return new WaitForSeconds(0.15f);
                }

                for (int i = 0; i <= BossHp70_2.Length; i++)
                {
                    tx2.text = BossHp70_2.Substring(0, i);
                    yield return new WaitForSeconds(0.15f);
                }

                Invoke("Destroy", 10);
                break;

            case 2:
                for (int i = 0; i <= BossHp40.Length; i++)
                {
                    tx.text = BossHp40.Substring(0, i);
                    yield return new WaitForSeconds(0.15f);
                }
                Invoke("Destroy", 5);

                break;

            case 3:
                for (int i = 0; i <= BossHp20.Length; i++)
                {
                    tx.text = BossHp20.Substring(0, i);
                    yield return new WaitForSeconds(0.15f);
                }

                for (int i = 0; i <= BossHp20_2.Length; i++)
                {
                    tx2.text = BossHp20_2.Substring(0, i);
                    yield return new WaitForSeconds(0.15f);
                }

                for (int i = 0; i <= BossHp20_3.Length; i++)
                {
                    tx3.text = BossHp20_3.Substring(0, i);
                    yield return new WaitForSeconds(0.15f);
                }
                Invoke("Destroy", 10);
                break;
        }
    }

    void Destroy()
    {
        tx.text = "";
        tx2.text = "";
        tx3.text = "";

        Destroy(this.gameObject);
    }
}
