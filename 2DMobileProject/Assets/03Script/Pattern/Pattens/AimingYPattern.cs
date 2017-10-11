using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingYPattern : BasePattern
{

    public override void init()
    {
        m_sPStat.m_ePattern = PATTERN_NAME.AIMING_Y;
    }

    public override void PatternDead()
    {
        StopCoroutine(PlayPattern());
    }

    protected override float CalculAngle(int idx)
    {
        return m_sPStat.m_fAngle;
    }

    protected override void FireBullet(int idx)
    {

        m_StartPos.x = m_cEnemyShooting.transform.position.x;


        if (m_cSootingMover.m_eType != MoverType.Player)
        {
            m_cBullet = BulletMGR.Instance.PopBullet();
        }
        else
        {
            m_cBullet = PlayerBulletMGR.Instance.PopBullet();
        }

        FinalFireBullet(idx);

    }

    protected override IEnumerator PlayPattern()
    {
        while (true)
        {
            for (int i = 0; i < m_sPStat.m_iFireCount; i++)
            {
                FireBullet(i);
                yield return new WaitForSeconds(m_sPStat.m_fMiniFireInterval);
            }

            yield return new WaitForSeconds(m_sPStat.m_fFireInterval);
        }
    }
    public override void PatternStop()
    {

    }
}
