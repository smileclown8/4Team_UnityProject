using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSentence : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] sentences;
    public Transform cahtTr;
    public GameObject chatBoxPrefab;

    private void Start()
    {
        Invoke("TalkNpc", 6f);
    }

    // Update is called once per frame
    public void TalkNpc()
    {
        GameObject go = Instantiate(chatBoxPrefab);
        go.GetComponent<ChatSystem>().Ondialogue(sentences, cahtTr);
        Invoke("TalkNpc", 6f);

    }
    /*
    private void OnMouseDown()
    {
        TalkNpc();
    }
    */
}
