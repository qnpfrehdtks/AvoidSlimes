using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    float m_fmoveRate;
    Vector2 prePos;
    Vector2 nowPos;
    Vector2 movePos;

    Vector2 m_vMin;
    Vector2 m_vMax;

    Mover m_cMover;

    bool m_isCanReset;


    public void Init(Mover mover)
    {
        m_vMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.94f));
        m_vMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));

        m_fmoveRate = (float)780 / 1280;
        m_cMover = mover;
    }

    //===========================================================
    // 안드로이드용, 터치 2개 입력시 발동
    // =========================================================
    private void ResetBullet()
    {
        if (m_cMover.m_isCanActive)
        {
            if (Input.touchCount == 2)
            {
                Touch touch2 = Input.GetTouch(1);
                if (touch2.phase == TouchPhase.Began)
                {
                    if (m_cMover.m_sStat.m_iCurMp > 0)
                    {
                        m_cMover.m_sStat.MpDamaged(1);

                        BulletMGR.Instance.AllBulletPatternStop(); // 모든 총알의 패턴을 중지
                        BulletMGR.Instance.AllReleaseBullet();  // 총알을 다시 집어넣고 

                        EnemyMGR.Instance.StopPattern(); // 적의 패턴 일시 정지
                        EnemyMGR.Instance.ResumePattern(1.0f); // 다시 패턴을 시작하기 까지 1.0f초 기다리자.
                         
                        SoundMGR.Instance.PlayOneShot(SOUND.SOUND_CHANGE); // 사운드 재생및 카메라 흔들림.
                        iTween.ShakePosition(Camera.main.gameObject, iTween.Hash("x", 0.3f, "y", 0.3f, "time", 1.0f));
                    }
                }
            }
        }
    }


    // Update is called once per frame
    public void MoveUpdate()
    {
#if UNITY_ANDROID // For Android!! 안드로이용
            if (Input.touchCount > 0 )
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                movePos = m_cMover.transform.position;
                movePos += touch.deltaPosition *  Time.deltaTime * m_fmoveRate;

                movePos.x = Mathf.Clamp(movePos.x, m_vMin.x, m_vMax.x);
                movePos.y = Mathf.Clamp(movePos.y, m_vMin.y, m_vMax.y);

                m_cMover.transform.position = movePos;
                
                }

            ResetBullet();
        }

       

#endif

#if UNITY_EDITOR_WIN // 디버그용ㅋ

                if (Input.GetMouseButton(0))
               {
                nowPos = Input.mousePosition - (Vector3)prePos;

                movePos = (Vector3)(nowPos.normalized) * m_cMover.m_fSpeed * Time.deltaTime;
                m_cMover.transform.Translate(movePos);

                prePos = Input.mousePosition;

            }

        if (Input.GetMouseButton(1))
        {
            //  Time.timeScale = 0.0f;
            if (m_cMover.m_sStat.m_iCurMp > 0)
            {
                m_cMover.m_sStat.MpDamaged(1);


                BulletMGR.Instance.AllBulletPatternStop();
                BulletMGR.Instance.AllReleaseBullet();

                EnemyMGR.Instance.StopPattern();
                EnemyMGR.Instance.ResumePattern(1.0f);

                SoundMGR.Instance.PlayOneShot(SOUND.SOUND_CHANGE);
                iTween.ShakePosition(Camera.main.gameObject, iTween.Hash("x", 0.3f, "y", 0.3f, "time", 1.0f));
            }

           // BattleUI.UIInstance.MpUpdate();
        }

        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position); //캐릭터의 월드 좌표를 뷰포트 좌표계로 변환해준다.
            viewPos.x = Mathf.Clamp01(viewPos.x); //x값을 0이상, 1이하로 제한한다.
            viewPos.y = Mathf.Clamp01(viewPos.y); //y값을 0이상, 1이하로 제한한다.
            Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos); //다시 월드 좌표로 변환한다.
            transform.position = worldPos; //좌표를 적용한다.
#endif
        }
}
