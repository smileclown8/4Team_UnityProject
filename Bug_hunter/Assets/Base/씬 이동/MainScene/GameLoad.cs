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

    private Transform PlayerPos;
    public string SceneName;
    public GameObject PlayerStatusManager;

    public void LoadGame()
    {
        SceneName = PlayerPrefs.GetString("SavedSceneName");

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

        isMoved = true;
        SceneManager.LoadScene(SceneName);
    
    }

    private bool isMoved = false;

    public void playerMove()
    {
        Debug.Log("이동");
        GameObject.Find("player").transform.position
    = new Vector2( GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().PlayerRespawn_Pos.x
    , GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().PlayerRespawn_Pos.y);
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}
