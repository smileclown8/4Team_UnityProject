using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Start : MonoBehaviour
{

    private AudioManager theAudio;
    public string ButtonClick;
    // Start is called before the first frame update
    void Start()
    {
        theAudio = FindObjectOfType<AudioManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void New_Start()
    {
        theAudio.Play(ButtonClick);
        Invoke("SceneMove", 1f);
    }

    public void SceneMove()
    {
        SceneManager.LoadScene("0Stage_Map");   
    }
}
