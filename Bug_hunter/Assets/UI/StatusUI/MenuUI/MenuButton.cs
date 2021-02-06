using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
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

    public void ActviateMenu_Set()
    {
        Pause();
        Menu_Set.SetActive(true);
    }

    void Pause()
    {
        Time.timeScale = 0;
    }
}
