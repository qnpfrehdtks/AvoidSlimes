using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCircularPattern : BasePattern {

    float AngleRate;
    float FireCount;

    public override void PatternDead()
    {
        StopCoroutine(PlayPattern());
    }


    protected override float CalculAngle(int idx)
    {
        return m_sPStat.m_fAngle + AngleRate * (idx * FireCount - 0.5f);
    }

    public override void init()
    {
        m_sPStat.m_ePattern = PATTERN_NAME.ROTATE_CIRCULAR;
    }

    protected override IEnumerator PlayPattern()
    {
        FireCount = m_mFirecount;
        AngleRate = 360.0f - (m_mRotateAngleset);

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
            }
            m_sPStat.m_fAngle += m_sPStat.m_fRotateAngleRate; 

            yield return new WaitForSeconds(m_sPStat.m_fFireInterval);
        }

    }

    public override void PatternStop()
    {

    }

}
