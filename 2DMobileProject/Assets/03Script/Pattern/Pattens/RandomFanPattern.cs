using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFanPattern : BasePattern {

    public override void init()
    {
        m_sPStat.m_ePattern = PATTERN_NAME.RANDOM_FAN;
    }

    public override void PatternDead()
    {
        StopCoroutine(PlayPattern());
    }


    protected override float CalculAngle(int idx)
    {
      return  m_sPStat.m_fAngle + m_sPStat.m_fAngleRate * (Random.Range(0.0f, 1.0f) - 0.5f);
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
                m_sPStat.m_fAngle += m_sPStat.m_fRotateAngleRate;
            yield return new WaitForSeconds(m_sPStat.m_fFireInterval);
        }
    }

    public override void PatternStop()
    {

    }
}
