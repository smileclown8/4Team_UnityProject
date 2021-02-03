using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Clea_StatusManager : MonoBehaviour
{
    private void Awake()
    {
        Clea_HpBarColor = GameObject.Find("Clea_HpBar").GetComponent<Image>().color;
        Clea_GrogyHpBarColor = GameObject.Find("Clea_GrogyHpBar").GetComponent<Image>().color;
        Clea_NameColor = GameObject.Find("Clea_Name").GetComponent<Text>().color;
    }
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(StageStartTypingManager_Clea, this.transform.position, this.transform.rotation);
        Invoke("StartShowBossInfoInvoke", 8f);
    }

    // Update is called once per frame
    void Update()
    {
        ShowBossInfo();
        Boss_HpBarManagement();
    }

    public Color Clea_HpBarColor;
    public Color Clea_GrogyHpBarColor;
    public Color Clea_NameColor;
    public float Alpha = 0 ;
    public bool isStartShowBossInfo =false;



    // =======================================================================
    // 보스 UI 관리
    public GameObject StageStartTypingManager_Clea;
    public GameObject Boss_HpBar;
    public GameObject Boss_GrogyHpBar;

    void StartShowBossInfoInvoke ()
    {
        isStartShowBossInfo = true;
    }

    void ShowBossInfo()
    {
        if (isStartShowBossInfo)
        {
            if(Alpha <= 0.8f)
            {
                GameObject.Find("Clea_HpBar").GetComponent<Image>().color = new Color(Clea_HpBarColor.r, Clea_HpBarColor.g, Clea_HpBarColor.b, Alpha);
                GameObject.Find("Clea_GrogyHpBar").GetComponent<Image>().color = new Color(Clea_GrogyHpBarColor.r, Clea_GrogyHpBarColor.g, Clea_GrogyHpBarColor.b, Alpha);
                GameObject.Find("Clea_Name").GetComponent<Text>().color = new Color(Clea_NameColor.r, Clea_NameColor.g, Clea_NameColor.b, Alpha);
                Alpha += Time.deltaTime * 0.5f;
            }
        }
    }

    void Boss_HpBarManagement()
    {
        GameObject.Find("Clea_HpBar").GetComponent<Image>().fillAmount = Boss_Clea_Doll_HP / Boss_Clea_Doll_MaxHP;
        GameObject.Find("Clea_GrogyHpBar").GetComponent<Image>().fillAmount = Boss_Clea_Doll_Grogy_HP / Boss_Clea_Doll_Grogy_MaxHP;
    }


    // =======================================================================
    // 보스 체력, 공격력 관리

    public float Boss_Clea_Doll_HP;
    public float Boss_Clea_Doll_MaxHP;

    public float Boss_Clea_Doll_Grogy_HP;
    public float Boss_Clea_Doll_Grogy_MaxHP;

}
