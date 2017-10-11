using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using Google;

public class PlayerMGR : SingleMGR<PlayerMGR> {



    public int m_CurScore { get; private set; }
    public Player m_Player { get; private set; }

    private  Vector3 m_StarterPos;
    private CollisionProcessor m_cCollisionProcessor; // 플레이어가 충돌할 때 사용하는 충돌 처리 관련 객체임.

    protected override bool Init()
    {
        if (!m_cCollisionProcessor)
        {
            m_cCollisionProcessor = gameObject.AddComponent<PlayerCollision>();
        }

        m_StarterPos = new Vector3(0, -3.0f, 0.0f);
        return true;
    }

    // ====================================================================
    //             플레이어 만드는 함수, 주로 전투씬 입장때 사용
    // ===================================================================
    public void CreatePlayer()
    {
        m_CurScore = 0;

        GameObject obj = Instantiate(Resources.Load<GameObject>("Player"), m_StarterPos, Quaternion.identity) as GameObject;
        obj.transform.parent = gameObject.transform;

        m_Player = obj.GetComponent<Player>();

       #if UNITY_EDITOR_WIN // 디버그용ㅋ
          m_Player.SetStat(100, 3);
       #endif

       #if UNITY_ANDROID
        m_Player.SetStat(5, 1);
       #endif

        m_Player.Init(5.0f, m_StarterPos, new Vector3(0.25f, 0.25f, 1.0f), Quaternion.identity, MoverType.Player);

        m_cCollisionProcessor.Init(m_Player);

    }

    // ====================================================================
    //                              레이로 체크용
    // ===================================================================
    public void CheckCollisionCheck()
    {
        m_cCollisionProcessor.RayCastCollisionCheck();
    }
    
    // ====================================================================
    //               플레이어 삭제 담당. 주로 전투 씬 끝날때 사용
    // ===================================================================
    public void releasePlayer()
    {
        m_CurScore = 0;
        m_Player.StopAllCoroutines();
        m_Player.PatternAllClear();
        Destroy(m_Player.gameObject);
        m_Player = null;

    }

    // ====================================================================
    //         적들이 플레이어와 각도를 알고 싶을 때 사용하는 함수.
    // ===================================================================
    public float CalculMoverAngle(float X, float Y)
    {
        return Mathf.Atan2(m_Player.transform.position.y - Y,
                   m_Player.transform.position.x - X) * Mathf.Rad2Deg;
    }

    // ====================================================================
    //          플레이어 스코어 얻느 함수. 전투 씬에서만 사용
    // ===================================================================
    public void GetScore(int score)
    {
        m_CurScore += score;
        BattleUI.UIInstance.ScoreUpdate(score);
    }

    // ====================================================================
    //               플레이어가 데미지를 입은 경우
    // ===================================================================
    public void GetDamage(int Damage, GameObject bulletObj)
    {
        m_cCollisionProcessor.Collision(Damage, bulletObj);
    }

    // ====================================================================
    //               플레이어 컨트롤 활성화 / 비활성화
    // ===================================================================
    public void setControllActive(bool isActive)
    {
        m_Player.m_isCanActive = isActive;
    }

    // ====================================================================
    //       다음 패턴으로 넘어 갔을 때 점수,생명력,리셋 추가
    // ===================================================================
    public void PatternScoreCalcul()
    {
        SoundMGR.Instance.PlayOneShot(SOUND.SOUND_SLIME1);

        GetScore(m_Player.m_sStat.m_iCurHp * 1000);
        BattleUI.UIInstance.accumulatedScore(m_Player.m_sStat.m_iCurHp * 1000);

        GetScore(m_Player.m_sStat.m_iCurMp * 1000);
        BattleUI.UIInstance.accumulatedScore(m_Player.m_sStat.m_iCurMp * 1000);

        m_Player.m_sStat.GetMpHeal(1);

        if (  m_cCollisionProcessor.m_CollisionNum == 0)
        {
            m_Player.m_sStat.GetHeal(2);
            BattleUI.UIInstance.accumulatedScore(10000);
            GetScore(10000);
        }
        else if (m_cCollisionProcessor.m_CollisionNum == 1 )
        {
            m_Player.m_sStat.GetHeal(1);
            BattleUI.UIInstance.accumulatedScore(5000);
            GetScore(5000);
        }
        else if (m_cCollisionProcessor.m_CollisionNum == 2)
        {
            BattleUI.UIInstance.accumulatedScore(3000);
            GetScore(3000);
        }
        else if (m_cCollisionProcessor.m_CollisionNum == 3)
        {
            BattleUI.UIInstance.accumulatedScore(1500);
            GetScore(1500);
        }

        BattleUI.UIInstance.ExposeBonusScore();
        m_cCollisionProcessor.resetCollNum();
    }

    // 플레이어 게임 끝날 때 점수 환산
    public void LastScoreCalcul()
    {
        PatternScoreCalcul();
    }

    // ====================================================================
    //                        플레이어 총 활성화
    // ===================================================================
    public void PatternStart()
    {
         m_Player.StartEvent();
    }


    // ====================================================================
    //                             패턴 종료
    // ===================================================================
    public void PatternStop()
    {
        PlayerBulletMGR.Instance.AllReleaseBullet();
        m_Player.PatternAllClear();
    }



    // ====================================================================
    //                            플레이어 죽을 시 처리
    // ===================================================================
    public void PlayerDeadEvent()
    {
        // iTween으로 카메라 흔들고
        iTween.ShakePosition(Camera.main.gameObject, iTween.Hash("x", 0.3f, "y", 0.3f, "time", 1.0f));
        // 데미지 입는 거 재생
        SoundMGR.Instance.PlayOneShot(SOUND.SOUND_DAMAGED);

        // 적 패턴 종료시키고
        EnemyMGR.Instance.m_CurBoss.PatternAllClear();
        BulletMGR.Instance.AllReleaseBullet();
        MoveMGR.Instance.releaseMove();

        PatternStop();
        PlayerBulletMGR.Instance.AllReleaseBullet();


        // 결과창 띄우고...
        ResultUI.UIInstance.ResultOn(false);
    }


    // ====================================================================
    //                      플레이어 승리 시 처리
    // ===================================================================
    public void PlayerVictoryEvent()
    {
        PatternStop();
        PlayerBulletMGR.Instance.AllReleaseBullet();
        LastScoreCalcul();

        BulletMGR.Instance.AllReleaseBullet();
        EnemyMGR.Instance.PatternAllClear();
        MoveMGR.Instance.releaseMove();

        ResultUI.UIInstance.ResultOn(true);

     #if UNITY_ANDROID
        AndroidMGR.Instance.PlayerVictoryProcess(EnemyMGR.Instance.m_eBoss, m_CurScore);
     #endif

    }

}
