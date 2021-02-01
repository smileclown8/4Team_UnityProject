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
    }

    // Update is called once per frame
    void Update()
    {
        Pattern2BossMove();
    }

    // =======================================================================
    // 보스 체력, 공격력 관리

    public float Boss_Clea_Doll_HP;
    public float Boss_Clea_Doll_MaxHP;

    public float Boss_Clea_Doll_Grogy_HP;
    public float Boss_Clea_Doll_Grogy_MaxHP;

    GameObject Player;
    GameObject PlayerStatusManager;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Boss_Clea_Doll_Grogy_HP -= collision.gameObject.GetComponent<BulletDamage>().damage;
        }
    }





    // =======================================================================
    // 보스 패턴 결정 부분

    public bool isPattern = false;
    public int nowPattern;

    [SerializeField]
    public GameObject TypingEffectManager;

   // public GameObject Pattern_Hamster;
   // public GameObject Pattern_StartPos;


    public GameObject Pattern2_TrackingBullet;
    public GameObject Pattern2_StartPos;
    public float Pattern2InstiateTimeTerm = 0.5f;


    public int postPattern = 0;
    public int patternRandomRate = 0;


    private bool pattern2Activate = false;

    IEnumerator PatternDecide()
    {
        yield return new WaitForSeconds(1.0f); //보스 패턴 시작하기전까지 시간


        while (true)
        {
            isPattern = false;

            DecidePattern();


            while (true)
            {
                if (nowPattern == postPattern)
                {
                    DecidePattern();
                }
                if (nowPattern != postPattern)
                    break;
            }

            Debug.Log(nowPattern);

            nowPattern = 2;

            switch (nowPattern)
            {
                case 1:
                    // 1번 패턴 생성

                 //   Instantiate(TypingEffectManager, this.transform.position,
                //        this.transform.rotation);
                    yield return new WaitForSeconds(3.0f);

              //      Instantiate(FirstPattern_Hamster, FirsPattern_StartPos.transform.position, FirsPattern_StartPos.transform.rotation);
                    Debug.Log("패턴1");
                    yield return new WaitForSeconds(13.0f); // 1번 패턴이 끝날때까지 걸리는 시간
                    break;
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

                        Pattern2BulletTerm();
                        Instantiate(Pattern2_TrackingBullet, Pattern2_StartPos.transform.position, Pattern2_StartPos.transform.rotation);
                        InstantiateNum++;
                        yield return new WaitForSeconds(Pattern2InstiateTimeTerm);

                        Pattern2BulletTerm();
                        Instantiate(Pattern2_TrackingBullet, Pattern2_StartPos.transform.position, Pattern2_StartPos.transform.rotation);
                        InstantiateNum++;
                        yield return new WaitForSeconds(Pattern2InstiateTimeTerm);

                        Pattern2BulletTerm();
                        Instantiate(Pattern2_TrackingBullet, Pattern2_StartPos.transform.position, Pattern2_StartPos.transform.rotation);
                        InstantiateNum++;
                        yield return new WaitForSeconds(Pattern2InstiateTimeTerm);

                        Pattern2BulletTerm();
                        Instantiate(Pattern2_TrackingBullet, Pattern2_StartPos.transform.position, Pattern2_StartPos.transform.rotation);
                        InstantiateNum++;
                        yield return new WaitForSeconds(Pattern2InstiateTimeTerm);

                        Pattern2BulletTerm();
                        Instantiate(Pattern2_TrackingBullet, Pattern2_StartPos.transform.position, Pattern2_StartPos.transform.rotation);
                        InstantiateNum++;
                        yield return new WaitForSeconds(Pattern2InstiateTimeTerm);

                        Pattern2BulletTerm();
                        Instantiate(Pattern2_TrackingBullet, Pattern2_StartPos.transform.position, Pattern2_StartPos.transform.rotation);
                        InstantiateNum++;
                        yield return new WaitForSeconds(Pattern2InstiateTimeTerm);

                        Pattern2BulletTerm();
                        Instantiate(Pattern2_TrackingBullet, Pattern2_StartPos.transform.position, Pattern2_StartPos.transform.rotation);
                        InstantiateNum++;
                        yield return new WaitForSeconds(Pattern2InstiateTimeTerm);

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
                    // 3번 패턴 생성
       //             Instantiate(TypingEffectManager, this.transform.position,
 //   this.transform.rotation);
                    yield return new WaitForSeconds(3.0f);

   //                 Instantiate(ThirdPattern_Dove, ThirdPattern_DovePos.transform.position, ThirdPattern_DovePos.transform.rotation);

                    Debug.Log("패턴3");
                    yield return new WaitForSeconds(10.0f); // 3번 패턴이 끝날때까지 걸리는 시간
      //              isPattern = true;
                    break;
                case 4:
                    // 4번 패턴 생성
        //            Instantiate(TypingEffectManager, this.transform.position,
  //  this.transform.rotation);
                    yield return new WaitForSeconds(3.0f);

      //              Instantiate(FourthPattern_Bear, FourthPattern_BearPos.transform.position, FourthPattern_BearPos.transform.rotation);


                    Debug.Log("패턴4");
                    yield return new WaitForSeconds(6.0f); // 4번 패턴이 끝날때까지 걸리는 시간
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



    public GameObject Pattern2Pos_BossStart;
    public GameObject Pattern2Pos_BossMid;
    public GameObject Pattern2Pos_BossEnd;
    private bool isArriveStartPos = false;
    private bool isArriveMidPos = false;
    private bool isArriveEndPos = false;

    void Pattern2BossMove()
    {
        if(pattern2Activate == true)
        {
            if (!isArriveStartPos)
            {
                transform.position = Vector2.MoveTowards(transform.position, Pattern2Pos_BossStart.transform.position, Time.deltaTime * 60);
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


}

