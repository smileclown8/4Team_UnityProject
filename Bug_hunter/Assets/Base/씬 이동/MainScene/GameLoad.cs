using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoad : MonoBehaviour
{

    private AudioManager theAudio;
    public string ButtonClick;

    // Start is called before the first frame update
    void Start()
    {
        theAudio = FindObjectOfType<AudioManager>();
        DontDestroyOnLoad(this.gameObject);

        Invoke("Destroy", 20f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoved)
        {
            Invoke("playerMove", 0.001f);
            isMoved = false;
        }

    }

    public void LoadGameClick()
    {
        theAudio.Play(ButtonClick);

        Invoke("LoadGame", 0.5f);
    }

    public string tempSceneName;
    private Transform PlayerPos;
    public string SceneName;
    public GameObject PlayerStatusManager;

    public void LoadGame()
    {
        tempSceneName = PlayerPrefs.GetString("SavedSceneName");

        GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().player_HP
               = PlayerPrefs.GetFloat("PlayerHP");
        GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().player_MaxHP
       = PlayerPrefs.GetFloat("PlayerMaxHP");
        GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().jumpPower
= PlayerPrefs.GetFloat("JumpPower");
        GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().skill_ID
= PlayerPrefs.GetInt("Skill_ID");
        GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().PlayerRespawn_Pos.x
            = PlayerPrefs.GetFloat("PlayerRespawn_x");
        GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().PlayerRespawn_Pos.y
    = PlayerPrefs.GetFloat("PlayerRespawn_y");
        Debug.Log(SceneName);
        Debug.Log(GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().PlayerRespawn_Pos.x);

        isMoved = true; if (tempSceneName == "FirstBossStage")
        {
            SceneName = "1Stage_Map";
        }
        else if (tempSceneName == "SecondBossStage")
        {
            SceneName = "2Stage_Map";
        }
        else
        {
            SceneName = tempSceneName;
        }
        SceneManager.LoadScene(SceneName);
    
    }

    private bool isMoved = false;

    public void playerMove()
    {
        Debug.Log("이동");
        if (tempSceneName == "FirstBossStage")
        {
            if (GameObject.Find("SavePoint_1_5") != null)
            {
                GameObject.Find("player").transform.position = GameObject.Find("SavePoint_1_5").transform.position;
            }
        }
        else if (tempSceneName == "SecondBossStage")
        {
            if (GameObject.Find("2_5SavePoint_Off") != null)
            {
                GameObject.Find("player").transform.position = GameObject.Find("2_5SavePoint_Off").transform.position;
            }
        }
        else
        {
            GameObject.Find("player").transform.position
    = new Vector2( GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().PlayerRespawn_Pos.x
    , GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().PlayerRespawn_Pos.y);
        }
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}
