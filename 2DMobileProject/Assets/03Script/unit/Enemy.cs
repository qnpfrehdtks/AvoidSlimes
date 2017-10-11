using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BOSS
{
    NONE,
    BOSS1,
    BOSS2,

    BOSS3,
    BOSS4,

    BOSS5,
    BOSS6,

    BOSS7


}

public class Enemy : Mover {


    public BOSS m_eBoss { get; private set; }

    // ====================================================================
    //           기본적인 능력치나 시작 위치를 초기화하는 함수 부분.
    // ===================================================================
    public override void Init(float speed, Vector3 pos, Vector3 vScale, Quaternion rot, MoverType type)
    {
        base.Init(speed, pos, vScale, rot, type);
    }

    // ====================================================================
    //    이벤트 진행 함수이다. 이 함수가 끝나면 공격을 시작하십다. 좀더 보완
    // ===================================================================
    public void StartEvent(float StartWaitTime, BOSS boss)
    {
        m_eBoss = boss;
        StartCoroutine(PatternStart(StartWaitTime));
    }


    IEnumerator PatternStart(float StartWaitTime)
    {
        PatternSetting(m_eBoss);
        yield return new WaitForSeconds(StartWaitTime);
        PatternStart();
    }

 

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        EnemyMGR.Instance.GetDamage(15, collision.gameObject);
    }


}
