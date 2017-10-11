using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatMGR : SingleMGR<StatMGR> {


    PatternFactory m_cFactory;

    Dictionary<BOSS, List<PatternPackage>> m_mBossDic;
    Dictionary<BOSS, float[]> m_fPhaseList;

    protected override bool Init()
    {
        m_mBossDic = new Dictionary<BOSS, List<PatternPackage>>();
        m_fPhaseList = new Dictionary<BOSS, float[]>();

        m_cFactory = new Boss2PatternFactory(BOSS.BOSS1);
        m_mBossDic.Add(m_cFactory.m_Boss, m_cFactory.GetPattern());
        m_fPhaseList.Add(m_cFactory.m_Boss, m_cFactory.GetPatternAxis());

        m_cFactory = new Boss3PatternFactory(BOSS.BOSS2);
        m_mBossDic.Add(m_cFactory.m_Boss, m_cFactory.GetPattern());
        m_fPhaseList.Add(m_cFactory.m_Boss, m_cFactory.GetPatternAxis());

        m_cFactory = new Boss5PatternFactory(BOSS.BOSS3);
        m_mBossDic.Add(m_cFactory.m_Boss, m_cFactory.GetPattern());
        m_fPhaseList.Add(m_cFactory.m_Boss, m_cFactory.GetPatternAxis());

        m_cFactory = new Boss6PatternFactory(BOSS.BOSS4);
        m_mBossDic.Add(m_cFactory.m_Boss, m_cFactory.GetPattern());
        m_fPhaseList.Add(m_cFactory.m_Boss, m_cFactory.GetPatternAxis());

        m_cFactory = new Boss7PatternFactory(BOSS.BOSS5);
        m_mBossDic.Add(m_cFactory.m_Boss, m_cFactory.GetPattern());
        m_fPhaseList.Add(m_cFactory.m_Boss, m_cFactory.GetPatternAxis());

        m_cFactory = new Boss8PatternFactory(BOSS.BOSS6);
        m_mBossDic.Add(m_cFactory.m_Boss, m_cFactory.GetPattern());
        m_fPhaseList.Add(m_cFactory.m_Boss, m_cFactory.GetPatternAxis());


        m_cFactory = new Boss9PatternFactory(BOSS.BOSS7);
        m_mBossDic.Add(m_cFactory.m_Boss, m_cFactory.GetPattern());
        m_fPhaseList.Add(m_cFactory.m_Boss, m_cFactory.GetPatternAxis());

        m_cFactory = new PlayerPatternFactory(BOSS.NONE);
        m_mBossDic.Add(m_cFactory.m_Boss, m_cFactory.GetPattern());
        m_fPhaseList.Add(m_cFactory.m_Boss, m_cFactory.GetPatternAxis());

        return true;
    }


    public List<PatternPackage> GetPatternList(BOSS boss)
    {
        if(m_mBossDic.ContainsKey(boss))
        {
            return m_mBossDic[boss];
        }

        return null;

    }


    public float[] GetPhaseList(BOSS boss)
    {
        if (m_fPhaseList.ContainsKey(boss))
        {
            return m_fPhaseList[boss];
        }

        return null;

    }



}
