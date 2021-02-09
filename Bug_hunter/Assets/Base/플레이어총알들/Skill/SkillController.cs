using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{


    GameObject PlayerStatusManager;

    void Awake()
    {
        PlayerStatusManager = GameObject.Find("PlayerStatusManager");
    }

    // Start is called before the first frame update
    void Start()
    {
        SkillSoundManager = FindObjectOfType<SkillSoundManager>();
        bulletPos = GameObject.Find("bulletPos"); //자식인 bulletPos 오브젝트를 찾아서 그 좌표값을 총알발사 좌표값으로 사용한다.

    }

    // Update is called once per frame
    void Update()
    {
        skill_ID = PlayerStatusManager.GetComponent<PlayerStatusManager>().skill_ID;

        if (Input.GetKey(KeyCode.F))
        {
            Shoot();
        }


        if(isShootButton == true)
        {
            Shoot();
        }

    }


    private SkillSoundManager SkillSoundManager;
    public string NormalBulletSound;
    public string tongtong;
    public string arrow;
    public string bomb;
    public string electro;
    public string fire;

    public void SoundPlay()
    {
        if(skill_ID == 0)
        {
            SkillSoundManager.Play(NormalBulletSound);
        }

        if (skill_ID == 1)
        {
            SkillSoundManager.Play(tongtong);
        }

        if (skill_ID == 2)
        {
            SkillSoundManager.Play(NormalBulletSound);
        }

        if (skill_ID == 3)
        {
            SkillSoundManager.Play(arrow);
        }

        if (skill_ID == 4)
        {
            SkillSoundManager.Play(bomb);
        }

        if (skill_ID == 5)
        {
            SkillSoundManager.Play(electro);
        }

        if (skill_ID == 6)
        {
            SkillSoundManager.Play(fire);
        }
    }


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
        switch (skill_ID)
        {
            // 기본 공격
            case 0:
                PlayerNormalShoot();
                break;
            // 탱탱볼
            case 1:
                ; PlayerSecondSkillShoot();
                break;
            // 산탄
            case 2:
                ; RandomBulletFire();
                break;
            // 화살
            case 3:
                ; ArrowSkillBulletFire();
                break;
            // 구름탄
            case 4:
                ; BombSkillFire();
                break;
            // 찌릿찌릿
            case 5:
                ; ElectroSkillFire();
                break;
            // 화염방사
            case 6:
                ; FireBulletSkill();
                break;

        }
    }


    



    public int skill_ID = 0; //초기값, 일반공격

    public GameObject NormalBullet;             // 0
    public GameObject SecondSkillBullet;        // 1
    public GameObject RandomBullet;             // 2
    public GameObject arrowSkillBullet;         // 3
    public GameObject BombSkill;                // 4
    public GameObject ElectroSkill;             // 5
    public GameObject FireSkill;                // 6

    public float coolTime_NormalShoot = 1;      // 0
    public float coolTime_SecondSKill = 1;      // 1
    public float coolTime_FirstSkill = 1;       // 2
    public float coolTime_arrowSkillBullet = 1; // 3
    public float coolTime_BombSkill = 1;        // 4
    public float coolTime_ElectroSkill = 1;     // 5
    public float coolTime_FireSkill = 1;        // 6

    public GameObject bulletPos;

    public Transform pos;
    public int coolTime = 1;
    private float curTime;



    //이거 그냥 여기에다가 소리넣으면되는거아닌가? 자고일어나서 넣어보기
    public void NormalBulletFire()
    {
        pos = bulletPos.transform;
        GameObject bullet = Instantiate(NormalBullet, pos.position, transform.rotation);
        bullet.GetComponent<BulletDamage>().damage = GameObject.Find("DamageManager").GetComponent<BulletDamage>().damage * 1.0f;
        Debug.Log(bullet.GetComponent<BulletDamage>().damage);

        curTime = coolTime * coolTime_SecondSKill;
        curTime -= Time.deltaTime;
    }

    public void PlayerNormalShoot() // 0
    {
        pos = bulletPos.transform;

        if (curTime <= 0)
        {
            NormalBulletFire();
            SkillSoundManager.Play(NormalBulletSound);

            curTime = coolTime * coolTime_NormalShoot;
        }
        curTime -= Time.deltaTime;
    }

    public void PlayerSecondSkillShoot() // 1
    //곡사포? 일단 대충넣어놈.
    {
        pos = bulletPos.transform;

        if (curTime <= 0)
        {
            GameObject bullet = Instantiate(SecondSkillBullet, pos.position, transform.rotation);
            bullet.GetComponent<BulletDamage>().damage = GameObject.Find("DamageManager").GetComponent<BulletDamage>().damage * 1.5f;
            Debug.Log(bullet.GetComponent<BulletDamage>().damage);

            curTime = coolTime * coolTime_SecondSKill;
            SkillSoundManager.Play(tongtong);

        }
        curTime -= Time.deltaTime;
    }

    public void RandomBulletFire() // 2     
    {
        if (curTime <= 0)
        {
            pos = bulletPos.transform;
            int random_BulletPOS_Y = Random.Range(-1, 1 + 1);
            Vector2 newBulletPos = new Vector2(pos.position.x, pos.position.y + random_BulletPOS_Y);

            GameObject bullet = Instantiate(RandomBullet, newBulletPos, transform.rotation);
            bullet.GetComponent<BulletDamage>().damage = GameObject.Find("DamageManager").GetComponent<BulletDamage>().damage * 1.0f;
            Debug.Log(bullet.GetComponent<BulletDamage>().damage);

            SkillSoundManager.Play(NormalBulletSound);

            curTime = coolTime * coolTime_FirstSkill;
        }
        curTime -= Time.deltaTime;
    }

    public void ArrowSkillBulletFire() // 3
    {
        if (curTime <= 0)
        {
            pos = bulletPos.transform;
            GameObject bullet = Instantiate(arrowSkillBullet, pos.position, transform.rotation);
            bullet.GetComponent<BulletDamage>().damage = GameObject.Find("DamageManager").GetComponent<BulletDamage>().damage * 1.2f;
            Debug.Log(bullet.GetComponent<BulletDamage>().damage);

            SkillSoundManager.Play(arrow);

            curTime = coolTime * coolTime_arrowSkillBullet;

        }
        curTime -= Time.deltaTime;
    }

    public void BombSkillFire() // 4
    {
        if (curTime <= 0)
        {
            pos = bulletPos.transform;
            int random_BulletPOS_Y = Random.Range(-2, 1 + 2);
            Vector2 newBulletPos = new Vector2(pos.position.x, pos.position.y + random_BulletPOS_Y);

            GameObject bullet = Instantiate(BombSkill, newBulletPos, transform.rotation);
            bullet.GetComponent<BulletDamage>().damage = GameObject.Find("DamageManager").GetComponent<BulletDamage>().damage * 1.5f;
            Debug.Log(bullet.GetComponent<BulletDamage>().damage);

            SkillSoundManager.Play(bomb);

            curTime = coolTime * coolTime_BombSkill;

        }
        curTime -= Time.deltaTime;
    }

    public void ElectroSkillFire() // 5
    {
        if (curTime <= 0)
        {
            pos = bulletPos.transform;
            int random_BulletPOS_Y = Random.Range(-2, 1 + 2);
            Vector2 newBulletPos = new Vector2(pos.position.x, pos.position.y + random_BulletPOS_Y);

            GameObject bullet = Instantiate(ElectroSkill, newBulletPos, transform.rotation);
            bullet.GetComponent<BulletDamage>().damage = GameObject.Find("DamageManager").GetComponent<BulletDamage>().damage * 1.7f;
            Debug.Log(bullet.GetComponent<BulletDamage>().damage);

            SkillSoundManager.Play(electro);

            curTime = coolTime * coolTime_ElectroSkill;

        }
        curTime -= Time.deltaTime;
    }

    void FireBulletSkill() // 6
    {
        if (curTime <= 0)
        {
            pos = bulletPos.transform;

            GameObject bullet = Instantiate(FireSkill, pos.position, transform.rotation);
            bullet.GetComponent<BulletDamage>().damage = GameObject.Find("DamageManager").GetComponent<BulletDamage>().damage * 1.8f;
            Debug.Log(bullet.GetComponent<BulletDamage>().damage);

            SkillSoundManager.Play(fire);

            curTime = coolTime * coolTime_FireSkill;

        }
        curTime -= Time.deltaTime;
    }
}
