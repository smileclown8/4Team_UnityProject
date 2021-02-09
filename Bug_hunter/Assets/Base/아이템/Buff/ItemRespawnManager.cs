using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemRespawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("HPUP") == null && GameObject.Find("HPUP(Clone)") == null)
        {
            if (!isStartRespawn)
            {
                isStartRespawn = true;
                if(SceneManager.GetActiveScene().name == "FirstBossStage")
                {
                    Invoke("Respawn", 60);
                }
                if (SceneManager.GetActiveScene().name == "SecondBossStage")
                {
                    Invoke("Respawn", 40);
                }
            }
        }
    }

    private bool isStartRespawn = false;

    public GameObject Item;
    public GameObject ItemPos;



    void Respawn()
    {
        Item.GetComponent<HPBuff>().HPup = 25;
        Instantiate(Item, ItemPos.transform.position, ItemPos.transform.rotation);
        isStartRespawn = false;
    }
}
