using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanPattern : CircularPattern {

    public override void init()
    {
        m_sPStat.m_ePattern = PATTERN_NAME.FAN;
    }

    protected override float CalculAngle(int idx)
    {
       // return 60.0f + 30.0f * idx;
        return m_sPStat.m_fAngle + m_sPStat.m_fAngleRate * ((float)idx / (m_sPStat.m_iFireCount - 1) - 0.5f);
    }



    protected override IEnumerator PlayPattern()
    {
        while (true)
        {
            for (int i = 0; i < m_sPStat.m_iFireCount; i++)
            {
                FireBullet(i);
                yield return null;
            }
           //      m_sPStat.m_fAngle += m_sPStat.m_fAngleRate;
            yield return new WaitForSeconds(m_sPStat.m_fFireInterval);
        }
    }

}
