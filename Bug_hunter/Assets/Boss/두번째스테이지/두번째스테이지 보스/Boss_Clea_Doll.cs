using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Clea_Doll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //=======================================
        //플레이어 찾기
        Player = GameObject.Find("player");
        PlayerStatusManager = GameObject.Find("PlayerStatusManager");
        

   
        //=======================================
        //패턴생성 코루틴 시작
        StartCoroutine(PatternDecide());

        //=====================================
        //패턴에 필요한 좌표들 초기화

        Pattern1_BossPos = GameObject.Find("Pattern1_BossPos");
        Pattern1_BulletStartPos = GameObject.Find("Pattern1_BulletStartPos");
        Pattern2_StartPos = GameObject.Find("Pattern2StartPos");
        Pattern2StartPos_Init = GameObject.Find("Pattern2StartPos_Init");

        Pattern2Pos_BossStart = GameObject.Find("Pattern2Pos_BossStart");
        Pattern2Pos_BossMid = GameObject.Find("Pattern2Pos_BossMid");
        Pattern2Pos_BossEnd = GameObject.Find("Pattern2Pos_BossEnd");
        Pattern3_BossPos = GameObject.Find("Pattern3_BossPos");
        Pattern3_BombBear_Pos1 = GameObject.Find("Pattern3_BombBear_Pos1");
        Pattern3_BombBear_Pos2 = GameObject.Find("Pattern3_BombBear_Pos2");
        Pattern3_BombBear_Pos3 = GameObject.Find("Pattern3_BombBear_Pos3");
        Pattern3_BombBear_Pos4 = GameObject.Find("Pattern3_BombBear_Pos4");
        Pattern3_BombBear_Pos5 = GameObject.Find("Pattern3_BombBear_Pos5");
        Pattern3_BombBear_Pos6 = GameObject.Find("Pattern3_BombBear_Pos6");
        Pattern3_BombBear_Pos7 = GameObject.Find("Pattern3_BombBear_Pos7");

        Pattern4_BossPos = GameObject.Find("Pattern4_BossPos");
        Pattern4_GeneratePos = GameObject.Find("Pattern4_GeneratePos");
        Pattenr4_BossReturnPos = GameObject.Find("Pattenr4_BossReturnPos");


        Pattern5_BossPos = GameObject.Find("Pattern5_BossPos");
        Pattern5_BulletStartPos = GameObject.Find("Pattern5_BulletStartPos");
    }

    // Update is called once per frame
    void Update()
    {
        //===========================================================
        //패턴발생시 보스가 패턴위치로 이동
        Pattern1BossMove();
        Pattern2BossMove();
        Pattern3BossMove();
        Pattern4BossMove();
        Pattern5BossMove();
        Pattern4BossReturnMove();

        if (GameObject.Find("Pattern4_BigBombDoll(Clone)") != null)
        {
            pattern4Return = GameObject.Find("Pattern4_BigBombDoll(Clone)").GetComponent<Pattern4_BigBombDoll>().BossReturn;
        }

        Debug.Log(pattern4Return);
    }

    // =======================================================================
    // 보스 체력, 공격력 관리



    GameObject Player;
    GameObject PlayerStatusManager;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            GameObject.Find("Boss_Clea_StatusManager").GetComponent<Boss_Clea_StatusManager>()
                .Boss_Clea_Doll_Grogy_HP -= collision.gameObject.GetComponent<BulletDamage>().damage;
        }
    }





    // =======================================================================
    // 보스 패턴 결정 부분

    public int nowPattern;

    [SerializeField]
    public GameObject TypingEffectManager;

    // public GameObject Pattern_Hamster;
    // public GameObject Pattern_StartPos;

    public int postPattern = 0;
    public int patternRandomRate = 0;



    private GameObject Pattern1_BossPos;
    public GameObject Pattern1_CircleBullet;
    private GameObject Pattern1_BulletStartPos;
    public bool Pattern1BulletCanMove;

    public GameObject Pattern2_TrackingBullet;
    private GameObject Pattern2_StartPos;
    public float Pattern2InstiateTimeTerm = 0.5f;
    private GameObject Pattern2StartPos_Init;

    public GameObject Pattern3_BombBear;
    private GameObject Pattern3_BossPos;
    private GameObject Pattern3_BombBear_Pos1;
    private GameObject Pattern3_BombBear_Pos2;
    private GameObject Pattern3_BombBear_Pos3;
    private GameObject Pattern3_BombBear_Pos4;
    private GameObject Pattern3_BombBear_Pos5;
    private GameObject Pattern3_BombBear_Pos6;
    private GameObject Pattern3_BombBear_Pos7;

    private GameObject Pattern4_BossPos;
    public GameObject Pattern4_BigBombDoll;
    private GameObject Pattenr4_BossReturnPos;

    private GameObject Pattern4_GeneratePos;

    public GameObject Pattern5_DamaegeBullet;
    public GameObject Pattern5_HealBullet;
    private GameObject Pattern5_BossPos;
    private GameObject Pattern5_BulletStartPos;
    public bool Pattern5BulletCanMove;


    private bool pattern1Activate = false;
    public bool pattern1RotateStart = false;
    private bool pattern2Activate = false;
    private bool pattern3Activate = false;
    private bool pattern4Activate = false;
    public bool pattern4Return = false;

    private bool pattern5Activate = false;
    IEnumerator PatternDecide()
    {
        yield return new WaitForSeconds(1.0f); //보스 패턴 시작하기전까지 시간


        while (true)
        {

            //DecidePattern();

         //   nowPattern = Random.Range(1, 5+1);

            while (true)
            {
                if (nowPattern == postPattern)
                {
                    DecidePattern();
                }
                if (nowPattern != postPattern)
                    break;
            }
            nowPattern = 3;

            switch (nowPattern)
            {
                case 1:
                    {
                        // 1번 패턴 생성

                        //   Instantiate(TypingEffectManager, this.transform.position,
                        //        this.transform.rotation);



                        yield return new WaitForSeconds(1.0f);

                        Debug.Log("패턴1");
                        pattern1Activate = true;
                        yield return new WaitForSeconds(3.0f);

                        pattern1RotateStart = true;
                        for (int i = 0; i < 14; i++)
                        {
                            Instantiate(Pattern1_CircleBullet, Pattern1_BulletStartPos.transform.position,
                                Pattern1_BulletStartPos.transform.rotation);
                            yield return new WaitForSeconds(0.07f);

                        }
                        pattern1RotateStart = false;

                        yield return new WaitForSeconds(1.0f);
                        Pattern1BulletCanMove = true;
                        yield return new WaitForSeconds(1.0f);
                        for (int i = 0; i < 5; i++)
                        {
                            Pattern1BulletCanMove = false;
                            yield return new WaitForSeconds(1.0f);
                            Pattern1BulletCanMove = true;
                            yield return new WaitForSeconds(1.0f);

                        }
                        Pattern1BulletCanMove = false;
                        pattern1Activate = false;
                        yield return new WaitForSeconds(10.0f); // 1번 패턴이 끝날때까지 걸리는 시간
                        break;
                    }
                case 2:
                    {
                        // 2번 패턴 생성
                        //          Instantiate(TypingEffectManager, this.transform.position,
                        //             this.transform.rotation);

                        yield return new WaitForSeconds(2.0f);


                        Debug.Log("패턴2");
                        pattern2Activate = true;
                        yield return new WaitForSeconds(1.5f);

                        int InstantiateNum = 0;
                     
       
                        Instantiate(Pattern2_TrackingBullet, Pattern2_StartPos.transform.position, Pattern2_StartPos.transform.rotation);
                        yield return new WaitForSeconds(Pattern2InstiateTimeTerm); 

                        for(int i = 0; i < 7; i ++)
                        {
                            Pattern2BulletTerm();
                            Instantiate(Pattern2_TrackingBullet, Pattern2_StartPos.transform.position, Pattern2_StartPos.transform.rotation);
                            InstantiateNum++;
                            yield return new WaitForSeconds(Pattern2InstiateTimeTerm);
                        }

                        Pattern2_StartPos.transform.position = new Vector2(Pattern2_StartPos.transform.position.x - 8 * InstantiateNum
                            , Pattern2_StartPos.transform.position.y);

                        yield return new WaitForSeconds(5.0f); // 2번 패턴이 끝날때까지 걸리는 시간

                        pattern2Activate = false;
                        isArriveStartPos = false;
                       isArriveMidPos = false;
                        isArriveEndPos = false;
                    }             
                    break;
                case 3:
                    {
                        // 3번 패턴 생성
                        //             Instantiate(TypingEffectManager, this.transform.position,
                        //   this.transform.rotation);
                        yield return new WaitForSeconds(3.0f);

                        pattern3Activate = true;

                        yield return new WaitForSeconds(2.0f);


                        Debug.Log("패턴3");
                        {
                            Instantiate(Pattern3_BombBear, Pattern3_BombBear_Pos1.transform.position,
                                Pattern3_BombBear_Pos1.transform.rotation);
                            yield return new WaitForSeconds(0.2f);
                            Instantiate(Pattern3_BombBear, Pattern3_BombBear_Pos2.transform.position,
        Pattern3_BombBear_Pos2.transform.rotation);
                            yield return new WaitForSeconds(0.2f);
                            Instantiate(Pattern3_BombBear, Pattern3_BombBear_Pos3.transform.position,
        Pattern3_BombBear_Pos3.transform.rotation);
                            yield return new WaitForSeconds(0.2f);
                            Instantiate(Pattern3_BombBear, Pattern3_BombBear_Pos4.transform.position,
        Pattern3_BombBear_Pos4.transform.rotation);
                            yield return new WaitForSeconds(0.2f);
                            Instantiate(Pattern3_BombBear, Pattern3_BombBear_Pos5.transform.position,
        Pattern3_BombBear_Pos5.transform.rotation);
                            yield return new WaitForSeconds(0.2f);
                            Instantiate(Pattern3_BombBear, Pattern3_BombBear_Pos6.transform.position,
        Pattern3_BombBear_Pos6.transform.rotation);
                            yield return new WaitForSeconds(0.2f);
                            Instantiate(Pattern3_BombBear, Pattern3_BombBear_Pos7.transform.position,
        Pattern3_BombBear_Pos7.transform.rotation);

                        }
                        yield return new WaitForSeconds(5f); // 3번 패턴이 끝날때까지 걸리는 시간
                        pattern3Activate = false;
                        break;
                    }
                case 4:
                    // 4번 패턴 생성
        //            Instantiate(TypingEffectManager, this.transform.position,
  //  this.transform.rotation);
                    yield return new WaitForSeconds(3.0f);

                    //              Instantiate(FourthPattern_Bear, FourthPattern_BearPos.transform.position, FourthPattern_BearPos.transform.rotation);

                    pattern4Activate = true;
                    Debug.Log("패턴4");

                    Instantiate(Pattern4_BigBombDoll, Pattern4_GeneratePos.transform.position, Pattern4_GeneratePos.transform.rotation);


                    yield return new WaitForSeconds(15f); // 4번 패턴이 끝날때까지 걸리는 시간
                    pattern4Activate = false;
                    pattern4Return = false;
                    break;


                case 5:
                    yield return new WaitForSeconds(3.0f);//패턴알림 시간

                    Debug.Log("패턴5");

                    pattern5Activate = true;
                    yield return new WaitForSeconds(2.0f);//이동에 걸리는 최소시간

                    int DecideHealBulletPos1 = Random.Range(1, 6 + 1);
                    int DecideHealBulletPos2 = Random.Range(1, 6 + 1);
                    while (true)
                    {
                        if (DecideHealBulletPos2 != DecideHealBulletPos1)
                            break;
                        DecideHealBulletPos2 = Random.Range(1, 6 + 1); 
                    }

                    Debug.Log(DecideHealBulletPos1);
                    Debug.Log(DecideHealBulletPos2);
                    Transform BulletPos = Pattern5_BulletStartPos.transform;
                    BulletPos.position = Pattern5_BulletStartPos.transform.position;
                    for (int i = 1; i <= 6; i++)
                    {
                        if (i == DecideHealBulletPos1 || i == DecideHealBulletPos2)
                            Instantiate(Pattern5_HealBullet, BulletPos.position, BulletPos.rotation);
                        else
                            Instantiate(Pattern5_DamaegeBullet, BulletPos.position, BulletPos.rotation);
                        BulletPos.position = new Vector2(BulletPos.position.x, BulletPos.position.y - 6f);
                        yield return new WaitForSeconds(0.2f);
                    }
                    BulletPos.position = new Vector2(BulletPos.position.x, BulletPos.position.y + 6f *6);
                    yield return new WaitForSeconds(2.0f);

                    Pattern5BulletCanMove = true;

                    yield return new WaitForSeconds(6.0f); // 5번 패턴이 끝날때까지 걸리는 시간
                    pattern5Activate = false;
                    Pattern5BulletCanMove = false;
                    break;
            }
            postPattern = nowPattern;
            yield return new WaitForSeconds(3.0f); // 패턴이 끝나고 다시 패턴이 시작될 때까지 걸리는 시간

        }
    }

    

    void DecidePattern()
    {
        patternRandomRate = Random.Range(1, 100 + 1);

        if (patternRandomRate > 0 && patternRandomRate <= 10) nowPattern = 1;
        else if (patternRandomRate > 10 && patternRandomRate <= 30) nowPattern = 2;
        else if (patternRandomRate > 30 && patternRandomRate <= 50) nowPattern = 3;
        else if (patternRandomRate > 50 && patternRandomRate <= 70) nowPattern = 4;
        else if (patternRandomRate > 70 && patternRandomRate <= 90) nowPattern = 5;
        else if (patternRandomRate > 90 && patternRandomRate <= 100) nowPattern = 6;
    }

    void Pattern2BulletTerm()
    {
        Pattern2_StartPos.transform.position = new Vector2(Pattern2_StartPos.transform.position.x + 8, Pattern2_StartPos.transform.position.y);
    }



    private GameObject Pattern2Pos_BossStart;
    private GameObject Pattern2Pos_BossMid;
    private GameObject Pattern2Pos_BossEnd;
    private bool isArriveStartPos = false;
    private bool isArriveMidPos = false;
    private bool isArriveEndPos = false;


    void Pattern1BossMove()
    {
        if (pattern1Activate)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                Pattern1_BossPos.transform.position, Time.deltaTime * 50f);
        }
    }

    void Pattern2BossMove()
    {
        if(pattern2Activate == true)
        {
            if (!isArriveStartPos)
            {
                transform.position = Vector2.MoveTowards(transform.position, Pattern2Pos_BossStart.transform.position, Time.deltaTime * 80);
                if (transform.position == Pattern2Pos_BossStart.transform.position)
                    isArriveStartPos = true;
            }
            else if (isArriveStartPos && !isArriveMidPos)
            {
                transform.position = Vector2.MoveTowards(transform.position, Pattern2Pos_BossMid.transform.position, Time.deltaTime * 9.2f);
                if (transform.position == Pattern2Pos_BossMid.transform.position)
                    isArriveMidPos = true;
            }

            else if (isArriveStartPos && isArriveMidPos && !isArriveEndPos)
            {
                transform.position = Vector2.MoveTowards(transform.position, Pattern2Pos_BossEnd.transform.position, Time.deltaTime * 10);
                if (transform.position == Pattern2Pos_BossEnd.transform.position)
                    isArriveEndPos = false;
            }
        }
    }

    void Pattern3BossMove()
    {
        if(pattern3Activate == true)
        {
            transform.position = Vector2.MoveTowards(transform.position,
    Pattern3_BossPos.transform.position, Time.deltaTime * 50f);
        }
    }

    void Pattern4BossMove()
    {
        if (pattern4Activate)
        {
            transform.position = Vector2.MoveTowards(transform.position,
Pattern4_BossPos.transform.position, Time.deltaTime * 50f);
        }
    }

    void Pattern4BossReturnMove()
    {
        if (pattern4Return)
        {
            transform.position = Vector2.MoveTowards(transform.position,
Pattenr4_BossReturnPos.transform.position, Time.deltaTime * 80f);
        }
    }

    void Pattern5BossMove()
    {
        if (pattern5Activate)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                Pattern5_BossPos.transform.position, Time.deltaTime * 80f);
        }
    }


}

