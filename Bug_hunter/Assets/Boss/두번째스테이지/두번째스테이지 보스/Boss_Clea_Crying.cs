using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss_Clea_Crying : MonoBehaviour
{

    public float limit_Time_Init;


    private float limit_Time;

    void Awake()
    {
        Player = GameObject.Find("player");
    }
    // Start is called before the first frame update
    void Start()
    {
      
        limit_Time = limit_Time_Init;
    }

    // Update is called once per frame
    void Update()
    {
        ToBossPos = GameObject.Find("ToBossPos").transform;
        Player_TempPos = GameObject.Find("Player_TempPos").transform;
        TimeLimit();
    }

    public Transform ToBossPos;
    public Transform Player_TempPos;

    [SerializeField]
    public GameObject Boss_Clea_StatusManager;
    public float Boss_Clea_Doll_HP;


    [SerializeField]
    public GameObject Boss_Clea_Grogy;



    public GameObject Player;



    [SerializeField]
    public GameObject Screen;

    [SerializeField]
    public GameObject BlackScreen;

    [SerializeField]
    public GameObject Movie1;
    [SerializeField]
    public GameObject Movie2;
    [SerializeField]
    public GameObject Movie3;
    [SerializeField]
    public GameObject Movie4;


    private int HowManyMeetClea;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // BGM 끄기
            GameObject.Find("DollBGM").GetComponent<AudioSource>().Stop();

            isPlayerInBossInside = false;
            limit_Time = limit_Time_Init;
            HowManyMeetClea++;
            BlackScreen.SetActive(true);
            Player.transform.position = Player_TempPos.position;
            switch (HowManyMeetClea)
            {
                case 1:
   
                    Debug.Log("첫번째 만남");

                    Movie1.SetActive(true);
                    Invoke("SetActiveScreen", 0.1f);
                    Invoke("MoveToBoss_AfterMovie", 12f);


                    Boss_Clea_StatusManager.GetComponent<Boss_Clea_StatusManager>().Boss_Clea_Doll_HP -= 25f;
                    break;
                case 2:
      
                    Debug.Log("두번째 만남");
                    Movie2.SetActive(true);

                    Invoke("SetActiveScreen", 0.1f);
                    Invoke("MoveToBoss_AfterMovie", 17f);
                    Boss_Clea_StatusManager.GetComponent<Boss_Clea_StatusManager>().Boss_Clea_Doll_HP -= 25f;
                    break;
                case 3:
          
                    Debug.Log("세번째 만남");
                    Movie3.SetActive(true);
                    Invoke("SetActiveScreen", 0.1f);
                    Invoke("MoveToBoss_AfterMovie", 17f);
                    Boss_Clea_StatusManager.GetComponent<Boss_Clea_StatusManager>().Boss_Clea_Doll_HP -= 25f;
                    break;
                case 4:
               
                    Debug.Log("네번째 만남");
                    Movie4.SetActive(true);
                    Invoke("SetActiveScreen", 0.1f);
                    limit_Time = 500f;
                    Invoke("MoveToBoss_AfterMovie", 65f);
                    Boss_Clea_StatusManager.GetComponent<Boss_Clea_StatusManager>().Boss_Clea_Doll_HP -= 25f;
                    Debug.Log("Clear!");
                    break;
            }

            Debug.Log("클레아 인형 HP 감소!");
            Debug.Log(Boss_Clea_StatusManager.GetComponent<Boss_Clea_StatusManager>().Boss_Clea_Doll_HP);
            Debug.Log(Boss_Clea_StatusManager.GetComponent<Boss_Clea_StatusManager>().Boss_Clea_Doll_Grogy_HP);
            Debug.Log(Boss_Clea_StatusManager.GetComponent<Boss_Clea_StatusManager>().Boss_Clea_Doll_Grogy_MaxHP);
        }
    }

    [SerializeField]
    public GameObject Boss_Clea_Doll;

    public GameObject Boss_GrogyRecoverPos;

    void isGrogyRecover()
    {
 
        GameObject.Find("Boss_Clea_StatusManager").GetComponent<Boss_Clea_StatusManager>().Boss_Clea_Doll_Grogy_HP
            = GameObject.Find("Boss_Clea_StatusManager").GetComponent<Boss_Clea_StatusManager>().Boss_Clea_Doll_Grogy_MaxHP;
        GameObject.Find("Boss_Clea_GrogyManager").GetComponent<Boss_Clea_GrogyManager>().isBossGrogy = false;
        // Boss_Clea_Doll.SetActive(true); Instatiate로 바꾸기
        Boss_Clea_Grogy.SetActive(false);
        LimitTimeNoticeText.SetActive(false);
        limit_Time = limit_Time_Init;
        //Instantiate(Boss_Clea_Doll, Boss_GrogyRecoverPos.transform.position,
        //    Boss_GrogyRecoverPos.transform.rotation);
        Invoke("BossReGenerate", 2f);
        GameObject.Find("Boss_Clea_GrogyManager").GetComponent<Boss_Clea_GrogyManager>().Boss_Clea_Doll
            = Boss_Clea_Doll;
       // Debug.Log("재생성");

        this.gameObject.SetActive(false);    
    }

    private bool isPlayerInBossInside;
    public GameObject LimitTimeNoticeText;

    void TimeLimit()
    {
        if (GameObject.Find("Boss_Clea_Grogy") != null)
        {
            isPlayerInBossInside = GameObject.Find("Boss_Clea_Grogy").GetComponent<ToTheBossInside>().isPlayerInBossInside;
        }

        if (isPlayerInBossInside)
        {
            limit_Time -= Time.deltaTime;
            int LeftTime = (int)limit_Time;
            if (LeftTime <= 30)
            {
                LimitTimeNoticeText.GetComponent<Text>().text = LeftTime.ToString();
            }
            if (limit_Time <= 0)
            {
                Player.transform.position = ToBossPos.position;
                isGrogyRecover();
            }
        }
    }

    void BossReGenerate()
    {
      Instantiate(Boss_Clea_Doll, Boss_GrogyRecoverPos.transform.position,
          Boss_GrogyRecoverPos.transform.rotation);
       Debug.Log("재생성");
    }

    void MoveToBoss_AfterMovie()
    {
        Player.transform.position = ToBossPos.position;
        if(Movie1 != null)
        Movie1.SetActive(false);
        if(Movie2 != null)
        Movie2.SetActive(false);
        Screen.SetActive(false);
        isGrogyRecover();
    }

    void SetActiveScreen()
    {
        BlackScreen.SetActive(false);
        Screen.SetActive(true);
    }

}
