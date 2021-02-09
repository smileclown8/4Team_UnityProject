using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    // Start is called before the first frame update
   
    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    
    }


    public void Close()
    {
        StartCoroutine(CloseAfterDelay());
    }

    private IEnumerator CloseAfterDelay()
    {
        animator.SetTrigger("close");
        yield return new WaitForSeconds(0.2f); //클로즈 버튼 짱 느려서 화남
        gameObject.SetActive(false);
        animator.ResetTrigger("close");
    }
}


