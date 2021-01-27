using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Died : MonoBehaviour
{

    public Transform PlayerRespawn_1_1;

    void Awake()
    {
        PlayerRespawn_1_1 = GameObject.Find("PlayerRespawn_1_1").transform;
        PlayerStatusManager player_Hp = GameObject.Find("Player").GetComponent<PlayerStatusManager>();
      

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
