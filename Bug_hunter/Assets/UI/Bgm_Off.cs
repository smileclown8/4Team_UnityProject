using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgm_Off : MonoBehaviour
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
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            BGM.Stop();
            //this.gameObject.SetActive(false);
        }
    }
}
