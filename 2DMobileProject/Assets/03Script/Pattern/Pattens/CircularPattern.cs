using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularPattern : BasePattern {


    public override void PatternDead()
    {
        StopCoroutine(PlayPattern());
    }


    protected override float CalculAngle(int idx)
    {
        return m_sPStat.m_fAngle + m_sPStat.m_fAngleRate * ((float)idx / (m_sPStat.m_iFireCount - 1) - 0.5f);
    }


    public override void init()
    {
        m_sPStat.m_ePattern = PATTERN_NAME.CIRCULAR;
    }

    protected override IEnumerator PlayPattern()
    {
        m_sPStat.m_fAngleRate = 360.0f - m_mRotateAngleset;

        while (true)
        {
            for (int i = 0; i < m_sPStat.m_iFireCount; i++)
            {
                FireBullet(i);
                yield return null;
            }
       //     m_sPStat.m_fAngle += m_sPStat.m_fAngleRate;
            yield return new WaitForSeconds(m_sPStat.m_fFireInterval);
        }

    }

    public override void PatternStop()
    {

    }



}
