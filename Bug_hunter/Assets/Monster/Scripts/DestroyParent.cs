using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParent : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        // 체력 0 이하일 때 피격효과 내고 사라진다. (사라지는 건 부모오브젝트에서)
        if (GetComponentInChildren<MonsterStatusManager>().hp <= 0)
        {
            Destroy(gameObject, 1.5f);      // 1.5초 뒤에 사라짐
        }
    }
}
