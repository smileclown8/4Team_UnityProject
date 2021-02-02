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


    private int HowManyMeetClea;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            limit_Time = limit_Time_Init;
            HowManyMeetClea++;
            Player.transform.position = Player_TempPos.position;
            switch (HowManyMeetClea)
            {
                case 1:
   
                    Debug.Log("첫번째 만남");

                    Movie1.SetActive(true);
                    BlackScreen.SetActive(true);
                    Invoke("SetActiveScreen", 1f);


                    Boss_Clea_StatusManager.GetComponent<Boss_Clea_StatusManager>().Boss_Clea_Doll_HP -= 25f;
                    break;
                case 2:
      
                    Debug.Log("두번째 만남");
                    Movie2.SetActive(true);
                    BlackScreen.SetActive(true);
                    Invoke("SetActiveScreen", 1f);
                    Boss_Clea_StatusManager.GetComponent<Boss_Clea_StatusManager>().Boss_Clea_Doll_HP -= 25f;
                    break;
                case 3:
          
                    Debug.Log("세번째 만남");

                    Boss_Clea_StatusManager.GetComponent<Boss_Clea_StatusManager>().Boss_Clea_Doll_HP -= 25f;
                    break;
                case 4:
               
                    Debug.Log("네번째 만남");

                    Boss_Clea_StatusManager.GetComponent<Boss_Clea_StatusManager>().Boss_Clea_Doll_HP -= 25f;
                    Debug.Log("Clear!");
                    break;
            }

            Invoke("MoveToBoss_AfterMovie", 10f);
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
        limit_Time = limit_Time_Init;
        //Instantiate(Boss_Clea_Doll, Boss_GrogyRecoverPos.transform.position,
        //    Boss_GrogyRecoverPos.transform.rotation);
        Invoke("BossReGenerate", 2f);
        GameObject.Find("Boss_Clea_GrogyManager").GetComponent<Boss_Clea_GrogyManager>().Boss_Clea_Doll
            = Boss_Clea_Doll;
       // Debug.Log("재생성");

        this.gameObject.SetActive(false);    
    }


    void TimeLimit()
    {
        limit_Time -= Time.deltaTime;
        Debug.Log((int)limit_Time);

        if(limit_Time <= 0)
        {
            Player.transform.position = ToBossPos.position;
            isGrogyRecover();
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
        GameObject.Find("Boss_Clea_GrogyManager").GetComponent<Boss_Clea_GrogyManager>().isBossGrogy
            = true;
        isGrogyRecover();
    }

    void SetActiveScreen()
    {
        BlackScreen.SetActive(false);
        Screen.SetActive(true);
    }

}
