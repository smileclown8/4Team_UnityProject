using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_IF_StoryText : MonoBehaviour
{
    public Text tx;
    private string Boss_Core_HP_Rate_70 = "끼잉..끼잉…IF는 필사적으로 무언가를 말하려고 한다.…저 거대한 괴물의 죽음이 다가온 것이 느껴진다.";
    private string Boss_Core_HP_Rate_40 = "나는빡빡이다";
    private string Boss_Core_HP_Rate_20 = "IF { ME 나는빡빡이다나는빡빡이다 HAMSTER }";

    private void Awake()
    {
        tx = this.GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_typing(Boss_Core_HP_Rate));
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Boss_CORE") != null)
        {
            Boss_Core = GameObject.Find("Boss_CORE");
            Boss_Core_HP = Boss_Core.GetComponent<Boss_IF_CORE_Controller>().Boss_IF_HP;
            Boss_Core_MaxHP = Boss_Core.GetComponent<Boss_IF_CORE_Controller>().Boss_IF_MaxHP;
            Boss_Core_HP_Rate = (int)((Boss_Core_HP / Boss_Core_MaxHP) * 100);

            if (Boss_Core_HP_Rate == 70)
            {
                Hp70Check = true;
            }
            if (Boss_Core_HP_Rate == 40)
            {
                Hp40Check = true;
            }
            if (Boss_Core_HP_Rate == 20)
            {
                Hp20Check = true;
            }
        }
        Debug.Log("Boss_Core_HP_Rate" + Boss_Core_HP_Rate);
    }

    public GameObject Boss_Core;
    private float Boss_Core_HP;
    private float Boss_Core_MaxHP;
    private int Boss_Core_HP_Rate;

    public bool Hp70Check;
    public bool Hp40Check;
    public bool Hp20Check;


    IEnumerator _typing(int Boss_Core_HP_Rate)
    {
        if (Boss_Core_HP_Rate <= 20)
        {
            if (Hp20Check)
            {
                for (int i = 0; i <= Boss_Core_HP_Rate_20.Length; i++)
                {
                    tx.text = Boss_Core_HP_Rate_20.Substring(0, i);

                    if (i == Boss_Core_HP_Rate_20.Length)
                        Hp20Check = false;
                    yield return new WaitForSeconds(0.15f);
                }
            }
        }
        else if (Boss_Core_HP_Rate <= 40)
        {
            if (Hp40Check)
            {
                for (int i = 0; i <= Boss_Core_HP_Rate_40.Length; i++)
                {
                    tx.text = Boss_Core_HP_Rate_40.Substring(0, i);
                    if (i == Boss_Core_HP_Rate_40.Length)
                        Hp40Check = false;
                    yield return new WaitForSeconds(0.15f);
                }
            }
        }
        else if (Boss_Core_HP_Rate <= 70)
        {
            if (Hp70Check)
            {
                Debug.Log("보스 체력 70");
                for (int i = 0; i <= Boss_Core_HP_Rate_70.Length; i++)
                {
                    tx.text = Boss_Core_HP_Rate_70.Substring(0, i);
                    if (i == Boss_Core_HP_Rate_70.Length)
                        Hp70Check = false;
                    yield return new WaitForSeconds(0.15f);
                }
            }
        }
    }

    void Destroy()
    {
        tx.text = "";
        Destroy(this.gameObject);
    }
}
