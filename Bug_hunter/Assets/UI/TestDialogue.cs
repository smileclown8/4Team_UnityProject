using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogue : MonoBehaviour
{
    [SerializeField]
    public Dialogue dialogue;

    private DialogueManager theDM;
    public GameObject targetObject;



    public bool isSavorTalkItemGet = false;

    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
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
                Destroy(GameObject.Find("Savor1"));

                targetObject.SetActive(true);
                GameObject.Find("Savor2").GetComponent<TestDialogue>().isSavorTalkItemGet = true;


            }
            if (this.gameObject.name == "Savor2")
            {
                if (isSavorTalkItemGet == true)
                {
                    theDM.ShowDialogue(this.dialogue);
                }
                
            }
            if (this.gameObject.name == "Bobgurut2")
            {
                theDM.ShowDialogue(this.dialogue);
            }
            if (this.gameObject.name == "Savor3")
            {
                theDM.ShowDialogue(this.dialogue);
            }

        }
    }
}