using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PatternFactory {

   public BOSS m_Boss { get; private set; }

    protected float[] m_PhaseAxis;
    protected List<MoverStat> m_moveList;
    protected List<PatternPackage> m_curPatternList;

    protected abstract void createPattern();
    protected abstract void createPatternAxis();
    protected abstract void createMovePattern();

    public PatternFactory(BOSS boss)
    {
        m_Boss = boss;
    }

    public List<PatternPackage> GetPattern()
    {
        m_moveList = new List<MoverStat>();
        createMovePattern();
        m_curPatternList = new List<PatternPackage>();
        createPattern();

        return m_curPatternList;
    }

    public float[] GetPatternAxis()
    {

        m_PhaseAxis = new float[4];
        createPatternAxis();

        return m_PhaseAxis;
    }

    protected void SetMoverStat(MoveType type, float deley, float Time, iTween.LoopType loopType, iTween.EaseType ease, string PathName1 = null, string PathName2 = null, string PathName3 = null, float x = 0, float y = 0)
    {
        MoverStat newMM;

        newMM.m_eMoveType = type;
        newMM.m_delay = deley;
        newMM.m_PathName1 = PathName1;
        newMM.m_PathName2 = PathName2;
        newMM.m_PathName3 = PathName3;
        newMM.m_Time = Time;
        newMM.m_LoopType = loopType;
        newMM.m_EaseType = ease;

        newMM.m_x = x;
        newMM.m_y = y;

        m_moveList.Add(newMM);
    }



}





