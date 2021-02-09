using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogue : MonoBehaviour
{
    [SerializeField]
    public Dialogue dialogue;

    [SerializeField]
    public Dialogue dialogue2;

    private DialogueManager theDM;
    public GameObject targetObject;


    public bool isSavorTalkItemGet = false;
    public bool isLamziTalk = false;

    //오디오 사운드 관련
    public string Door_Unlock;
    private AudioManager theAudio;
    public string Door_Open;

    // ============ For 중력장 =====
    GameObject player;
    Rigidbody2D rb;


    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();


        theAudio = FindObjectOfType<AudioManager>();        
        
        // ============ For 중력장 =====
        player = GameObject.Find("player");
        rb = player.GetComponent<Rigidbody2D>();
    }

    public bool isTalkWithBook = false;
    public bool isBobgurut2 = false;
    public bool isSavorBomb = false;
    public bool isC_laugh = false;
    public bool isDoor_Unlock = false;
    public bool isMusicbox1 = false;
    public bool isSadSound1 = false;
    public bool isDoor_Open = false;



    public bool isPortal1 = false;
    public bool isPortal2 = false;

  
    


    private void Update()
    {
        if (this.gameObject.name == "Savor2")
        {
            Destroy(GameObject.Find("Savor1_Chatbox(Clone)"));
        }
        if (this.gameObject.name == "Savor4")
        {
            Destroy(GameObject.Find("Savor3_Chatbox(Clone)"));
        }
    }

    void ColliderReactive()
    {
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }








    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {

            if (howManyTailkingWithThisObject >= 1
                && this.dialogue2.sentences.Length != 0)
            {
                theDM.ShowDialogue(this.dialogue2);
            }
            else
            {
                if (this.gameObject.name == "Dialougue_00_message")
                {
                    theDM.ShowDialogue(this.dialogue);
                }
                if (this.gameObject.name == "Dialougue_01_message")
                {
                    theDM.ShowDialogue(this.dialogue);

                }
                if (this.gameObject.name == "Dialougue_03_message")
                {
                    theDM.ShowDialogue(this.dialogue);
                    isTalkWithBook = true;
                }
                if (this.gameObject.name == "Dialougue_04_message")
                {
                    theDM.ShowDialogue(this.dialogue);
                }
                if (this.gameObject.name == "Seed")
                {
                    theDM.ShowDialogue(this.dialogue);
                    GameObject.Find("Savor3").SetActive(false);

                    targetObject.SetActive(true);
                    GameObject.Find("Savor4").GetComponent<TestDialogue>().isLamziTalk = true;
                    Destroy(GameObject.Find("Seed"));
                }

                    if (this.gameObject.name == "Savor1")
                {
                    theDM.ShowDialogue(this.dialogue);
                }
                if (this.gameObject.name == "Bolt")
                {
                    theDM.ShowDialogue(this.dialogue);
                    GameObject.Find("Savor1").SetActive(false);

                    targetObject.SetActive(true);
                    GameObject.Find("Savor2").GetComponent<TestDialogue>().isSavorTalkItemGet = true;

                }
                if (this.gameObject.name == "Savor2")
                {
                    //if (isSavorTalkItemGet == true)
                    //{
                        theDM.ShowDialogue(this.dialogue);
                        isSavorBomb = true;
                    //} 
                    

                }
                if (this.gameObject.name == "Bobgurut2")
                {
                    theDM.ShowDialogue(this.dialogue);
                    isBobgurut2 = true;
                }
                if (this.gameObject.name == "Savor3")
                {
                    theDM.ShowDialogue(this.dialogue);
                }
                if(this.gameObject.name == "Savor4")
                {
                    theDM.ShowDialogue(this.dialogue);
                }
                if (this.gameObject.name == "Bear")
                {
                    theDM.ShowDialogue(this.dialogue);
                }
                if (this.gameObject.name == "Memory1")
                {
                    theDM.ShowDialogue(this.dialogue);
                }
                if (this.gameObject.name == "Memory2")
                {
                    theDM.ShowDialogue(this.dialogue);
                }
                if (this.gameObject.name == "Memory3")
                {
                    theDM.ShowDialogue(this.dialogue);
                }
                if (this.gameObject.name == "Memory4")
                {
                    theDM.ShowDialogue(this.dialogue);
                }
                if (this.gameObject.name == "Memory5")
                {
                    theDM.ShowDialogue(this.dialogue);
                }
                if (this.gameObject.name == "Memory6")
                {
                    theDM.ShowDialogue(this.dialogue);
                }







                //2스테이지
                if (this.gameObject.name == "Magazine02")
                {
                    theDM.ShowDialogue(this.dialogue);
                }
                if (this.gameObject.name == "Portrait")
                {
                    theDM.ShowDialogue(this.dialogue);
                }
                if (this.gameObject.name == "Stage_Start")
                {
                    theDM.ShowDialogue(this.dialogue);
                    isSadSound1 = true;
                }
                if (this.gameObject.name == "Fairy_tale_01")
                {
                    theDM.ShowDialogue(this.dialogue);
                }
                if(this.gameObject.name == "Fairy_tale_02")
                {
                    theDM.ShowDialogue(this.dialogue);
                }
                if(this.gameObject.name == "Fairy_tale_03")
                {
                    theDM.ShowDialogue(this.dialogue);
                }
                if (this.gameObject.name == "Portal_01")
                {
                    theDM.ShowDialogue(this.dialogue);
                    isMusicbox1 = true;
                    isPortal1 = true;
                }

                if (this.gameObject.name == "Fairy_tale_04")
                {
                    theDM.ShowDialogue(this.dialogue);
                }
                if (this.gameObject.name == "Fairy_tale_05")
                {
                    theDM.ShowDialogue(this.dialogue);
                }
                
                
                if (this.gameObject.name == "Portal_02")
                { 
                    theDM.ShowDialogue(this.dialogue);
                    isC_laugh = true;
                    isPortal2 = true;
                }



                if (this.gameObject.name == "Fairy_tale_06")
                {
                    theDM.ShowDialogue(this.dialogue);
                    // 6번째 책(2_4의 첫번째 책)을 읽는 순간 플레이어의 바디 타입을 고정(static)으로 변경해라===================================================
                    rb.bodyType = RigidbodyType2D.Static;


                }
                if (this.gameObject.name == "Fairy_tale_07")
                {
                    theDM.ShowDialogue(this.dialogue);
                }
                if (this.gameObject.name == "Portal_03")
                {
                    theDM.ShowDialogue(this.dialogue);
                    GameObject.Find("Portal_03").SetActive(false);
                }

                //2스테이지 트리거
                if (this.gameObject.name == "Door_close001")
                {
                    theDM.ShowDialogue(this.dialogue);
                    theAudio.Play(Door_Unlock);
                    isDoor_Unlock = true;
                }
                if(this.gameObject.name == "Door_close002")
                {
                    theDM.ShowDialogue(this.dialogue);
                    theAudio.Play(Door_Unlock);
                    isDoor_Unlock = true;
                }
                if (this.gameObject.name == "Door_close004")
                {
                    theDM.ShowDialogue(this.dialogue);
                    theAudio.Play(Door_Unlock);
                    isDoor_Unlock = true;
                }
                if (this.gameObject.name == "Door_close003")
                {
                    theDM.ShowDialogue(this.dialogue);
                    theAudio.Play(Door_Unlock);
                    isDoor_Unlock = true;
                }
                if (this.gameObject.name == "Lever_off")
                {
                    theDM.ShowDialogue(this.dialogue);
                    theAudio.Play(Door_Open);
                    GameObject.Find("Door_close001").SetActive(false);
                }
                if (this.gameObject.name == "Lever_off3")
                {
                    theDM.ShowDialogue(this.dialogue);
                    theAudio.Play(Door_Open);
                    GameObject.Find("Door_close002").SetActive(false);
                }
                if (this.gameObject.name == "Lever_off4")
                {
                    theDM.ShowDialogue(this.dialogue);
                    theAudio.Play(Door_Open);
                    GameObject.Find("Door_close004").SetActive(false);
                }
                if (this.gameObject.name == "LostMemory1")
                {
                    theDM.ShowDialogue(this.dialogue);

                }
                if (this.gameObject.name == "LostMemory2")
                {
                    theDM.ShowDialogue(this.dialogue);

                }
                if (this.gameObject.name == "LostMemory3")
                {
                    theDM.ShowDialogue(this.dialogue);

                }
                if (this.gameObject.name == "LostMemory4")
                {
                    isDoor_Open = true;
                    theDM.ShowDialogue(this.dialogue);


                }
















                howManyTailkingWithThisObject++;
            }

            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Invoke("ColliderReactive", 5f); //2초 후 콜라이더를 재활성화


        }
    }



    public int howManyTailkingWithThisObject = 0;
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {

        }
    }
}