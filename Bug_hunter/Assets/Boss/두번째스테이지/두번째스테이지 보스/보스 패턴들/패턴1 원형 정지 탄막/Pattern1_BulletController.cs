using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern1_BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(GameObject.Find("Pattern1_Parent").transform.rotation.z);
    }
}
