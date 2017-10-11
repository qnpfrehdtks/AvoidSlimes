using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasherFanPattern : BasePattern {



    public override void PatternDead()
    {
        StopCoroutine(PlayPattern());
    }



    public override void init()
    {
        m_sPStat.m_ePattern = PATTERN_NAME.WASHER_FAN;
    }

    protected override float CalculAngle(int idx)
    {
        return m_sPStat.m_fAngle + m_sPStat.m_fAngleRate * ((float)idx / (m_sPStat.m_iFireCount - 1) - 0.5f);
    }

    protected override IEnumerator PlayPattern()
    {
       

        while (true)
        {
            for (int i = 0; i < m_sPStat.m_iFireCount; i++)
            {

                FireBullet(i);

                //Instantiate(m_cBullet).
                //    AddComponent<Bullet>().
                //    FireBullet(
                //    m_cSootingMover.transform.position,
                //    m_sPStat.m_fSpeed,
                //    m_sPStat.m_fAngle + (90 * i),
                //    m_sPStat.m_fBullet_SpeedRate,
                //    m_sPStat.m_fBullet_AngleRate,
                //    m_sPStat.m_shape);
                yield return null;
            }
            m_sPStat.m_fAngle += m_sPStat.m_fRotateAngleRate;

            if (Mathf.Abs(m_sPStat.m_fAngle) >= m_sPStat.m_fRotateAngle + m_sPStat.m_fMaxAngle ||
                Mathf.Abs(m_sPStat.m_fAngle) <= m_sPStat.m_fRotateAngle - m_sPStat.m_fMaxAngle)
            {
                m_sPStat.m_fRotateAngleRate *= -1;
            }

            yield return new WaitForSeconds(m_sPStat.m_fFireInterval);
        }
    }

    public override void PatternStop()
    {

    }
}
