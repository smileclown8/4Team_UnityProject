using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgm_On : MonoBehaviour
{
    BGMManager BGM;
    public int playMusicTrack;
    // Start is called before the first frame update
    void Start()
    {
        BGM = FindObjectOfType<BGMManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            BGM.Play(playMusicTrack);
            BGM.SetVolumn(0.2f);
        }
    }
}
