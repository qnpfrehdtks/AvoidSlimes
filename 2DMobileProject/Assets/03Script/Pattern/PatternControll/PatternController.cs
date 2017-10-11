using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//===========================================================================================================
//       이 클래스는 오직 탄막 패턴만을 관리하는 함수임. 보스의 이동이 어떻게 움직이는지는 얘도 모름. ㅎ
//===========================================================================================================
public class PatternController : MonoBehaviour {

    protected Mover m_EnemyMover;
    protected Mover m_cMover;

    protected int m_CurPatternLevel = 0;
    protected int m_MaxPatternLevel = 0;

    // 현재 시전 중인 패턴의 리스트를 담아놓음.
    protected List<BasePattern> m_CurPatternList;

    // Boss가 앞으로 시전할 스킬의 리스트를 담아 놓음.
    protected List<PatternPackage> m_cBossPatternList;

    //===================================================================================
    //   패턴 컨트롤러는 패턴 매니저로 부터 수많은 패턴을 입력받아 가져와야함.
    //   패턴 매니저와 패턴 컨트롤러를 분리한 이유는 보스마다 패턴을 관리할 객체가 필요해서.
    //   ※사용법 :  패턴 컨트롤러는 보스의 패턴을 관리해준다.
    //===================================================================================
    public virtual void SetPattern(Mover mover, BOSS boss)
    {
        m_cMover = mover;
        m_cBossPatternList = StatMGR.Instance.GetPatternList(boss);

        SetCostume(boss);

        m_MaxPatternLevel = m_cBossPatternList.Count;
        m_CurPatternList = new List<BasePattern>();

        if (m_cMover.m_eType == MoverType.Player)
            m_EnemyMover = EnemyMGR.Instance.m_CurBoss;
        else 
            m_EnemyMover = PlayerMGR.Instance.m_Player;
    }

    public virtual void SetPattern(Mover mover, PatternState ps)
    {
        m_cBossPatternList = new List<PatternPackage>();
        m_cMover = mover;

        PatternPackage pk = new PatternPackage(ps);
        m_cBossPatternList.Add(pk);

        m_MaxPatternLevel = m_cBossPatternList.Count;
        m_CurPatternList = new List<BasePattern>();

    }

    public virtual void SetPattern(PatternState ps)
    {
        //   m_EnemyMover = PlayerMGR.Instance.m_Player;
        m_CurPatternLevel = 0;
           m_cBossPatternList[0].m_Pattern = ps;
        m_cBossPatternList[0].m_PPDelay = 0.0f;
       
    }

    public void PlayPattern()
    {
        MoveStart();
        realPlayPattern();
    }


    //===================================================================================================
    //             SetPattern 함수에서 넣은 패턴을 차례대로 실행합시다!!
    //    패턴을 패턴 매니저로 부터 꺼내오고 -> 패턴을 실행한다. 
    //    -> 패턴을 현재 실행중인 패턴 리스트에 집어넣는다. -> 만약 다음 패턴도 같이 섞어야 하면 같이 실행하자.
    //===================================================================================================
    private void realPlayPattern()
    {
        BasePattern pattern = null;

        pattern = PatternMGR.Instance.GetPattern(m_cBossPatternList[m_CurPatternLevel].m_Pattern);
        pattern.PatternInit(m_cMover, PlayerMGR.Instance.m_Player, m_cBossPatternList[m_CurPatternLevel]);

        pattern.PatternStart(m_cBossPatternList[m_CurPatternLevel].m_PPDelay);
        m_CurPatternList.Add(pattern);

        MixPattern();
    }

    private void MoveStart()
    {
        if (m_cMover.m_eType == MoverType.BOSS)
            MoveMGR.Instance.StartMovePattern(m_cMover, m_cBossPatternList[m_CurPatternLevel].m_MoveStat);
    }

    //===================================================================================================
    //                                    패턴을 섞을 때 사용하는 함수. 
    //===================================================================================================
    protected void MixPattern()
    {
        if (m_cBossPatternList[m_CurPatternLevel].m_Pattern.m_isPatternMix)
        {
            if (m_CurPatternLevel < m_MaxPatternLevel - 1)
            {
                m_CurPatternLevel++;
                realPlayPattern();
            }
            else
            {
                //    Debug.Log("Already Max Level");
            }
        }
    }

    //=================================================================================
    //       넘기자 패턴을 다음으로! 근데 끝까지 오면 모든 현재 돌리는 패턴 다 종료 시킴.
    //=================================================================================
    public void NextPattern()
    {
        if (m_CurPatternLevel < m_MaxPatternLevel - 1)
        {
            ClearAllPattern(); // 현재 돌리는 모든 패턴 지우고
            m_CurPatternLevel++;  // 다음 레벨로
                                  //   SetCostme(EnemyMGR.Instance.m_eBoss); // 코스튬도 갈아 끼우고,
            PlayPattern();  // 다음 레벨 패탄 돌리자.
        }
        else
        {
            ClearAllPattern();
        }
    }

    //========================================================================
    //                     패턴을 강제로 종료 시키는 함수.
    //========================================================================
    public void ClearAllPattern()
    {
        for (int i = 0; i <  m_CurPatternList.Count; i++)
        {
            m_CurPatternList[i].PatternDead();
            PatternMGR.Instance.RetrunPattern(m_CurPatternList[i].gameObject);
        }
        m_CurPatternList.Clear();
    }
    //========================================================================
    //                           패턴 일시 정지 함수.
    //========================================================================
    public void StopPattern()
    {
        for (int i = 0; i < m_CurPatternList.Count; i++)
        {
            m_CurPatternList[i].PatternDead();
            m_CurPatternList[i].gameObject.SetActive(false);
        //    PatternMGR.Instance.RetrunPattern(m_CurPatternList[i].gameObject);
        }

    }

    //========================================================================
    //                           패턴 다시 시작
    //========================================================================
    public void ResumePattern(float delay)
    {

        StartCoroutine(ResumeP(delay));
    }

    IEnumerator ResumeP(float delay)
    {
       yield return new WaitForSeconds(delay);
    //    Debug.Log(m_CurPatternList.Count);
        for (int i = 0; i < m_CurPatternList.Count; i++)
        {
           // Debug.Log("냥!");
            m_CurPatternList[i].gameObject.SetActive(true);
            m_CurPatternList[i].PatternStart();
        }
    }

    //========================================================================
    //                           보스 코스튬 꾸미는 함수
    //========================================================================

    private void SetCostume(BOSS boss)
    {
        if (m_cMover.m_eType == MoverType.BOSS)
        {
            EnemyMGR.Instance.m_CStyilist.SetAllPart(
                m_cBossPatternList[m_CurPatternLevel].m_Body,
                m_cBossPatternList[m_CurPatternLevel].m_LEye,
                m_cBossPatternList[m_CurPatternLevel].m_REye,
                m_cBossPatternList[m_CurPatternLevel].m_Mouth
                );
        }
    }




}
