using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomShotGunPattern : BasePattern {

    public override void PatternDead()
    {
        StopCoroutine(PlayPattern());
    }


    protected override float CalculSpeed(int idx)
    {
       return m_sPStat.m_fSpeed + (m_sPStat.m_fSpeedRate * idx);
    }

    protected override float CalculAngle(int idx)
    {
        return m_sPStat.m_fAngle + m_sPStat.m_fAngleRate * (Random.Range(0.0f, 1.0f) - 0.5f);
    }

    public override void init()
    {
        m_sPStat.m_ePattern = PATTERN_NAME.SHOTGUN_RANDOM;
    }

    protected override IEnumerator PlayPattern()
    {
        while (true)
        {

            for (int j = 0; j < m_sPStat.m_iGroupCount; j++)
            {
                for (int i = 0; i < m_sPStat.m_iFireCount; i++)
                {
                    FireBullet(i);

                    yield return null;
                }

                yield return new WaitForSeconds(m_sPStat.m_fMiniFireInterval);
                //     m_sPStat.m_fAngle += m_sPStat.m_fAngleRate;

            }

            yield return new WaitForSeconds(m_sPStat.m_fFireInterval);
        }

    }

    public override void PatternStop()
    {

    }
}
