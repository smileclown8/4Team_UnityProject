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
        Boss_Clea_Doll_Grogy_HP = Boss_Clea_StatusManager.GetComponent<Boss_Clea_StatusManager>().Boss_Clea_Doll_Grogy_HP;
        isGrogy();
    }


    [SerializeField]
    public GameObject Boss_Clea_Doll;
    [SerializeField]
    public GameObject Boss_Clea_StatusManager;

    public float Boss_Clea_Doll_Grogy_HP;


    [SerializeField]
    public GameObject Boss_Clea_Grogy;

    [SerializeField]
    public GameObject Boss_Clea_Crying;


    public bool isBossGrogy;

    void isGrogy()
    {
        if(Boss_Clea_Doll_Grogy_HP < 0)
        {
            //Debug.Log("그로기");
            isBossGrogy = true;
            if (Boss_Clea_Doll != null)
            {
                Boss_Clea_Grogy.SetActive(true);
                Boss_Clea_Grogy.transform.position = Boss_Clea_Doll.transform.position;
                Boss_Clea_Crying.SetActive(true);
            }
            Invoke("DestroyDoll", 0.5f);
        }
    }

    void DestroyDoll()
    {
        Destroy(Boss_Clea_Doll);
    }





    
}
