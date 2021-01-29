using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        bulletPos = GameObject.Find("bulletPos"); //자식인 bulletPos 오브젝트를 찾아서 그 좌표값을 총알발사 좌표값으로 사용한다.

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F)) // 유니티내에서 
                                     //테스트용으로 버튼대신 키입력받기. 나중에는 update에서 Jump()와 Shoot을하는게 아니라 따로 버튼입력 받을거임
                                     //즉, Update문은 Land를 제외하고 싹 비워버릴꺼니 신경ㄴㄴ
        {
            switch (skill_ID)
            {
                // 기본 공격
                case 0:
                    PlayerNormalShoot();
                    break;
                // 빠른 공격
                case 1:
                    PlayerFirstSkillShoot();
                    break;
                // 탱탱볼
                case 2:
                    ; PlayerSecondSkillShoot();
                    break;
                // 산탄
                case 3:
                    ; RandomBulletFire();
                    break;
                // 화살
                case 4:
                    ; ArrowSkillBulletFire();
                    break;
                // 구름탄
                case 5:
                    ; BombSkillFire();
                    break;
                // 찌릿찌릿
                case 6:
                    ; ElectroSkillFire();
                    break;
                case 7:
                    ; FireBulletSkill();
                    break;

            }
        }
    }

    public int skill_ID = 0; //초기값, 일반공격

    public GameObject NormalBullet; // 일반 공격의 bullet(탄환,투사체). 
    public GameObject FirstSkillBullet; // 첫번째 스킬의 bullet
    public GameObject SecondSkillBullet; // 두번째스킬의 bullet.

    public GameObject arrowSkillBullet;
    public GameObject BombSkill;
    public GameObject ElectroSkill;
    public GameObject FireSkill;

    public float coolTime_NormalShoot = 1;
    public float coolTime_FirstSkill = 1;
    public float coolTime_SecondSKill = 1;
    public float coolTime_arrowSkillBullet = 1;
    public float coolTime_BombSkill = 1;
    public float coolTime_ElectroSkill = 1;
    public float coolTime_FireSkill = 1;

    public GameObject bulletPos;

    public Transform pos;
    public float coolTime;
    private float curTime;


    public void PlayerNormalShoot()
    {
        pos = bulletPos.transform;

        if (curTime <= 0)
        {
            NormalBulletFire();
            curTime = coolTime * coolTime_NormalShoot;
        }
        curTime -= Time.deltaTime;
    }


    public float continousFireSpeed = 0.05f;
    public void PlayerFirstSkillShoot()
    {
        pos = bulletPos.transform;

        if (curTime <= 0)
        {
            Invoke("NormalBulletFire", continousFireSpeed);
            Invoke("NormalBulletFire", 2 * continousFireSpeed);
            Invoke("NormalBulletFire", 3 * continousFireSpeed);
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


    public void NormalBulletFire()
    {
        pos = bulletPos.transform;
        Instantiate(NormalBullet, pos.position, transform.rotation);
    }

    public void RandomBulletFire()
    {
        pos = bulletPos.transform;
        int random_BulletPOS_Y = Random.Range(-1, 1 + 1);
        Vector2 newBulletPos = new Vector2(pos.position.x, pos.position.y + random_BulletPOS_Y);

        Instantiate(NormalBullet, newBulletPos, transform.rotation);


    }

    public void ArrowSkillBulletFire()
    {
        pos = bulletPos.transform;
        Instantiate(arrowSkillBullet, pos.position, transform.rotation);
        curTime = coolTime * coolTime_arrowSkillBullet;

    }

    public void BombSkillFire()
    {
        pos = bulletPos.transform;
        int random_BulletPOS_Y = Random.Range(-2, 1 + 2);
        Vector2 newBulletPos = new Vector2(pos.position.x, pos.position.y + random_BulletPOS_Y);

        Instantiate(BombSkill, newBulletPos, transform.rotation);
        curTime = coolTime * coolTime_BombSkill;

    }

    public void ElectroSkillFire()
    {
        pos = bulletPos.transform;
        int random_BulletPOS_Y = Random.Range(-2, 1 + 2);
        Vector2 newBulletPos = new Vector2(pos.position.x, pos.position.y + random_BulletPOS_Y);

        Instantiate(ElectroSkill, newBulletPos, transform.rotation);
        curTime = coolTime * coolTime_ElectroSkill;

    }

    void FireBulletSkill()
    {
        pos = bulletPos.transform;

        Instantiate(FireSkill, pos.position, transform.rotation);
        curTime = coolTime * coolTime_FireSkill;

    }

}
