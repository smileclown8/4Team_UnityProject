using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public static DialogueManager instance;

    #region Singleton
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

    private AudioManager theAudio;

    public bool talking = false;
    private bool keyActivated = false;

    // Use this for initialization
    void Start()
    {
        count = 0;
        text.text = "";
        listSentences = new List<string>();
        listSprites = new List<Sprite>();
        listDialogueWindows = new List<Sprite>();
        theAudio = FindObjectOfType<AudioManager>();
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
        if (GameObject.Find("Portal_02") != null)
        {
            GameObject.Find("Portal_02").GetComponent<TestDialogue>().isC_laugh = false;
        }
        talking = false;
    }


    IEnumerator StartDialogueCoroutine()
    {
        if (count > 0)
        {
            if (listDialogueWindows[count] != listDialogueWindows[count - 1])
            {
                animSprite.SetBool("Change", true);
                animDialogueWindow.SetBool("Appear", false);
                yield return new WaitForSeconds(0.2f);
                rendererDialogueWindow.GetComponent<SpriteRenderer>().sprite = listDialogueWindows[count];
                rendererSprite.GetComponent<SpriteRenderer>().sprite = listSprites[count];
                animDialogueWindow.SetBool("Appear", true);
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

        for (int i = 0; i < listSentences[count].Length; i++)
        {
            switch (listSentences[count][i])
            {
                case '☆': t_white = true; t_yellow = false; t_ignore = true; break;//노란색 끝
                case '★': t_white = false; t_yellow = true; t_ignore = true; break;//노란색시작
                case '♡': t_white = true; t_teal = false; t_ignore = true; break;//청록색시작
                case '♥': t_white = false; t_teal = true; t_ignore = true; break;//청록색시작
            }
            //Debug.Log(listSentences[count][i]);
            string t_letter = listSentences[count][i].ToString();
            if (!t_ignore)
            {
                if (t_white) { t_letter = "<color=#ffffff>" + t_letter + "</color>"; }
                else if (t_yellow) { t_letter = "<color=#FFFF00>" + t_letter + "</color>"; }
                if (t_white) { t_letter = "<color=#ffffff>" + t_letter + "</color>"; }
                else if (t_teal) { t_letter = "<color=#00ffffff>" + t_letter + "</color>"; }
                text.text += t_letter; // 1글자씩 출력.
            }
            t_ignore = false;

            if (i % 7 == 1)
            {
                theAudio.Play(typeSound);
            }
            yield return new WaitForSeconds(0.05f);
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (talking && keyActivated)
        {
            // if (Input.GetKeyDown(KeyCode.Z))   // 터치가 아닐때
            if (Input.GetMouseButtonDown(0))     // 터치일 때
            {
                keyActivated = false;
                count++;
                text.text = "";
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
                        theAudio.Play(dog_bark);
                    }
                }

                if (GameObject.Find("Bobgurut2") != null) // 매 오브젝트마다 걸어주기
                {
                    if (GameObject.Find("Bobgurut2").GetComponent<TestDialogue>().isBobgurut2 == true
                    && count == 1
                    && GameObject.Find("Bobgurut2").GetComponent<TestDialogue>().howManyTailkingWithThisObject == 1)
                    {
                        theAudio.Play(dog_bark);
                    }
                }

                if (GameObject.Find("Portal_02") != null) // 매 오브젝트마다 걸어주기
                {
                    if (GameObject.Find("Portal_02").GetComponent<TestDialogue>().isC_laugh == true
                    && count == 8
                    && GameObject.Find("Portal_02").GetComponent<TestDialogue>().howManyTailkingWithThisObject == 1)
                    {
                        theAudio.Play(C_laugh);
                    }
                }



                if (GameObject.Find("Savor2") != null) // 없는데 찾으라고해서 오류 났으니까 걸어줘야 함
                {

                    if (GameObject.Find("Savor2").GetComponent<TestDialogue>().isSavorBomb == true
                       && count == 9
                       && GameObject.Find("Savor2").GetComponent<TestDialogue>().howManyTailkingWithThisObject == 1)
                    {
                        Debug.Log("재생");
                        theAudio.Play(Bomb);
                    }


                }







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