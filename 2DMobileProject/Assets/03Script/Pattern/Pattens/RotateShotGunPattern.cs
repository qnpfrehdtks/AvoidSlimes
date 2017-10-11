using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShotGunPattern : BasePattern {

    public override void PatternDead()
    {
        StopCoroutine(PlayPattern());
    }


    public override void init()
    {
        m_sPStat.m_ePattern = PATTERN_NAME.ROTATE_SHOTGUN;
    }

    protected override float CalculAngle(int idx)
    {
        return m_sPStat.m_fAngle + m_sPStat.m_fAngleRate * ((float)idx / (m_sPStat.m_iFireCount - 1) - 0.5f);
    }

    protected override float CalculSpeed(int idx)
    {
        return m_sPStat.m_fSpeed + (m_sPStat.m_fSpeedRate * idx);
    }

    protected override IEnumerator PlayPattern()
    {
        float original = m_sPStat.m_fAngle;

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

                m_sPStat.m_fAngle += m_sPStat.m_fRotateAngleRate;
            }

            yield return new WaitForSeconds(m_sPStat.m_fFireInterval);
            m_sPStat.m_fAngle = original;
        }

    }

    public override void PatternStop()
    {

    }
}
