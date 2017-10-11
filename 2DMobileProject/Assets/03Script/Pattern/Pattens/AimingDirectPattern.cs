using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingDirectPattern : BasePattern {

    public override void init()
    {
        m_sPStat.m_ePattern = PATTERN_NAME.AIMING_DIRECT;
    }

    public override void PatternDead()
    {
        StopCoroutine(PlayPattern());
    }


    protected override float CalculAngle(int idx)
    {
        return m_sPStat.m_fAngle;
    }

   

    protected override IEnumerator PlayPattern()
    {

        while (true)
        {
            if (m_sPStat.m_isMyPos)
                m_sPStat.m_fAngle = CalculShipAngle();
            else m_sPStat.m_fAngle = MeCalculShipAngle();

            for (int i = 0; i < m_sPStat.m_iFireCount; i++)
            {
                FireBullet(i);

                yield return new WaitForSeconds(m_sPStat.m_fMiniFireInterval);
            }

                //Instantiate(m_cBullet).
                //    AddComponent<Bullet>().
                //    FireBullet(
                //    m_cSootingMover.transform.position,
                //    m_sPStat.m_fSpeed,
                //    m_sPStat.m_fAngle + (90 * i),
                //    m_sPStat.m_fBullet_SpeedRate,
                //    m_sPStat.m_fBullet_AngleRate,
                //    m_sPStat.m_shape);
            
            //     m_sPStat.m_fAngle += m_sPStat.m_fAngleRate;
            yield return new WaitForSeconds(m_sPStat.m_fFireInterval);
        }
    }

    public override void PatternStop()
    {

    }
}
