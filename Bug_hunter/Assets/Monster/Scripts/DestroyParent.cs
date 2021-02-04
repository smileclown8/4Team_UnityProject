using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParent : MonoBehaviour
{
    float hp;

    void Start()
    {
        
    }

    void Update()
    {
        hp = GetComponentInChildren<MonsterStatusManager>().hp;

        // 체력 0 이하일 때 피격효과 내고 사라진다. (사라지는 건 부모오브젝트에서)
        if (hp <= 0)
        {
            Destroy(gameObject, 0.4f);      // 0.4초 뒤에 사라짐
        }
    }
}
