using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RRShotGunPattern : RotateShotGunPattern {

    public override void init()
    {
        m_sPStat.m_ePattern = PATTERN_NAME.ROTATE_RANDOM_SHOTGUN;
    }

    protected override float CalculAngle(int idx)
    {
        return m_sPStat.m_fAngle + m_sPStat.m_fAngleRate * (Random.Range(0.0f, 1.0f) - 0.5f);
    }
}
