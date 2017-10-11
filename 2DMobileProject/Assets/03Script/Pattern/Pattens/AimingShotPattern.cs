using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingShotPattern : BasePattern {

    public override void init()
    {
        m_sPStat.m_ePattern = PATTERN_NAME.AIMING_SHOT;
    }

    public override void PatternDead()
    {
        StopCoroutine(PlayPattern());
    }


    protected override float CalculAngle(int idx)
    {
        return MeCalculShipAngle();

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
