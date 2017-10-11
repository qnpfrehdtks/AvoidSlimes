using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCircularPattern : BasePattern {

    float AngleRate;
    public override void PatternDead()
    {
        StopCoroutine(PlayPattern());
    }


    public override void init()
    {
        m_sPStat.m_ePattern = PATTERN_NAME.RANDOM_CIRCULAR;
    }


    protected override float CalculAngle(int idx)
    {
      
        return m_sPStat.m_fAngle + AngleRate * (Random.Range(-1.0f, 1.0f));
    }

    protected override IEnumerator PlayPattern()
    {

        AngleRate = 360.0f - m_mRotateAngleset;

        while (true)
        {
            for (int i = 0; i < m_sPStat.m_iFireCount; i++)
            {

                FireBullet(i);
                yield return null;
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
            //     m_sPStat.m_fAngle += m_sPStat.m_fAngleRate;
            yield return new WaitForSeconds(m_sPStat.m_fFireInterval);
        }

    }

    public override void PatternStop()
    {

    }
}
