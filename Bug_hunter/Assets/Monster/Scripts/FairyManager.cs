using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyManager : MonoBehaviour
{
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
    }
}
