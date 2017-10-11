using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MoverType
{
    Player,
    BOSS,
    Bullet,
    SummonedBullet,
}


public abstract class Mover : MonoBehaviour {


    public bool m_isCanActive { get; set; }
    public MoverType m_eType { get; protected set; }
    public Stat m_sStat { get; protected set; }

    protected InputController m_cInputController;
    protected PatternController m_PatternContorller;

    protected bool m_isEvent;
    protected int m_MaxPatternLevel;
    protected int m_CurPatternLevel;

    protected SpriteRenderer m_stSpriteResource;

    public float m_fSpeed { get;  set; }
    public float m_fAngle { get;  set; }


    public virtual void Init()
    {

    }

    // ====================================================================
    //           기본적인 능력치나 시작 위치를 초기화하는 함수 부분.
    // ===================================================================
    public virtual void Init(float speed, Vector3 pos, Vector3 vScale,Quaternion rot, MoverType type)
    {
        m_eType = type;
        gameObject.transform.position = pos;
        gameObject.transform.rotation = rot;
        gameObject.transform.localScale = vScale;
        m_fSpeed = speed;
        m_isCanActive = false;
    }


    // ====================================================================
    //     패턴을 진행합시다. 패턴은 보스가 가진 패턴 컨트롤러에 의해 관리됨.
    // ====================================================================
    protected void PatternSetting(BOSS boss)
    {
        if (!m_PatternContorller)
        {
            m_PatternContorller = gameObject.AddComponent<PatternController>();
        }
            // 공격 패턴 시작.
            m_PatternContorller.SetPattern(this ,boss);
    }

    protected void PatternStart()
    {
        if (!m_PatternContorller)
        {
            m_PatternContorller = gameObject.AddComponent<PatternController>();
        }

        m_PatternContorller.PlayPattern();
    }

    public void PatternAllClear()
    {
        m_PatternContorller.ClearAllPattern();
    }

    // ===========================
    //    다음 패턴 넘어가는 함수
    // ============================
    public void NextPattern(float DelayTime)
    {
        StartCoroutine(coNextPattern(DelayTime));// 다음으로 넘기고
    }

    IEnumerator coNextPattern(float DelayTime)
    {
        yield return new WaitForSeconds(DelayTime);

        m_PatternContorller.NextPattern();
    }


    // ===========================
    //       패턴 일시 중지
    // ============================
    public void StopPatern()
    {
        m_PatternContorller.StopPattern();  // 다음으로 넘기고
    }

    // ===========================
    //        패턴 리스타트
    // ============================
    public void RestartPattern(float DelayTime)
    {
        m_PatternContorller.ResumePattern(DelayTime);  // 다음으로 넘기고
    }

    // ====================================================================
    //           능력치 Set 해주는 함수
    // ====================================================================
    public virtual void SetStat(int Hp, int Mp)
    {
        m_sStat = new Stat();
        m_sStat.setStat(Hp, Mp);

    }


   



}
