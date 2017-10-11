using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasherPattern : BasePattern {


    float AngleRate;

    public override void init()
    {
        m_sPStat.m_ePattern = PATTERN_NAME.WASHER_SPIRAL;
    }

    public override void PatternDead()
    {
        StopCoroutine(PlayPattern());
    }


    protected override float CalculAngle(int idx)
    {
     
        return m_sPStat.m_fAngle + AngleRate * idx;
    }

    protected override IEnumerator PlayPattern()
    {
         AngleRate = (float)360 / m_sPStat.m_iFireCount;

        while (true)
        {
            for (int i = 0; i < m_sPStat.m_iFireCount; i++)
            {
                FireBullet(i);
                yield return null;
            }

            m_sPStat.m_fAngle += m_sPStat.m_fAngleRate;


            if (Mathf.Abs(m_sPStat.m_fAngle) >= m_sPStat.m_fMaxAngle)
            {
                m_sPStat.m_fAngleRate *= -1;
            }


            yield return new WaitForSeconds(m_sPStat.m_fFireInterval);
        }

    }

    public override void PatternStop()
    {

    }
}
