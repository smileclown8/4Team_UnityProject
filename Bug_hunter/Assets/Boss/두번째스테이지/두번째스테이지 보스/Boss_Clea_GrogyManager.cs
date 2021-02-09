using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Clea_GrogyManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {

    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        Boss_Clea_Doll_Grogy_HP = GameObject.Find("Boss_Clea_StatusManager").GetComponent<Boss_Clea_StatusManager>().Boss_Clea_Doll_Grogy_HP;
        isGrogy();
    }

    public GameObject Boss_Clea_Doll;
    [SerializeField]
    public GameObject Boss_Clea_StatusManager;

    public float Boss_Clea_Doll_Grogy_HP;


    [SerializeField]
    public GameObject Boss_Clea_Grogy;

    [SerializeField]
    public GameObject Boss_Clea_Crying;


    public bool isBossGrogy;

    [SerializeField]
    public GameObject GrogyNoticeText;

    void isGrogy()
    {
        if (Boss_Clea_Doll != null)
        {
            if (!isBossGrogy && Boss_Clea_Doll_Grogy_HP < 0)
            {
                Debug.Log("그로기");
                GrogyNoticeText.SetActive(true);
                Boss_Clea_Grogy.SetActive(true);
                if (GameObject.Find("Boss_Clea_Doll") != null)
                {
                    Boss_Clea_Grogy.transform.position =
                       new Vector2(GameObject.Find("Boss_Clea_Doll").transform.position.x, GameObject.Find("Boss_Clea_Doll").transform.position.y + 4);
                }

                else if (GameObject.Find("Boss_Clea_Doll(Clone)") != null)
                {
                    Boss_Clea_Grogy.transform.position =
                       new Vector2(GameObject.Find("Boss_Clea_Doll(Clone)").transform.position.x, GameObject.Find("Boss_Clea_Doll(Clone)").transform.position.y + 4);
                }

                Boss_Clea_Crying.SetActive(true);
                Invoke("DestroyDoll", 0.01f);
               // Boss_Clea_Doll_Grogy_HP = GameObject.Find("Boss_Clea_StatusManager").GetComponent<Boss_Clea_StatusManager>().Boss_Clea_Doll_Grogy_MaxHP;
            }
        }
    }

    void DestroyDoll()
    {
        if (GameObject.Find("Boss_Clea_Doll") != null)
        {
            Destroy(GameObject.Find("Boss_Clea_Doll"));
        }

        else if (GameObject.Find("Boss_Clea_Doll(Clone)") != null)
        {
            Destroy(GameObject.Find("Boss_Clea_Doll(Clone)"));
        }

        Debug.Log("인형파괴");
    }





    
}
