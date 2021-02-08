using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clea_2Stage_2_MovieStarter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PrepareVideo();
        Invoke("ShowVideo", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("CloseVideo", 36);
    }

    public GameObject Movie1;
    public GameObject Screen;
    public GameObject BlackScreen;
    public GameObject SkipButton;

    public void ShowVideo()
    {
        BlackScreen.SetActive(false);
    }

    public void PrepareVideo()
    {
        BlackScreen.SetActive(true);
        Screen.SetActive(true);
        Movie1.SetActive(true);
    }


    public void CloseVideo()
    {
        if (Screen != null)
        {
            Screen.SetActive(false);
        }

        if (Movie1 != null)
        {
            Movie1.SetActive(false);
        }
    }

}
