using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alpaca_RightController : MonoBehaviour
{

    private AudioManager theAudio;
    public string Wekk;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("SoundPlay", 0.2f);


        rigid = GetComponent<Rigidbody2D>();

        theAudio = FindObjectOfType<AudioManager>();

        Invoke("DestroyPattern", 10);
    }

    // Update is called once per frame
    void Update()
    {
        AlpacaMoveRight_To_Left();
        moveSpeed += 5;
    }

    void SoundPlay()
    {
        theAudio.Play(Wekk);

    }




    // ======================================================
    // 알파카, 우측에서 왼쪽으로 힘주기


    public Rigidbody2D rigid;

    public float moveSpeed;

    void AlpacaMoveRight_To_Left()
    {
        rigid.AddForce(Vector2.right * -1 * Time.deltaTime * moveSpeed, ForceMode2D.Impulse) ;

    }






    // ======================================================
    // 패턴이 생성되고 일정시간이 지나고 패턴이 파괴되어야함

    void DestroyPattern()
    {
        Destroy(this.gameObject);
    }

}
