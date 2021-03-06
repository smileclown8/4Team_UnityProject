﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //플레이어의 이동, 점프, 점프공격, 총발싸등 온갖 활동을 다 관장하는 컨트롤러
    //기능중 일부를 따로 빼서 따로 컨트롤러스크립트를 만들어도 된다.
    // -> 01.25 수정 : 각 스테이터스값들을 PlayerStatusManager로 이관
    // ====로 기능별로 구분해놨음
    // == 구분별로 변수가 따로 설정되어있기때문에, 변수가 위에만 있는게 아니라 곳곳에 있으니 잘 확인하세요




    public Rigidbody2D playerRigidbody2D;
    SpriteRenderer spriteRenderer;

    public Animator anim;
    public AudioSource audioSource;
    public AudioClip running;
    public AudioClip jumping;
    public AudioClip damaged;
    public AudioClip death;

    public bool printingScripts;



    //플레이어의 최대 이동속도
    public float maxMoveSpeed;

    //이름은 moveSpeed로 했지만, 실제로는 플레이어가 이동(좌,우)할때 받는 힘의 양을 조절해줌
    //클수록 maxMoveSpeed에 도달하는 시간이 짧아짐. 자동차의 제로백이라고 생각하면 된다.
    //값이 클수록 이동이 부드러워지는걸 확인. 60정도를 추천
    public float moveSpeed;





    //플레이어가 점프중인가를 확인해주는 bool 변수
    //점프중에는 다시 점프를 못하게 막아준다.
    public bool isJumping = false;

    //PlayerStatusManager의 jumpPower값을 읽어옴
    public float jumpPower;
    public GameObject PlayerStatusManager;

    public GameObject Dialogue;
    public bool isTalk;

    GameObject tilemap;
    Renderer tileColor;
    GameObject tilemap2;
    Renderer tileColor2;

    void Awake()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        PlayerStatusManager = GameObject.Find("PlayerStatusManager");
        jumpPower = PlayerStatusManager.GetComponent<PlayerStatusManager>().jumpPower;
        Dialogue = GameObject.Find("UI_Dialogue");
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }



    void Start()
    {
        // bulletPos = GameObject.Find("bulletPos"); //자식인 bulletPos 오브젝트를 찾아서 그 좌표값을 총알발사 좌표값으로 사용한다.
        tilemap = GameObject.Find("Tilemap1_2_1");
        if (tilemap != null)
        {
            tileColor = tilemap.GetComponent<Renderer>();
        }

        tilemap2 = GameObject.Find("Tilemap1_4_1");

        if (tilemap2 != null)
        {
            tileColor2 = tilemap2.GetComponent<Renderer>();
        }

    }

    void Update()
    {
       // skill_ID = PlayerStatusManager.GetComponent<PlayerStatusManager>().skill_ID;
        isTalk = Dialogue.GetComponent<DialogueManager>().talking;



        //터치가 아닐 때
        //   Jump();
        //   Land();

    
   
        // 터치일 때
       // Jump();
        Land();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

    }


    public void Jump() //플레이어 점프
    {
        if (
           // Input.GetKeyDown(KeyCode.Space)&& //터치가 아닐때, 터치라면 이 줄을 주석처리하기
            !isJumping && isTalk==false) // 
        {
            playerRigidbody2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            playerRigidbody2D.AddForce(Vector2.right * this.playerRigidbody2D.velocity.x * 0.5f, ForceMode2D.Impulse);
            //플레이어가 대각선으로 점프할때, 너무 앞으로 나아가는 힘이 없어서 좀 더 앞으로 밀어줌
            isJumping = true;

            // 점프 애니메이션과 사운드
            anim.SetBool("isJumping", true);
            audioSource.volume = 0.6f;
            audioSource.clip = jumping;
            audioSource.Play();
        }

        if (playerRigidbody2D.velocity.y > 40.0f)
        {
            playerRigidbody2D.AddForce(Vector2.down * jumpPower / 5, ForceMode2D.Impulse);
        }
        // 플레이어가 점프힘을 지나치게 많이받아서 하늘로 날아가고 그러길래, 플레이어의 점프속도가 어느 정도를 넘어가면 강제로
        // 아래로 내려꽂히는 힘을 추가로 가해줌.

    }


    public LayerMask isLayer;
    public void Land() //플레이어 착륙 감지 함수. 이 함수 때문에 레이어설정이 중요하다
    {
        if (playerRigidbody2D.velocity.y <= 0)
        {
            Debug.DrawRay(playerRigidbody2D.position, Vector3.down, new Color(0, 1, 0));

            RaycastHit2D rayHit = Physics2D.Raycast(playerRigidbody2D.position, Vector3.down
                , 100, isLayer);  // 점프가 가능한 오브젝트의 레이어를 플레이어의 인스펙터의 isLayer 항목에서 설정해줘야 합니다.

            if (rayHit.collider != null)
            {
                if (rayHit.distance < 2f) // 플레이어의 중심에서 발끝까지의 거리(플레이어절반크기) 즉, 바닥에 닿았으면
                {
                    isJumping = false;

                    // 착지 애니메이션
                    anim.SetBool("isJumping",false);
                }
            }
        }

    }


    // ==================================================================================================
    // 여기서부터 플레이어 + 오브젝트 충돌
    void OnCollisionEnter2D(Collision2D collision)   // 이 스크립트가 들어가있는 오브젝트가 콜라이더를 가지고 있는 무언가와 충돌했을때 실행됨
    {
      if(collision.gameObject.tag == "Enemy")  // tag가 Enemy인것과 충돌할때.
                                               // 현재 까시와 몬스터가 모두 태그를 Enemy로 했음.
                                               // 까시를 따로 태그 설정한다면
                                               // if(collision.gameObject.tag =="까시"){ OnDamaged( ... ) } 이런 내용을 추가해야함
        {
            // 몬스터 밟기
            if (this.transform.position.y > collision.transform.position.y) //몬스터와 충돌할때, 몬스터 위에서 충돌하면.
            {
                OnJumpAttack(collision.transform);  //점프 어택을 하고,
            }
            else
            {
                // 피격 사운드
                audioSource.Stop();
                audioSource.volume = 1;
                audioSource.clip = damaged;
                audioSource.Play();

                OnDamaged(collision.transform.position,8);  // 만약 몬스터 위가 아닌곳에서 몬스터와 충돌하면 데미지를 입는다.
            }
        }
        if (collision.gameObject.tag == "Gimik")  // tag가 Gimik인것과 충돌할때.
                                                  // if(collision.gameObject.tag =="Gimik"){ OnDamaged( ... ) } 이런 내용을 추가해야함
        {
            // 피격 사운드
            audioSource.Stop();
            audioSource.volume = 1;
            audioSource.clip = damaged;
            audioSource.Play();

            OnDamaged(collision.transform.position,8);  
        }
        
        if(collision.gameObject.tag == "EnemyAttack")
        {
            // 피격 사운드
            audioSource.Stop();
            audioSource.volume = 1;
            audioSource.clip = damaged;
            audioSource.Play();

            OnDamaged(collision.transform.position,8);

        }

        if (collision.gameObject.tag == "Staff")
        {
            OnDamaged(collision.transform.position, 40);
        }
    }


    void OnJumpAttack(Transform monster)  // 아직 미완성부분
    {
        //Point


        isJumping = false;
        playerRigidbody2D.AddForce(Vector2.up * 15, ForceMode2D.Impulse); // 밟았을때 통~ 하고 튀게 위로 힘을 준다.

        //Enemy Die
        if(monster.gameObject.name != "Bat" &&
           monster.gameObject.name != "Ghost" &&
           monster.gameObject.name != "Musicbox"
           /*몬스터 '이슬라프의 망령' 추가 시 + && monster.gameObject.name != "PhantomEslaf"*/ )
        monster.GetComponent<MonsterStatusManager>().hp = 0;


        // BE2 6분대 근처 참고하면서 마저작성하기
    }
    void OnDamaged(Vector2 targetPos, float KnockBackPower) //메이플마냥 데미지를 받으면 뒤로 약간 밀려나고 투명해지며 몬스터를 통과하게 함
    {
        if(PlayerStatusManager.GetComponent<PlayerStatusManager>().player_HP > 0)
        {
            //피격시 PlayerDamaged로 플레이어의 레이어 변화
            this.gameObject.layer = 10; // 레이어 PlayerDamaged 가 들어가있는 레이어 번호

            //피격당하면 색변화(투명도를 변화시킴)
            this.spriteRenderer.color = new Color(1, 1, 1, 0.4f);

            // 피격당했을때 튕겨나가는거
            int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;  //몬스터에게 피격당해서 날아갈 방향
            isJumping = true;
            playerRigidbody2D.AddForce(new Vector2(dirc, 1) * KnockBackPower, ForceMode2D.Impulse);

            Invoke("OffDamaged", 2); //레이어와 투명해진거를 원상복귀
        }
        else if (PlayerStatusManager.GetComponent<PlayerStatusManager>().player_HP <= 0)
        {
            
        }

    }
    public bool isDead = false;
    
    void OffDamaged() //원상복귀
    {
        this.gameObject.layer = 9; // 레이어 Player가 들어가있는 레이어 번호
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    // Trigger 타입의 콜라이더와 충돌이 발생하면 충돌이 발생한 오브젝트의
    // Collider 정보가 넘어온다.
    // Trigger 를 사용할 때는 Collider 타입으로 매개변수를 받음
    {
        if (collision.gameObject.tag == "Tile")
        {
            tileColor.material.color = new Color(1f, 1f, 1f, 0.2f);
        }
        if (collision.gameObject.tag == "Tile_off")
        {
            tileColor.material.color = new Color(1f, 1f, 1f, 1f);
        }

        if (collision.gameObject.tag == "Tile1_4on")
        {
            tileColor2.material.color = new Color(1f, 1f, 1f, 0.2f);
        }

        if (collision.gameObject.tag == "Tile1_4off")
        {
            tileColor2.material.color = new Color(1f, 1f, 1f, 1f);
        }

        if (collision.gameObject.tag == "Story")
        {
            printingScripts = true;
            GameObject.Find("StageBGM").GetComponent<AudioSource>().volume = 0.1f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Story")
        {
            printingScripts = false;
            if (GameObject.Find("StageBGM").GetComponent<AudioSource>().volume != 1)
                GameObject.Find("StageBGM").GetComponent<AudioSource>().volume = 1;
        }
    }


    /* 이 부분을 SkillController로 이관함.
    // =======================================================================================
    // 여기서부터 플레이어 슈팅



    public bool isShootButton = false;

    public void ShootButtonDown()
    {
        isShootButton = true;
    }

    public void ShootButtonUp()
    {
        isShootButton = false;
    }


    public void Shoot()
    {
        if (Input.GetKey(KeyCode.F)) // 터치가 아닐 때

        //    if(isShootButton) //터치일 때 
        {

            switch (skill_ID)
            {
                case 0:
                    PlayerNormalShoot();
                    break;
                case 1:
                    PlayerFirstSkillShoot();
                    break;
                case 2:
                    PlayerSecondSkillShoot();
                    break;

            }

        }
    }


    public int skill_ID; //초기값, 일반공격

    public GameObject NormalBullet; // 일반 공격의 bullet(탄환,투사체). 
    public GameObject FirstSkillBullet; // 첫번째 스킬의 bullet
    public GameObject SecondSkillBullet; // 두번째스킬의 bullet.

    public GameObject bulletPos;
    //bulletPos도 ShootPos로 이름 바꿔야함
    public Transform pos;

    public float coolTime;

    //나중에 밸런싱할때 각각의 공격마다의 쿨타임을 따로 정해주고,
    // 각 공격마다의 쿨타임을 다시, 플레이어 자체의 공격쿨타임(coolTime)과 곱해준다.
    // 왜그러냐면, 공격속도 강화 아이템을 먹었을때 coolTime을 강화시켜주면 (실제론 coolTIme의 값이 작아질것)
    //모든 스킬의 공격속도가 빨라지게됨
    public float coolTime_NormalShoot = 1;
    public float coolTime_FirstSkill = 1;
    public float coolTime_SecondSKill= 1;
    //임시로 모두 초기값을 1로 통일

    private float curTime;

    //bullet의 이름과 해당 총알의 스크립트이름도 바꿔야함
    public void PlayerNormalShoot()
    {
        pos = bulletPos.transform;

        if (curTime <= 0)
        {
            Instantiate(NormalBullet, pos.position, transform.rotation);
            curTime = coolTime * coolTime_NormalShoot;
        }
        curTime -= Time.deltaTime;
    }
    public void PlayerFirstSkillShoot()
    {
        pos = bulletPos.transform;

        if (curTime <= 0)
        {
            Instantiate(FirstSkillBullet, pos.position, transform.rotation);
            curTime = coolTime * coolTime_FirstSkill;
        }
        curTime -= Time.deltaTime;
    }

    public void PlayerSecondSkillShoot()
        //곡사포? 일단 대충넣어놈.
    {
        pos = bulletPos.transform;

        if (curTime <= 0)
        {
            Instantiate(SecondSkillBullet, pos.position, transform.rotation);
            curTime = coolTime * coolTime_SecondSKill;
        }
        curTime -= Time.deltaTime;
    }

    */

}
