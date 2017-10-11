using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseController
{

    private float[] m_PhaseRates;

    int m_CurLevel;

    public void Init(float[] Phase)
    {
        m_PhaseRates = Phase;
    }
   
    public void CheckNextPattern(float Rate)
    {
       if(m_PhaseRates[m_CurLevel] > Rate)
        {
            m_CurLevel++;
            EnemyMGR.Instance.NextPattern(2.0f);
        }
    }
}

public class Stat
{

    private float m_HpRate;

    public bool m_isImmortal { get;  set; }

    public int m_iHP { get;  set; }
    public int m_iMp { get;  set; }
    public int m_iCurHp { get;  set; }
    public int m_iCurMp { get;  set; }
    public bool m_isDead { get;  set; }


    public virtual void setStat(int Hp, int Mp)
    {
        m_iHP = Hp;
        m_iCurHp = m_iHP;

        m_iMp = Mp;
        m_iCurMp = m_iMp;

        m_isDead = false;
        m_isImmortal = false;

        m_HpRate = (float)1 / m_iHP;
    }

    public virtual void MpDamaged(int Damage)
    {
        m_iCurMp -= Damage;
        BattleUI.UIInstance.MpUpdate();
    }
    public virtual void Damaged(int Damage)
    {
        if (!m_isImmortal && m_iCurHp > 0)
        {
            m_iCurHp -= Damage;
        }
    }
    public void GetMpHeal(int heal)
    {
        m_iCurMp += heal;
        BattleUI.UIInstance.MpUpdate();
    }
    public void GetHeal(int heal)
    {
        m_iCurHp += heal;
        BattleUI.UIInstance.LifeUpdate();
    }

    public void SetImmortal(bool active)
    {
        m_isImmortal = active;
    }

    public virtual bool CheckDead()
    {
        if(m_iCurHp <= 0 )
        {
            m_isDead = true;
            return true;    
        }
        m_isDead = false;
        return false;
    }


    public float GetHPRate()
    {
        return m_iCurHp * m_HpRate;
    }




}


public struct PatternState
{
    public bool m_isPatternMix;

    public PATTERN_NAME m_ePattern;

    // 총알의 스피드를 증가 시킬 것인가 각도를 증가 시킬것인가...
    public float m_fBullet_SpeedRate;
    public float m_fBullet_AngleRate;

    public float m_fAngle;
    public float m_fAngleRate;

    public float m_fSpeed;
    public float m_fSpeedRate;

    public float m_fFireInterval;

    public int m_iFireCount;
    public int m_iGroupCount;

    public float m_fRotateAngle;
    public float m_fRotateAngleRate;

    public float m_fMaxAngle;

    public float m_fMiniFireInterval;

    public Sprite m_sImage;
    public BULLET_IMAGE m_eImage;
    public BULLET_TYPE m_eType;

    public float m_HomingRate;
    public bool m_isHoming;

    public float m_MoveTime;
    public float m_StopTime;

    public Vector3 ScaleXY;

    public bool m_isMyPos;

    public float m_fStartPosX;
    public float m_fStartPosY;

    public void setPattern
          (bool isMix, PATTERN_NAME patternName, float XScale, float YScale, float speed, float anlge, float speedRate, float angleRate, float interval, float BulletSpeedRate = 0.0f, float BulletAngleRate = 0.0f, 
          int Count = 1, float MinInterval = 0.0f,
          float RotAngle = 90.0f, float RotAngleRate = 90.0f, float MaxAngle = 90.0f, int GroupCount = 0,
          BULLET_TYPE type = BULLET_TYPE.BASE, BULLET_IMAGE image = BULLET_IMAGE.BASE_BULLET1_1, float HomingRate = 0.0f, bool isHoming = false, float MoveTime = 0.0f, float StopTime = 0.0f, bool isMyPos = true, float StartX = 0.0f, float StartY =0.0f)
    {
        m_isPatternMix = isMix;
        m_ePattern = patternName;

        ScaleXY.x = XScale;
        ScaleXY.y = YScale;

        m_fSpeed = speed;
        m_fAngle = anlge;
        m_fSpeedRate = speedRate;
        m_fAngleRate = angleRate;

        m_iFireCount = Count;
        m_fFireInterval = interval;

        m_fBullet_SpeedRate = BulletSpeedRate;
        m_fBullet_AngleRate = BulletAngleRate;

        m_fMaxAngle = MaxAngle;

        m_fRotateAngle = RotAngle;
        m_fRotateAngleRate = RotAngleRate;

        m_fMiniFireInterval = MinInterval;

        m_eType = type;
        m_eImage = image;

        m_iGroupCount = GroupCount;

        m_HomingRate = HomingRate;
        m_isHoming = isHoming;

        m_MoveTime = MoveTime;
        m_StopTime = StopTime;

        m_fStartPosX = StartX;
        m_fStartPosY = StartY;
        m_isMyPos = isMyPos;

        m_sImage = SpriteMGR.Instance.GetSprite(m_eImage);


    }

    public void setPattern (PatternState stat)
    {
        m_isPatternMix = stat.m_isPatternMix;
        m_ePattern = stat.m_ePattern;

        ScaleXY.x = stat.ScaleXY.x;
        ScaleXY.y = stat.ScaleXY.y;

        m_fSpeed = stat.m_fSpeed;
        m_fAngle = stat.m_fAngle;
        m_fSpeedRate = stat.m_fSpeedRate;
        m_fAngleRate = stat.m_fAngleRate;

        m_iFireCount = stat.m_iFireCount;
        m_fFireInterval = stat.m_fFireInterval;

        m_fBullet_SpeedRate = stat.m_fBullet_SpeedRate;
        m_fBullet_AngleRate = stat.m_fBullet_AngleRate;

        m_fRotateAngle = stat.m_fRotateAngle;
        m_fRotateAngleRate = stat.m_fRotateAngleRate;

        m_fMaxAngle = stat.m_fMaxAngle;

        m_fMiniFireInterval = stat.m_fMiniFireInterval;

        m_iGroupCount = stat.m_iGroupCount;

        m_eType = stat.m_eType;
        m_eImage = stat.m_eImage;

        m_HomingRate = stat.m_HomingRate;
        m_isHoming = stat.m_isHoming;

        m_StopTime = stat.m_StopTime;
        m_MoveTime = stat.m_MoveTime;


        m_fStartPosX = stat.m_fStartPosX;
        m_fStartPosY = stat.m_fStartPosY;

        m_isMyPos = stat.m_isMyPos;

        m_sImage = SpriteMGR.Instance.GetSprite(m_eImage);


    }
}