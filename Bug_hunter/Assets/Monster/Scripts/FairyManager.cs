using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyManager : MonoBehaviour
{
    // 스탯
    [HideInInspector] public int hp = 25;
    int attack = 10;
    int defenseRate = 10;
    int dodgeRate = 10;
    int buffRate = 20;


    Animator animator;
    bool pushingAnimTrigger;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 밀어낼 때 애니메이션 바꾸기
        pushingAnimTrigger = GetComponentInChildren<FairyBounce>().pushing;
        if (pushingAnimTrigger)
            animator.SetBool("bomb", true);     // 밀어낼 때의 애니메이션 재생
        else
            animator.SetBool("bomb", false);


        // 사망하면 프리팹 파괴
        if (hp <= 0)
        {
            Destroy(gameObject);
        }

    }
}
