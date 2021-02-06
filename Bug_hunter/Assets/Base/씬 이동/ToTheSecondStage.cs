using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTheSecondStage : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoved)
        {
            Invoke("MoveToSavePoint", 0.1f);
            isMoved = false;
        }
    }

    private bool isMoved = false;

    void MoveToSavePoint()
    {
        if (GameObject.Find("2_5SavePoint_Off") != null)
        {
            GameObject.Find("player").transform.position = GameObject.Find("2_5SavePoint_Off").transform.position;
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isMoved = true;
            SceneManager.LoadScene("2Stage_Map");          

        }
    }
}
