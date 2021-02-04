using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    public GameObject Menu_Set;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void De_ActviateMenu_Set()
    {
        Continue();
        Menu_Set.SetActive(false);
    }

    void Continue()
    {
        Time.timeScale = 1;
    }

}
