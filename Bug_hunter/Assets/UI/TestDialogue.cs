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

    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
    }

    public bool isTalkWithBook = false;
    public bool isBobgurut2 = false;
    public bool isSavorBomb = false;

    private void Update()
    {
        if (this.gameObject.name == "Savor2")
        {
            Destroy(GameObject.Find("Savor1_Chatbox(Clone)"));
        }
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
                    isBobgurut2 = true; //사운드이펙트 출력할 때
                }
                if (this.gameObject.name == "Savor3")
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
                if (this.gameObject.name == "2_1stage_01")
                {
                    theDM.ShowDialogue(this.dialogue);
                }
                if(this.gameObject.name == "Fairy_tale01")
                {
                    theDM.ShowDialogue(this.dialogue);
                }










                howManyTailkingWithThisObject++;
            }
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