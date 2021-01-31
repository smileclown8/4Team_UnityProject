﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public Queue<string> sentences;
    public string currentSentence;
    public TextMeshPro text;
    public GameObject quad;




    public void Ondialogue(string[] lines, Transform chatPoint)
    {
        transform.position = chatPoint.position;
        sentences = new Queue<string>();
        sentences.Clear();
        foreach (var line in lines)
        {
            sentences.Enqueue(line);
        }
        StartCoroutine(DialogueFlow(chatPoint));



    }

    IEnumerator DialogueFlow(Transform chatPoint)
    {
        yield return null;
        while (sentences.Count > 0)

        {
            currentSentence = sentences.Dequeue();
            text.text = currentSentence;
            float x = text.preferredWidth;
            x = (x > 6) ? 6 : x + 0.3f;
            quad.transform.localScale = new Vector2(x, text.preferredHeight + 0.3f);

            transform.position = new Vector2(chatPoint.position.x, chatPoint.position.y + text.preferredHeight / 2);
            yield return new WaitForSeconds(3f); //3초를 대기하고 계속 진행

        }
        Destroy(gameObject);
    }

}
