using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BULLET_IMAGE
{
    BASE_BULLET1_1,
    BASE_BULLET1_2,

    BASE_BULLET2_1,
    BASE_BULLET2_2,

    BASE_BULLET3_1,
    BASE_BULLET3_2,
    BASE_BULLET3_3,

    BASE_BULLET4_1,
    BASE_BULLET4_2,
    BASE_BULLET4_3,

    BASE_PLAYER1,
    BASE_PLAYER2,

    GOLD,
    HEAL
}


public enum BULLET_TYPE
{
   NONE,
   BASE,
   TRAIL,
   HEAL,
   GOLD,
   ROTATE,
   STOP_AND_PLAY,
   STOP_AND_PLAY_TRAIL,
   RANDOM_STOP_AND_PLAY,
   TIMER

}

public class Bullet : Mover {

    Rigidbody2D rb2d;

    public PatternState m_cStat;
    public PatternState m_cBulletStat;

    public MoverMove m_MoverMove;
    public SpriteRenderer m_Sprite;

    public BULLET_TYPE m_eBulletType;
    public BULLET_IMAGE m_eBulletImage;

    public bool m_isFire = false;


    public override void Init()
    {
        //  BallCollSize = new Vector2(0.7f, 0.6f);
        //  LaserCollSize = new Vector2(3.5f, 3.3f);
        // NeedleCollSize = new Vector2(1.1f, 0.3f);
        rb2d = GetComponent<Rigidbody2D>();
         m_PatternContorller = GetComponent<PatternController>();
        m_eType = MoverType.Bullet;

       // m_Coll = gameObject.GetComponent<CapsuleCollider2D>();
        if (m_PatternContorller == null)
        {
            m_PatternContorller = gameObject.AddComponent<PatternController>();
        }
        m_PatternContorller.SetPattern(this, m_cStat);

        m_Sprite = GetComponent<SpriteRenderer>();
    }

    public void SetSprite(Sprite sprite)
    {


        if(m_Sprite)
        m_Sprite.sprite = sprite;

    }



    public void FireBullet(Vector2 StartPos, float StartAngle, float StartSpeed, PatternState stat, PatternState bulletstat)
    {
     //   m_eType = MoverType.Bullet;
        m_cStat = stat;
        m_cBulletStat = bulletstat;

        transform.position = StartPos;

        if (transform.localScale != stat.ScaleXY)
            transform.localScale = stat.ScaleXY;

           SetSprite(m_cStat.m_sImage);

        m_fAngle = StartAngle;
        m_fSpeed = StartSpeed;
        m_eBulletType = m_cStat.m_eType;

        PlayStopaAndMove();
        InstallTraill();

        m_isFire = true;
    }


    public void FireBullet(Vector2 StartPos, float StartAngle, float StartSpeed, PatternState stat)
    {

        m_cStat = stat;

        transform.position = StartPos;

       if(transform.localScale != stat.ScaleXY)
        transform.localScale = stat.ScaleXY;

        SetSprite(m_cStat.m_sImage);

        m_fAngle = StartAngle;
        m_fSpeed = StartSpeed;
        m_eBulletType = m_cStat.m_eType;

    //    SettingCollisionAndAngle();
        PlayStopaAndMove();

        m_isFire = true;

        StartTimer(3.0f);

    }


    private void StartTimer(float time)
    {
        if(m_cStat.m_eType == BULLET_TYPE.TIMER)
        StartCoroutine(TimerDestroy(time));
    }


    private IEnumerator TimerDestroy(float Time)
    {
        yield return new WaitForSeconds(Time);

        m_isFire = false;
        BulletPushToPool();


    }

    //private void Rotate()
    //{
    //    if (m_cStat.m_eType == BULLET_TYPE.ROTATE)
    //        transform.rotation = Quaternion.Euler(new Vector3(0, 0, m_fAngle));
    //}


    private void InstallTraill()
    {
        if (m_eBulletType == BULLET_TYPE.TRAIL)
        {
           m_PatternContorller.SetPattern(m_cBulletStat);
            m_PatternContorller.PlayPattern();
        }
    }
    
    private void UpdateMove()
    {
        Homing();

        Vector2 delta;
        
        delta.x = transform.position.x + Mathf.Cos(m_fAngle * Mathf.Deg2Rad) * m_fSpeed * Time.deltaTime;
        delta.y = transform.position.y + Mathf.Sin(m_fAngle * Mathf.Deg2Rad) * m_fSpeed * Time.deltaTime;

       // transform.position = delta;
       rb2d.MovePosition(delta);

        m_fAngle += (m_cStat.m_fBullet_AngleRate * Time.deltaTime);
        m_fSpeed += (m_cStat.m_fBullet_SpeedRate * Time.deltaTime);
    }


    public virtual void Homing()
    {
        if (m_cStat.m_isHoming)
        {
             m_fAngle = PlayerMGR.Instance.CalculMoverAngle(transform.position.x, transform.position.y);
        }
    }

    private void PlayStopaAndMove()
    {
        if (gameObject.activeSelf)
        {
            if (m_eBulletType == BULLET_TYPE.STOP_AND_PLAY)
                StartCoroutine(StopaAndMove());
        }
    }

    private IEnumerator StopaAndMove()
    {
        float Speed = m_fSpeed;

        yield return new WaitForSeconds(m_cStat.m_MoveTime);

        m_fSpeed = 0.0f;

        yield return new WaitForSeconds(m_cStat.m_StopTime);

        m_fSpeed = Speed;
    }

    private void FixedUpdate()
    {
        if(m_isFire)
           UpdateMove();
    }


     protected virtual void BulletPushToPool()
    {
        if (gameObject.activeSelf)
        {
         //   PlayerMGR.Instance.GetScore(5);
            BulletMGR.Instance.PushBullet(this);
        }
    }
    
      void OnBecameInvisible()
    {
        if (m_cStat.m_eType != BULLET_TYPE.TIMER)
        {
            m_isFire = false;
            
            BulletPushToPool();
        }
    }

    void OnDisable()
    {
        if (m_PatternContorller)
        {
            m_PatternContorller.ClearAllPattern();
        }
        m_isFire = false;
    }






}
