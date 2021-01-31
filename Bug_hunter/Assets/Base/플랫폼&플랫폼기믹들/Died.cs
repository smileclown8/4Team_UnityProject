using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Died : MonoBehaviour
{
    public GameObject PlayerStatusManager;
    public Transform PlayerRespawn_1_1;
    public GameObject Character;
    void Awake()
    {
        PlayerRespawn_1_1 = GameObject.Find("PlayerRespawn_1_1").transform;
        PlayerStatusManager = GameObject.Find("PlayerStatusManager");
        Character = GameObject.Find("player");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerStatusManager.GetComponent<PlayerStatusManager>().player_HP <= 0)
        {
            Character.transform.position
        = new Vector2(PlayerRespawn_1_1.position.x, PlayerRespawn_1_1.position.y);

            PlayerStatusManager.GetComponent<PlayerStatusManager>().player_HP = 100;
        }

    }
}
