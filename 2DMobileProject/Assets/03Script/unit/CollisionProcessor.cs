using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollisionProcessor : MonoBehaviour {

    protected AudioClip m_CollideSound; // 충돌 했을 때 사운드 클립 미리 저장.

    protected Mover m_mMover;
    protected Stat m_sStat;

    protected Color m_DamagedColor;
    protected Color m_OriginColor;

    
    protected int m_ibulletLayer;

    public int m_CollisionNum { get; protected set; } // 이번 패턴에서 몇번 충돌했는지 알려주는 변수임.


    public virtual void Init(Mover mover)
    {
        m_mMover = mover;
        m_sStat = mover.m_sStat;

        m_ibulletLayer = 1 << LayerMask.NameToLayer("Bullet");

        SoundInit();
        ColorInit(0.1f, 0.1f, 0.1f, 0.1f);
       
    }

    protected void SoundInit()
    {
        m_CollideSound = SoundMGR.Instance.GetAudioClip(SOUND.SOUND_DAMAGED);

    }
    protected void ColorInit(float R, float G, float B, float A)
    {
        m_OriginColor = Color.white;
        m_OriginColor.a = 1.0f;

        m_DamagedColor = Color.white;
        m_DamagedColor.r = R;
        m_DamagedColor.g = G;
        m_DamagedColor.b = B;
        m_DamagedColor.a = A;
    }

    public void ScoreCollision(int Score)
    {
        PlayerMGR.Instance.GetScore(Score);
    }

    public void HealthCollision(int heal)
    {
        m_sStat.GetHeal(heal);
        BattleUI.UIInstance.LifeUpdate();
    }

    public void resetCollNum()
    {
        m_CollisionNum = 0;
    }

    public abstract void Collision(int Damaged, GameObject collider);
    public abstract void RayCastCollisionCheck();
}

//===============================================
//     플레이어의 충돌 처리를 담당하는 객체.
//===============================================
public class PlayerCollision : CollisionProcessor
{

    //==========================================================================
    //     Ray를 쏘아서 충돌을 체크한다!! 콜리더 쓰는 것 보다 프레임이 줄어들더라~
    //==========================================================================
    public override void RayCastCollisionCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(m_mMover.transform.position - Vector3.up * 0.1f, Vector2.up, 0.2f,  m_ibulletLayer);

        if (hit.collider)
        {
            Collision(1, hit.collider.gameObject);
        }
    }

    //======================================================
    //             충돌할 경우 처리하는 함수
    //======================================================
    public override void Collision(int Damaged, GameObject collider)
    {

        //작은 총알들에게 데미지 입을 시 그 총알은 다시 회수됨.
        if (collider.transform.localScale.x <= 1.0f)
        {
            Bullet bullet = collider.GetComponent<Bullet>();
            bullet.StopAllCoroutines();
            BulletMGR.Instance.PushBullet(bullet);
        }

        // 데미지 입을 경우 처리
            DamagedCollision(Damaged);
            
    }

    //======================================================
    //          데미지를 입을 시 처리하는 함수.
    //======================================================
    private void DamagedCollision(int Damaged)
    {
        m_sStat.Damaged(Damaged);
       

        // 죽을때 처리...
        if (m_sStat.CheckDead())
        {
            BattleUI.UIInstance.LifeUpdate();
            PlayerMGR.Instance.PlayerDeadEvent();
            return;
        }

        // 죽진 않고 데미지 입을 경우
        if (!m_sStat.m_isImmortal)
        {
            BattleUI.UIInstance.LifeUpdate();
            // iTween으로 카메라 흔들고
            iTween.ShakePosition(Camera.main.gameObject, iTween.Hash("x", 0.3f, "y", 0.3f, "time", 1.0f));
            // 데미지 입는 거 재생
            SoundMGR.Instance.PlayOneShot(m_CollideSound);
            // 난 무적이다!!! 실행
            StartImmortal(2.0f, 0.2f);
            m_CollisionNum++;

        }
    }


    //======================================================
    //      무적을 처리하는 함수~ 코루틴으로 시간 조정
    //======================================================
    public void StartImmortal(float Time, float TwinkleTime)
    {
        StartCoroutine(Immortal(Time));
        StartCoroutine(TwinkleMaterial(TwinkleTime));
    }

    private IEnumerator Immortal(float Time)
    {
        m_sStat.SetImmortal(true);

        yield return new WaitForSeconds(Time);

        m_sStat.SetImmortal(false);
    }

    private IEnumerator TwinkleMaterial(float TwinkleTime)
    {
        while (m_sStat.m_isImmortal)
        {
            iTween.ColorTo(gameObject, m_DamagedColor, TwinkleTime);

            yield return new WaitForSeconds(TwinkleTime);

            iTween.ColorTo(gameObject, m_OriginColor, TwinkleTime);

            yield return new WaitForSeconds(TwinkleTime);
        }
    }
}


public class EnemyCollision : CollisionProcessor
{
    public override void Init(Mover mover)
    {
        m_mMover = mover;
        m_sStat = mover.m_sStat;
        m_ibulletLayer = 1 << LayerMask.NameToLayer("PlayerBullet");

        ColorInit(0.1f, 
            0.1f, 0.1f, 0.1f);
    }

    public override void RayCastCollisionCheck()
    {
       
    }

    public override void Collision(int Damaged, GameObject Collider)
    {
        if (Collider.layer == 11)
        {
            PlayerMGR.Instance.GetScore(10);
             PlayerBulletMGR.Instance.PushBullet(Collider.GetComponent<PlayerBullet>());
            // 데미지 입을 경우 처리
            DamagedCollision(Damaged);
        }
    }

    private void DamagedCollision(int Damaged)
    {
        m_sStat.Damaged(Damaged);
        BattleUI.UIInstance.BossLifeUpdate();
    
        if (m_sStat.CheckDead())
        {
            PlayerMGR.Instance.PlayerVictoryEvent();
        }
        
    }
}
