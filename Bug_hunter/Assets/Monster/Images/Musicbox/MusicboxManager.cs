using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicboxManager : MonoBehaviour
{
    // 스탯
    public int hp = 40;
    public int attack = 10;
    public int defense = 15;
    int buffRate = 40;

    bool isTracing;     // 플레이어 인식용
    GameObject target;
    Transform myPos;
    public float forceFactor = 20;

    //Animator anim;

    void Start()
    {
        myPos = GetComponent<Transform>();
    }

    void Update()
    {
        target = GameObject.FindWithTag("Player");
        isTracing = GetComponentInChildren<RecognitionManager>().isTracing;
    }

    void FixedUpdate()
    {
        if (isTracing && target.gameObject.tag == "Player")
        {
        }
    }

}
