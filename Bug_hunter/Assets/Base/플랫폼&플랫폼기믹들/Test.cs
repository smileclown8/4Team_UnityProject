using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject A;

    public Image B;

   public Sprite C;
    
    // Update is called once per frame
    void Update()
    {
        A.GetComponent<Image>().sprite = C;
    }
}
