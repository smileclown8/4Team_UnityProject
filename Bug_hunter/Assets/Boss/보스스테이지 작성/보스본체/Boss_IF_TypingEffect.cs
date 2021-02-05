using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_IF_TypingEffect : MonoBehaviour
{
    public Text tx;
    private string PatternStartText_Hamster = "IF { ME == HAMSTER }";
    private string PatternStartText_Alpaca = "IF { ME == Chipmunk }";
    private string PatternStartText_Dove = "IF { ME == DOVE }";
    private string PatternStartText_Bear = "IF { ME == BEAR }";

    public GameObject Boss_IF;
    public int pattern_Decided;

    void Awake()
    {
        Boss_IF = GameObject.Find("Boss_CORE");
        tx = GameObject.Find("PatternNoticeText").GetComponent<Text>();
    }

    void Start()
    {
        pattern_Decided = Boss_IF.GetComponent<Boss_IF_CORE_Controller>().nowPattern;

        StartCoroutine(_typing(pattern_Decided));
        Invoke("Destroy", 5);
    }

    void Update()
    {
        Debug.Log(pattern_Decided);
    }

    IEnumerator _typing(int pattern_Decided)
    {
        switch (pattern_Decided)
        {
            case 1:
                for (int i = 0; i <= PatternStartText_Hamster.Length; i++)
                {
                    tx.text = PatternStartText_Hamster.Substring(0, i);
                    yield return new WaitForSeconds(0.15f);
                }
                break;

            case 2:
                for (int i = 0; i <= PatternStartText_Alpaca.Length; i++)
                {
                    tx.text = PatternStartText_Alpaca.Substring(0, i);
                    yield return new WaitForSeconds(0.15f);
                }  
                break;

            case 3:
                for (int i = 0; i <= PatternStartText_Dove.Length; i++)
                {
                    tx.text = PatternStartText_Dove.Substring(0, i);
                    yield return new WaitForSeconds(0.15f);
                }
                break;

            case 4:
                for (int i = 0; i <= PatternStartText_Bear.Length; i++)
                {
                    tx.text = PatternStartText_Bear.Substring(0, i);
                    yield return new WaitForSeconds(0.15f);
                }
                break;
        }
    }

    void Destroy()
    {
        tx.text = "";
        Destroy(this.gameObject);
    }
}
