using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject Movie1;
    public GameObject Screen;

    public void Skip()
    {
        Screen.SetActive(false);
        Movie1.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
