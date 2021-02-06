using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHideController : MonoBehaviour
{

    public GameObject Dialogue;
    // Start is called before the first frame update
    void Start()
    {
        Dialogue = GameObject.Find("UI_Dialogue");
    }

    // Update is called once per frame
    void Update()
    {
        if (Dialogue.GetComponent<DialogueManager>().talking)
        {
            if (this.gameObject.GetComponent<Image>() != null)
            {
                this.gameObject.GetComponent<Image>().color = new Color(this.gameObject.GetComponent<Image>().color.r, this.gameObject.GetComponent<Image>().color.g
                , this.gameObject.GetComponent<Image>().color.b, 0);
            }

            if(this.gameObject.GetComponent<Text>() != null)
            {
                this.gameObject.GetComponent<Text>().color = new Color(this.gameObject.GetComponent<Text>().color.r, this.gameObject.GetComponent<Text>().color.g
, this.gameObject.GetComponent<Text>().color.b, 0);
            }
        }


        if (!Dialogue.GetComponent<DialogueManager>().talking)
        {
            if (this.gameObject.name == "Jump" || this.gameObject.name == "Shoot"
                || this.gameObject.name == "HpBar")
            {
                this.gameObject.GetComponent<Image>().color = new Color(this.gameObject.GetComponent<Image>().color.r, this.gameObject.GetComponent<Image>().color.g
, this.gameObject.GetComponent<Image>().color.b, 1);
            }

            else //조이스틱
            {
                if (this.gameObject.GetComponent<Image>() != null)
                {
                    this.gameObject.GetComponent<Image>().color = new Color(this.gameObject.GetComponent<Image>().color.r, this.gameObject.GetComponent<Image>().color.g
            , this.gameObject.GetComponent<Image>().color.b, this.gameObject.GetComponent<Image>().color.a);//수정하기
                }


                if (this.gameObject.GetComponent<Text>() != null)
                {
                    this.gameObject.GetComponent<Text>().color = new Color(this.gameObject.GetComponent<Text>().color.r, this.gameObject.GetComponent<Text>().color.g
    , this.gameObject.GetComponent<Text>().color.b, 1);
                }
            }
        }
    }
}
