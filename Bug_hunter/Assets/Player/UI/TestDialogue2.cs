using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestDialogue2 : MonoBehaviour
{
    [SerializeField]
    public Dialogue dialogue;

    private DialogueManager1 theDM;






    void Start()
    {
        theDM = FindObjectOfType<DialogueManager1>();
        theDM.ShowDialogue(this.dialogue);
    }
   
}