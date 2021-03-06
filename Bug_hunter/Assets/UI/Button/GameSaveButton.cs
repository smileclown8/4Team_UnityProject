﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSaveButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("player");
        PlayerStatusManager = GameObject.Find("PlayerStatusManager");
        SceneName = SceneManager.GetActiveScene().name;


    }

    public GameObject player;
    public GameObject PlayerStatusManager;
    public string SceneName;
    public void Save()
    {

        PlayerPrefs.SetString("SavedSceneName", SceneName);
        PlayerPrefs.SetFloat("PlayerHP", PlayerStatusManager.GetComponent<PlayerStatusManager>().player_HP);
        PlayerPrefs.SetFloat("PlayerMaxHP", PlayerStatusManager.GetComponent<PlayerStatusManager>().player_MaxHP);
        PlayerPrefs.SetFloat("JumpPower", PlayerStatusManager.GetComponent<PlayerStatusManager>().jumpPower);
        PlayerPrefs.SetInt("Skill_ID", PlayerStatusManager.GetComponent<PlayerStatusManager>().skill_ID);
        PlayerPrefs.SetFloat("PlayerRespawn_x", PlayerStatusManager.GetComponent<PlayerStatusManager>().PlayerRespawn_Pos.x);
        PlayerPrefs.SetFloat("PlayerRespawn_y", PlayerStatusManager.GetComponent<PlayerStatusManager>().PlayerRespawn_Pos.y);
        PlayerPrefs.SetFloat("PlayerPos_x", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerPos_y", player.transform.position.y);

        Debug.Log("저장됨");
    }
}
