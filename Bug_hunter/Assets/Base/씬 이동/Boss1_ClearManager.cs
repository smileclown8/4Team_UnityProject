using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss1_ClearManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(GameObject.Find("Boss_CORE") != null)
        {
        if(GameObject.Find("Boss_CORE").GetComponent<Boss_IF_CORE_Controller>().Boss_IF_HP <= 0)
            {
                Debug.Log("클리어");
                Boss1_Clear();
            }    
        }


      //  Debug.Log(GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().PlayerRespawn_Pos);
    }

    void Boss1_Clear()
    {
        SceneManager.LoadScene("2Stage_Map");
    }
}
