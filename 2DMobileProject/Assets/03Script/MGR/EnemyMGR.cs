using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMGR : SingleMGR<EnemyMGR> {

    public BOSS m_eBoss { get; private set; }

    public PhaseController m_PhaseController { get; private set; }

    // UnitStylist 객체는 보스의 눈1,눈2, 몸통, 입의 Sprite를 변경을 담당하는 놈임.
    public UnitStylist m_CStyilist { get; private set; }
    public List<Enemy> m_CurEnemies { get; private set; }
    public Enemy m_CurBoss { get; private set; }

    // 충돌 처리 담당.
    private CollisionProcessor m_cCollisionProcessor;
    private Vector3 m_StarterPos;
    // 이번 프로젝트의 원칙.. 대부분 객체화해서 사용하자~

    // =============================================================================
    //   맨 처음 매니저를 만들 때 딱 한번 실행하는 함수임. 잘 생각하고 코드를 구현하자. 
    // =============================================================================
    protected override bool Init()
    {
       if(!m_CStyilist)
        {
            m_CStyilist = gameObject.AddComponent<UnitStylist>();
        }

        if (!m_cCollisionProcessor)
        {
            m_cCollisionProcessor = gameObject.AddComponent<EnemyCollision>();
        }

      
        return true;
    }


    // ==========================================================================
    //   보스 생성함수, 코스튬도 입히고, init도 해주고, 충돌 객체도 설정도 하고 그럼
    // ==========================================================================
    public void CreateBoss(BOSS boss, float StartX = 0, float StartY  = 2.5f)
    {
        m_eBoss = boss;

        m_StarterPos = new Vector3(StartX, StartY,0.0f);

        m_PhaseController = new PhaseController();

        // 보스를 생성하고 EnemyManager의 자식으로 둔다.
        GameObject obj = Instantiate(Resources.Load<GameObject>("Boss"), m_StarterPos, Quaternion.identity) as GameObject;
        obj.transform.parent = gameObject.transform;
        m_CurBoss = obj.GetComponent<Enemy>();

        // 보스의 눈1, 눈2, 입, 몸통을 조립하여 원하는 코스튬을 입히는 작업.
        Transform[] FaceParts = obj.transform.GetComponentsInChildren<Transform>();
        m_CStyilist.init(FaceParts[1].gameObject, FaceParts[2].gameObject, FaceParts[3].gameObject, FaceParts[4].gameObject);

        // 보스 스탯 조정 및 Init 로 시작 위치 조정.
        if(m_eBoss == BOSS.BOSS7)
        m_CurBoss.SetStat(15000, 100);
        else m_CurBoss.SetStat(12000, 100);

        m_CurBoss.Init(2.0f, m_StarterPos, new Vector3(0.5f, 0.5f, 0.5f), Quaternion.identity, MoverType.BOSS);

        // 충돌 처리하는 객체에게 보스가 누구인지 할당.
        m_cCollisionProcessor.Init(m_CurBoss);
        m_PhaseController.Init(StatMGR.Instance.GetPhaseList(boss));

 
    }



    // ====================================================================
    //         적들이 플레이어와 각도를 알고 싶을 때 사용하는 함수.
    // ===================================================================
    public float CalculMoverAngle(float X, float Y)
    {
        return Mathf.Atan2(m_CurBoss.transform.position.y - Y,
                   m_CurBoss.transform.position.x - X) * Mathf.Rad2Deg;
    }

    // ====================================================================
    //               보스를 제거할때 사용하는 함수.
    // ===================================================================
    public void releaseBoss()
    {
        m_CurBoss.PatternAllClear();
        Destroy(m_CurBoss.gameObject);
        m_CurBoss = null;
    }

    // ====================================================================
    //                              레이로 체크용
    // ===================================================================
    public void CheckCollisionCheck()
    {
        m_cCollisionProcessor.RayCastCollisionCheck();
    }

    // ====================================================================
    //               보스가 데미지를 입은 경우
    // ===================================================================
    public void GetDamage(int Damage, GameObject bulletObj)
    {
        
        m_cCollisionProcessor.Collision(Damage, bulletObj);
    }

    public void StartPattern(float DelayTime)
    {
        m_CurBoss.StartEvent(DelayTime, m_eBoss);
    }

    public void StopPattern()
    {
        m_CurBoss.StopPatern();
    }

    public void PatternAllClear()
    {
        m_CurBoss.PatternAllClear();
    }

    public void NextPattern(float delay)
    {
        PlayerMGR.Instance.PatternScoreCalcul();

        m_CurBoss.PatternAllClear();
        BulletMGR.Instance.AllBulletPatternStop();
        BulletMGR.Instance.AllReleaseBullet();

        SoundMGR.Instance.PlayOneShot(SOUND.SOUND_CHANGE);

        iTween.ShakePosition(Camera.main.gameObject, iTween.Hash("x", 0.3f, "y", 0.3f, "time", 1.0f));
        iTween.MoveTo(m_CurBoss.gameObject,iTween.Hash("position", m_StarterPos,  "time", delay));

        m_CurBoss.NextPattern(delay);
    }

    public void ResumePattern(float DelayTime)
    {
        m_CurBoss.RestartPattern(DelayTime);
    }

}
