using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern1_CenterRotater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        rotSpeed = 180f;
    }

    public float rotSpeed;
    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Boss_Clea_Doll").GetComponent<Boss_Clea_Doll>().pattern1RotateStart)
            this.transform.Rotate(Vector3.forward, rotSpeed * Time.deltaTime);
    }
}
