using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePattern: MonoBehaviour {


    protected Bullet m_cBullet;
    protected Vector2 m_StartPos;
    protected bool m_isMyPos;

    public abstract void init();
    protected Mover m_cSootingMover;
    protected Mover m_cEnemyShooting;

    protected Vector3 m_fFirePos;

    // 패턴의 정보를 구조체로 따로 빼냄.
    public PatternState m_sPStat;
    // 패턴의 정보를 구조체로 따로 빼냄.
    public PatternState m_sBPStat;

    protected float m_mRotateAngleset;
    protected float m_mFirecount;
 //   public GameObject m_cBullet;

    // ================================= //
    //   처음 패턴 만들고 초기화시 사용    //
    // ================================= //

    public virtual void PatternInit(Mover mover, Mover EnemyMover, PatternPackage ppk)
    {
        m_cSootingMover = mover;
        m_cEnemyShooting = EnemyMover;

        m_sPStat = ppk.m_Pattern;
        m_sBPStat = ppk.m_BulletPattern;

        m_mRotateAngleset = 360.0f / m_sPStat.m_iFireCount;
        m_mFirecount = (float)1 / (m_sPStat.m_iFireCount - 1);

        if (!m_sPStat.m_isMyPos)
        {
            m_StartPos.x = m_sPStat.m_fStartPosX;
            m_StartPos.y = m_sPStat.m_fStartPosY;
        }

    }

    public virtual void PatternStart(float delayTime = 0.0f)
    {
       
        StartCoroutine(DelayStart(delayTime));
    }



    public abstract void PatternStop();
    public abstract void PatternDead();


    private IEnumerator DelayStart(float delayTime)
    {
       yield return new WaitForSeconds(delayTime);

        StartCoroutine(PlayPattern());
    }


    protected abstract IEnumerator PlayPattern();

    //public abstract void Fire();

    protected float CalculShipAngle()
    {
        return Mathf.Atan2(m_cEnemyShooting.transform.position.y -
            m_cSootingMover.transform.position.y,
                          
            m_cEnemyShooting.transform.position.x - 
            m_cSootingMover.transform.position.x) * Mathf.Rad2Deg;
    }

    protected float MeCalculShipAngle()
    {

        return Mathf.Atan2(m_cEnemyShooting.transform.position.y -
            m_StartPos.y,

            m_cEnemyShooting.transform.position.x -
            m_StartPos.x) * Mathf.Rad2Deg;
    }


    protected abstract float CalculAngle(int idx);

    protected virtual float CalculSpeed(int idx)
    {
        return m_sPStat.m_fSpeed;
    }


    protected virtual void FireBullet(int idx)
    {
        if (m_sPStat.m_isMyPos)
        {
            m_StartPos.x = m_cSootingMover.transform.position.x + m_sPStat.m_fStartPosX;
            m_StartPos.y = m_cSootingMover.transform.position.y + m_sPStat.m_fStartPosY;
        }

        if (m_cSootingMover.m_eType != MoverType.Player)
        {
            m_cBullet = BulletMGR.Instance.PopBullet();
        }
        else
        {
          
            m_cBullet = PlayerBulletMGR.Instance.PopBullet();
        }

        FinalFireBullet(idx);

    }

    protected void FinalFireBullet(int idx)
    {
        m_cBullet.
        FireBullet
           (
           m_StartPos,
           CalculAngle(idx),
           CalculSpeed(idx),
           m_sPStat,
           m_sBPStat
           );
    }




}
