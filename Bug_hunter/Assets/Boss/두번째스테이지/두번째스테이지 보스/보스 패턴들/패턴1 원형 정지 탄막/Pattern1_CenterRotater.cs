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

    public Transform initRotation;
    public float rotSpeed;
    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Boss_Clea_Doll") != null)
        {
            if (GameObject.Find("Boss_Clea_Doll").GetComponent<Boss_Clea_Doll>().pattern1RotateStart)
                this.transform.Rotate(Vector3.forward, rotSpeed * Time.deltaTime);

            else
            {
                this.transform.rotation = Quaternion.Euler(0, 0, -2.617f);
            }
        }

        if(GameObject.Find("Boss_Clea_Doll(Clone)") != null)
        {
            if (GameObject.Find("Boss_Clea_Doll(Clone)").GetComponent<Boss_Clea_Doll>().pattern1RotateStart)
                this.transform.Rotate(Vector3.forward, rotSpeed * Time.deltaTime);

            else
            {
                this.transform.rotation = Quaternion.Euler(0, 0, -2.617f);
            }
        }
    }
}
