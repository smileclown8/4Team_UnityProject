using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostMemoryController : MonoBehaviour
{
    public int count;
    public GameObject target1;
    public GameObject target2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 4)
        {
            target1.SetActive(false);
            target2.SetActive(false);
        }
    }
}
