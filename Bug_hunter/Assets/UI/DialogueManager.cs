﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    // public GameObject DialougeWindow_Image;

    public static DialogueManager instance;
    
    /*#region Singleton
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion Singleton
    */
    public Text text;
    public SpriteRenderer rendererSprite;
    public SpriteRenderer rendererDialogueWindow;

    private List<string> listSentences;
    private List<Sprite> listSprites;
    private List<Sprite> listDialogueWindows;

    private int count; // 대화 진행 상황 카운트.

    public Animator animSprite;
    public Animator animDialogueWindow;



    public string typeSound;
    public string enterSound;
    public string dog_bark;
    public string Bomb;
    public string C_laugh;
    public string Door_Unlock;
    public string Musicbox1;
    public string SadSound1;
    public string Door_Open;

    private AudioManager theAudio;

    public bool talking = false;
    private bool keyActivated = false;


    // ============ For 플레이어 중력 =====
    GameObject player;
    Rigidbody2D rb;
    // ============ For 바닥 =====
    GameObject floor;
    // ============ For 중력장 =====
    public GameObject gravity;
    //====================중력장의 경우 퍼블릭으로 안 하면 인식을 못해서 일단 퍼블릭으로 작동되게 만들어둠===========


    // Use this for initialization
    void Start()
    {
        count = 0;
        text.text = "";
        listSentences = new List<string>();
        listSprites = new List<Sprite>();
        listDialogueWindows = new List<Sprite>();
        theAudio = FindObjectOfType<AudioManager>();

        // ============ For 플레이어 중력 =====
        player = GameObject.Find("player");
        rb = player.GetComponent<Rigidbody2D>();
        // ============ For 바닥 =====
        floor = GameObject.Find("Tilemap2_4_1");

    }

    public void ShowDialogue(Dialogue dialogue)
    {
        talking = true;

        for (int i = 0; i < dialogue.sentences.Length; i++)
        {
            listSentences.Add(dialogue.sentences[i]);
            listSprites.Add(dialogue.sprites[i]);
            listDialogueWindows.Add(dialogue.dialogueWindows[i]);
        }

        animSprite.SetBool("Appear", true);

        // DialougeWindow_Image.SetActive(true);
        animDialogueWindow.SetBool("Appear", true);
        StartCoroutine(StartDialogueCoroutine());
    }
    public void ExitDialogue()
    {
        text.text = "";
        count = 0;
        listSentences.Clear();
        listSprites.Clear();
        listDialogueWindows.Clear();
        animSprite.SetBool("Appear", false);

        // DialougeWindow_Image.SetActive(false);
        animDialogueWindow.SetBool("Appear", false);

        if (GameObject.Find("Dialougue_03_message") != null)
        {
            GameObject.Find("Dialougue_03_message").GetComponent<TestDialogue>().isTalkWithBook = false;
        }
        if (GameObject.Find("Bobgurut2") != null)
        {
            GameObject.Find("Bobgurut2").GetComponent<TestDialogue>().isBobgurut2 = false;
        }
        if (GameObject.Find("Savor2") != null)
        {
            GameObject.Find("Savor2").GetComponent<TestDialogue>().isSavorBomb = false;
        }
        if (GameObject.Find("Door_close001") != null)
        {
            GameObject.Find("Door_close001").GetComponent<TestDialogue>().isDoor_Unlock = false;
        }
        if (GameObject.Find("Door_close002") != null)
        {
            GameObject.Find("Door_close002").GetComponent<TestDialogue>().isDoor_Unlock = false;
        }
        if (GameObject.Find("Door_close003") != null)
        {
            GameObject.Find("Door_close003").GetComponent<TestDialogue>().isDoor_Unlock = false;
        }
        if (GameObject.Find("Portal_01") != null)
        {
            GameObject.Find("Portal_01").GetComponent<TestDialogue>().isMusicbox1 = false;
            theAudio.Stop(Musicbox1);
        }
        if (GameObject.Find("Stage_Start") != null)
        {
            GameObject.Find("Stage_Start").GetComponent<TestDialogue>().isSadSound1 = false;
        }
        if (GameObject.Find("LostMemory4") != null)
        {
            GameObject.Find("LostMemory4").GetComponent<TestDialogue>().isDoor_Open = false;
        }







        if (GameObject.Find("Portal_01") != null)
        {
            if (GameObject.Find("Portal_01").GetComponent<TestDialogue>().isPortal1 == true)
            {
                Debug.Log(GameObject.Find("Portal_01").GetComponent<TestDialogue>().isPortal1);
                Invoke("Stage2_Portal1_Move", 0.5f); // 포탈2와 대화가 끝나고 0.5초후에 이동
                GameObject.Find("Portal_01").GetComponent<TestDialogue>().isPortal1 = false;
            }
        }

        if (GameObject.Find("Portal_02") != null)
        {
            GameObject.Find("Portal_02").GetComponent<TestDialogue>().isC_laugh = false;

            if (GameObject.Find("Portal_02").GetComponent<TestDialogue>().isPortal2 == true)
            {
                Debug.Log(GameObject.Find("Portal_02").GetComponent<TestDialogue>().isPortal2);
                Invoke("Stage2_Portal2_Move", 0.5f); // 포탈2와 대화가 끝나고 0.5초후에 이동
                GameObject.Find("Portal_02").GetComponent<TestDialogue>().isPortal2 = false;
            }
        }

        // 페어리북 6의 텍스트 출력이 끝나면,                    
        // 이 이후에 바닥이 사라지고(false), 중력장이 사라지고(false), 이슬라프 중력 1로 변경
        // (SetActive) 활용
        if (GameObject.Find("Fairy_tale_06") != null)
        {
            if (rb.bodyType == RigidbodyType2D.Static)
            // 다른 책에서는 작동하지 않게 만들기 위해, 이 책을 읽을 때만의 특수한 조건을 제약으로 건다.
            {

                // 이슬라프의 중력값을 1(기본값)으로 변경
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.gravityScale = 1;
                // 바닥 사라지기 
                floor.SetActive(false);
                // 중력장 사라지기
                gravity.SetActive(false);

            }
            // ==============================================================================
        }

        talking = false;
    }

    void Stage2_Portal1_Move()
    {
        GameObject.Find("player").transform.position = GameObject.Find("XY01").transform.position;
    }

    void Stage2_Portal2_Move()
    {
        GameObject.Find("player").transform.position = GameObject.Find("XY02").transform.position;
    }

    IEnumerator StartDialogueCoroutine()
    {
        if (count > 0)
        {
            if (listDialogueWindows[count] != listDialogueWindows[count - 1])
            {
                animSprite.SetBool("Change", true);

                // DialougeWindow_Image.SetActive(false);
                animDialogueWindow.SetBool("Appear", false);
                yield return new WaitForSeconds(0.2f);
                rendererDialogueWindow.GetComponent<SpriteRenderer>().sprite = listDialogueWindows[count];
                rendererSprite.GetComponent<SpriteRenderer>().sprite = listSprites[count];
                animDialogueWindow.SetBool("Appear", true);
                // DialougeWindow_Image.SetActive(true);
                animSprite.SetBool("Change", false);
            }
            else
            {
                if (listSprites[count] != listSprites[count - 1])
                {
                    animSprite.SetBool("Change", true);
                    yield return new WaitForSeconds(0.1f);
                    rendererSprite.GetComponent<SpriteRenderer>().sprite = listSprites[count];
                    animSprite.SetBool("Change", false);
                }
                else
                {
                    yield return new WaitForSeconds(0.05f);
                }
            }

        }
        else
        {
            yield return new WaitForSeconds(0.05f);
            rendererDialogueWindow.GetComponent<SpriteRenderer>().sprite = listDialogueWindows[count];
            rendererSprite.GetComponent<SpriteRenderer>().sprite = listSprites[count];
        }
        keyActivated = true;

        bool t_white = false; bool t_yellow = false; bool t_ignore = false;
        bool t_teal = false;
        bool t_red = false;

        for (int i = 0; i < listSentences[count].Length; i++)
        {
            switch (listSentences[count][i])
            {
                case '☆': t_white = true; t_yellow = false; t_ignore = true; break;//노란색 끝
                case '★': t_white = false; t_yellow = true; t_ignore = true; break;//노란색시작
                case '♡': t_white = true; t_teal = false; t_ignore = true; break;//청록색끝
                case '♥': t_white = false; t_teal = true; t_ignore = true; break;//청록색시작
                case '◇': t_white = true; t_red = false; t_ignore = true; break;//빨간색끝
                case '◆': t_white = false; t_red = true; t_ignore = true; break;//빨간색시작
            }
            //Debug.Log(listSentences[count][i]);
            string t_letter = listSentences[count][i].ToString();
            if (!t_ignore)
            {
                if (t_white) { t_letter = "<color=#ffffff>" + t_letter + "</color>"; }
                else if (t_yellow) { t_letter = "<color=#FFFF00>" + t_letter + "</color>"; }
                if (t_white) { t_letter = "<color=#ffffff>" + t_letter + "</color>"; }
                else if (t_teal) { t_letter = "<color=#00ffffff>" + t_letter + "</color>"; }
                if (t_white) { t_letter = "<color=#ffffff>" + t_letter + "</color>"; }
                else if (t_red) { t_letter = "<color=#ff0000ff>" + t_letter + "</color>"; }
                text.text += t_letter; // 1글자씩 출력.
            }
            t_ignore = false;

            if (i % 7 == 1)
            {
                theAudio.Play(typeSound);
            }
            yield return new WaitForSeconds(textWaitTime);

        }

    }
    // Update is called once per frame

    public float textWaitTime;

    private bool isSoundPlayed = false;

    void Update()
    {
        if (talking && keyActivated)
        {
            if (Input.GetMouseButtonDown(0))     // 터치일 때
            {
                keyActivated = false;
                theAudio.Play(enterSound);

                // Dialougue_03_message 오브젝트와 대화할때
                // (count+1)번째 문장이 나올 때
                // 그리고, 처음대화할때만(howManyTailkingWithThisObject ==) 효과음(dog_bark)을 재생시켜줘라.


                if (GameObject.Find("Dialougue_03_message") != null) // 없는데 찾으라고해서 오류 났으니까 걸어줘야 함
                {
                    if (GameObject.Find("Dialougue_03_message").GetComponent<TestDialogue>().isTalkWithBook == true
                    && count == 1
                    && GameObject.Find("Dialougue_03_message").GetComponent<TestDialogue>().howManyTailkingWithThisObject == 1)
                    {
                        if (!isSoundPlayed)
                        {
                            Debug.Log("재생");
                            theAudio.Play(dog_bark);
                            isSoundPlayed = true;
                        }
                    }
                }

                if (GameObject.Find("Bobgurut2") != null) // 매 오브젝트마다 걸어주기
                {
                    if (GameObject.Find("Bobgurut2").GetComponent<TestDialogue>().isBobgurut2 == true
                    && count == 1
                    && GameObject.Find("Bobgurut2").GetComponent<TestDialogue>().howManyTailkingWithThisObject == 1)
                    {
                        if (!isSoundPlayed)
                        {
                            Debug.Log("재생");
                            theAudio.Play(dog_bark);
                            isSoundPlayed = true;
                        }
                    }
                }

                if (GameObject.Find("Portal_02") != null) // 매 오브젝트마다 걸어주기
                {
                    if (GameObject.Find("Portal_02").GetComponent<TestDialogue>().isC_laugh == true
                    && count == 8
                    && GameObject.Find("Portal_02").GetComponent<TestDialogue>().howManyTailkingWithThisObject == 1)
                    {
                        if (!isSoundPlayed)
                        {
                            Debug.Log("재생");
                            theAudio.Play(C_laugh);
                            isSoundPlayed = true;
                        }
                    }
                }
                if (GameObject.Find("LostMemory4") != null) // 매 오브젝트마다 걸어주기
                {
                    if (GameObject.Find("LostMemory4").GetComponent<TestDialogue>().isDoor_Open == true
                    && count == 2
                    && GameObject.Find("LostMemory4").GetComponent<TestDialogue>().howManyTailkingWithThisObject == 1)
                    {
                        if (!isSoundPlayed)
                        {
                            Debug.Log("재생");
                            theAudio.Play(Door_Open);
                            isSoundPlayed = true;
                        }
                    }
                }



                if (GameObject.Find("Savor2") != null) // 없는데 찾으라고해서 오류 났으니까 걸어줘야 함
                {

                    if (GameObject.Find("Savor2").GetComponent<TestDialogue>().isSavorBomb == true
                       && count == 9
                       && GameObject.Find("Savor2").GetComponent<TestDialogue>().howManyTailkingWithThisObject == 1)
                    {
                        /*
                        Debug.Log("재생");
                        theAudio.Play(Bomb);
                        */
                        if (!isSoundPlayed)
                        {
                            Debug.Log("재생");
                            theAudio.Play(Bomb);
                            isSoundPlayed = true;
                        }
                    }
                }
                if (GameObject.Find("Portal_01") != null) // 없는데 찾으라고해서 오류 났으니까 걸어줘야 함
                {

                    if (GameObject.Find("Portal_01").GetComponent<TestDialogue>().isMusicbox1 == true
                       && count == 1
                       && GameObject.Find("Portal_01").GetComponent<TestDialogue>().howManyTailkingWithThisObject == 1)
                    {
                        /*
                        Debug.Log("재생");
                        theAudio.Play(Musicbox1);
                        */
                        if (!isSoundPlayed)
                        {
                            Debug.Log("재생");
                            theAudio.Play(Musicbox1);
                            isSoundPlayed = true;
                        }
                    }
                }
                if (GameObject.Find("Stage_Start") != null) // 없는데 찾으라고해서 오류 났으니까 걸어줘야 함
                {

                    if (GameObject.Find("Stage_Start").GetComponent<TestDialogue>().isSadSound1 == true
                       && count == 2
                       && GameObject.Find("Stage_Start").GetComponent<TestDialogue>().howManyTailkingWithThisObject == 1)
                    {
                        /*
                        Debug.Log("재생");
                        theAudio.Play(SadSound1);
                        */
                        if (!isSoundPlayed)
                        {
                            Debug.Log("재생");
                            theAudio.Play(SadSound1);
                            isSoundPlayed = true;
                        }
                    }
                }

                if (textWaitTime != 0)
                {
                    textWaitTime = 0;
                    keyActivated = true;
                }
                else if (textWaitTime == 0)
                {
                    text.text = "";
                    count++;
                    textWaitTime = 0.05f;
                    isSoundPlayed = false;
                    if (count == listSentences.Count)
                    {
                        StopAllCoroutines();
                        ExitDialogue();
                    }
                    else
                    {
                        StopAllCoroutines();
                        StartCoroutine(StartDialogueCoroutine());
                    }
                }

            }
        }
    }
}