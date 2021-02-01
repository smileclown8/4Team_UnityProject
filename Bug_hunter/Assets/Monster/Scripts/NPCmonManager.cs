using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCmonManager : MonoBehaviour
{
    // 스탯
    public int hp = 30;
    public int attack = 4;
    int buffRate = 30;

    Animator anim;
    SpriteRenderer spriteRenderer;

    [SerializeField] float shoottime;       // 발사시간
    [SerializeField] float nextshoot;       // 쿨타임



    void Start()
    {
        anim = GetComponent<Animator>();
        nextshoot = 2;
    }

    void Update()
    {
        
    }
}
